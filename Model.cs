using Microsoft.Office.Interop.Excel;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using houself_cluster.Common;
using houself_cluster.Utils;

namespace houself_cluster
{
	public delegate void ModelHandler<IModel>(IModel sender, ModelEventArgs e);
	public class ModelEventArgs: EventArgs
	{
		public string action;
		public Dictionary<string, dynamic> payload;

		public ModelEventArgs(string a)
		{
			this.action = a;
		}
		public ModelEventArgs(string a, Dictionary<string,dynamic> p = null)
		{
			this.action = a;
			this.payload = p;
		}
	}
	public interface IModelObserver
	{
		void ModelNotify(IModel model, ModelEventArgs e);
	}
	public interface IModel
	{
		void Attach(IModelObserver observer);
		void ChangeOption(string action, Dictionary<string, dynamic> payload);
		void InitLoadExcel();
		// 1. UID 탐색
		void StartClustering();
		// 2. Datas 구성
		void SetDatas();
		// 3. Data Preprocessing : Timeslot 기반
		void DataPreprocessing();
		// 4. Cluster 구성
		void SetCluster();
		// 5. Assign Instance 
		void AssignInstance();
		void ReSetCluster();
	}
	public class HouselfClusterModel: IModel
	{
		public event ModelHandler<HouselfClusterModel> changed;
		// Load Excel Datas
		public object[,] cell;
		public List<Data> datas;
		public List<Cluster> clusters;
		public ClusterOptions options;
		public HouselfClusterModel()
		{
			//
			// Cluster Option Config
			//
			this.options = new ClusterOptions();
			this.options.keyword = "";
			this.options.day = Day.SUN;
			this.options.season = Season.ALL;
			this.options.timeslot = Timeslot.H3;
		}
		public void Attach(IModelObserver imo)
		{
			this.changed += new ModelHandler<HouselfClusterModel>(imo.ModelNotify);
		}
		public void ChangeOption(string a, Dictionary<string, dynamic> p)
		{
			switch(a)
			{
				case VIEW_ACTION.CHANGE_DAYS:
					this.options.day = (Day) p["tabPageIdx"];
					Console.WriteLine(this.options.day);
					break;
				case VIEW_ACTION.CHANGE_SEASONS:
					this.options.season = (Season) p["tabPageIdx"];
					Console.WriteLine(this.options.season);
					break;
				case VIEW_ACTION.CHANGE_KEYWORD:
					this.options.keyword = p["keyword"];
					Console.WriteLine(this.options.keyword);
					break;
			}
		}
		public void ReSetCluster()
		{
			for(int k = 0; k < this.options.K; k++)
			{
				for (int e = 0; e < this.clusters[k].timeslot.Length; e++)
				{
					this.clusters[k].timeslot[e] = 0;
					for (int i = 0; i < this.clusters[k].instances.Count; i++)
					{
						this.clusters[k].timeslot[e] += this.clusters[k].instances[i].timeslot[e];
						Console.WriteLine(this.clusters[k].timeslot[e]);
					}
					this.clusters[k].timeslot[e] /= this.clusters[k].instances.Count;
					
				}
			}

			this.changed.Invoke(this, new ModelEventArgs(
					MODEL_ACTION.RECLUSTER_SUCCESS,
				new Dictionary<string, dynamic>() {
					{"clusters", this.clusters },
					{"K", this.options.K }
				}));
		}
		public void InitLoadExcel()
		{
			this.changed.Invoke(this, new ModelEventArgs(COMMON_ACTION.START_LOADING));

			Task.Run(() =>
			{
				string path = System.Windows.Forms.Application.StartupPath + @"\all_datas\4개아파트_15분데이터(180501-190430).xlsx";

				Application application = new Application();
				Workbooks wbs = application.Workbooks;
				Workbook wb = wbs.Open(path);
				this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTION.READ_FILE_SUCCESS));

				Sheets shs = wb.Worksheets;
				Worksheet ws = shs.get_Item(1) as Worksheet;
				Range range = ws.UsedRange;

				try
				{
					this.cell = ws.UsedRange.Value;
				}
				catch
				{
					Console.WriteLine("Error!");
					this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTION.INIT_EXCEL_LOAD_FAILURE));
					return;
				}

				LOAD_EXCEL_CONFIG.ROW = this.cell.GetLength(0);
				LOAD_EXCEL_CONFIG.COLUMN = this.cell.Length / LOAD_EXCEL_CONFIG.ROW;
				LOAD_EXCEL_CONFIG.USER = LOAD_EXCEL_CONFIG.COLUMN - 7;

				this.changed.Invoke(this, new ModelEventArgs(COMMON_ACTION.STOP_LOADING));
				this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTION.INIT_EXCEL_LOAD_SUCCESS));
			});
		}
		public void StartClustering()
		{
			Console.WriteLine(LOAD_EXCEL_CONFIG.ToString());
			Console.WriteLine(this.options.ToString());

			int searchCol = LOAD_EXCEL_CONFIG.STARTCOLUMN;
			// 1. UID 탐색
			for (; searchCol < LOAD_EXCEL_CONFIG.COLUMN + 1; searchCol++) {
				if (this.options.keyword
						==
						string.Format("{0}-{1}-{2}", cell[3, searchCol], cell[4, searchCol], cell[5, searchCol])) {
					Console.WriteLine(string.Format("칼럼 {0} 번째 찾았습니다.\n", searchCol));
					break;
				}
			}

			if (!(searchCol < (LOAD_EXCEL_CONFIG.COLUMN + 1))) { 
				Console.WriteLine(string.Format("{0} 가구는 존재하지 않습니다.\n", this.options.keyword == "" ? "[Empty]" : this.options.keyword));
				this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTION.SEARCH_KEYWORD_NOTFOUND));

				return;
			}

			this.options.searchCol = searchCol;
			this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTION.SEARCH_KEYWORD_FIND));
		}

		public void SetDatas()
		{
			List<Data> datas = new List<Data>();

			for(int r = LOAD_EXCEL_CONFIG.STARTROW; r <= LOAD_EXCEL_CONFIG.ROW; r+=96)
			{
				// Date Parse
				DateTime date = DateTime.ParseExact(
					cell[r, LOAD_EXCEL_CONFIG.DATECOLUMN].ToString(),
					"yyyyMMdd",
					null
					);
				if ((int)date.DayOfWeek == (int)this.options.day)
				{
					// TimeSlot Parse
					List<double> timeslot = new List<double>();
					for(int rr = r; rr < r + 96; rr++)
						timeslot.Add(double.Parse(cell[rr, this.options.searchCol].ToString()) * 1000);

					datas.Add(new Data(
						date,
						this.options.keyword,
						timeslot.ToArray()
						));
				}
			}

			this.options.K = (int) Math.Pow(datas.Count / 2, 1f / 2);
			this.datas = datas;

			Console.WriteLine(LOAD_EXCEL_CONFIG.ToString());
			Console.WriteLine(this.options.ToString());

			this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTION.REQUEST_DATAS_SUCCESS));
		}

		public void DataPreprocessing()
		{
			// 차원 축소
			List<Data> newDatas = new List<Data>();

			this.datas.ForEach((data) =>
			{
				Data newData = new Data(
					data.date,	
					data.uid,
					new double[(int) this.options.timeslot]
					);
				for (int t = 0; t < data.timeslot.Length; t++)
					newData.timeslot
						[t / 
							(LOAD_EXCEL_CONFIG.TIMESLOT / 
								(int)this.options.timeslot)] 
						+= data.timeslot[t];

				newDatas.Add(newData);
			});

			Console.WriteLine(newDatas[0].timeslot.Length);
			this.datas = newDatas;

			this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTION.DATA_PREPROCESSING_SUCCESS));
		}

		public void SetCluster()
		{
			Random random = new Random();
			
			List<Cluster> clusters = new List<Cluster>();

			for(int k = 0; k < this.options.K; k++)
				clusters.Add(null);

			int firstCluster = random.Next(0, this.datas.Count);
			double[] copyTimeslot = new double
				[this.datas[firstCluster].timeslot.Length];
			this.datas[firstCluster].timeslot.CopyTo(copyTimeslot, 0);

			clusters[0] = new Cluster(
				new DateTime(),
				"cluster-1",
				copyTimeslot
				);

			for(int k = 1; k < this.options.K; k++)
			{
				Console.WriteLine(string.Format("{0}번 클러스터 구성 중", k));
				double[] distanceArr = new double[this.datas.Count];

				for(int s = 0; s < this.datas.Count; s++)
				{
					double minDistance = Math.Sqrt(double.MaxValue);
					for (int kk = 0; kk < k; kk++)
					{
						double distance = Operator.Distance(this.datas[s].timeslot, clusters[kk].timeslot, minDistance);
						if (minDistance > distance)
							minDistance = distance;
					}

					distanceArr[s] = minDistance;
				}

				double[] roulette = new double[distanceArr.Length];
				roulette[0] = distanceArr[0];
				for (int r = 1; r < roulette.Length; r++)
					roulette[r] = roulette[r - 1] + distanceArr[r];

				bool isChk = false;
				while (!isChk)
				{
					double ranValue = random.NextDouble() * roulette[roulette.Length - 1];
					for (int r = 0; r < roulette.Length; r++)
						if (ranValue <= roulette[r])
						{
							double[] copyTs = new double[
									this.datas[r].timeslot.Length
								];
							for(int t = 0; t < this.datas[r].timeslot.Length; t++)
								 copyTs[t] = this.datas[r].timeslot[t];

							Cluster data = new Cluster(
								new DateTime(),
								string.Format("cluster-{0}", k + 1),
								copyTs
								);

							Data test = clusters.Find((cluster) => cluster != null && cluster.CompareTS(data));
							
							if(test == null)
							{
								isChk = true;
								clusters[k] = data;
							}
						}
				}
				
			}

			this.clusters = clusters;
			this.clusters.ForEach((cluster) =>
			{
				cluster.ToPrint();
			});


			this.changed.Invoke(this, new ModelEventArgs(
				MODEL_ACTION.SET_CLUSTER_SUCCESS, 
				new Dictionary<string, dynamic>() {
					{ "clusters", this.clusters },
					{ "K", this.options.K }
				}));
		}

		public async void AssignInstance()
		{
			for (int k = 0; k < this.options.K; k++)
			{
				this.clusters[k].instances.Clear();
				this.clusters[k].initSeasonFrequeny();
			}

			for(int d = 0; d< this.datas.Count; d++) {
				await Task.Run(() =>
				{
					double min1 = Math.Sqrt(double.MaxValue) - 1, min2 = Math.Sqrt(double.MaxValue);

					for (int k = 0; k < this.options.K; k++)
					{
						double distance = Operator.Distance(clusters[k].timeslot, datas[d].timeslot, min2);
						if (min1 > distance)
						{
							min2 = min1;
							this.datas[d].subCluster = this.datas[d].mainCluster;
							min1 = distance;
							this.datas[d].distance = min1;
							this.datas[d].mainCluster = k;
						}
						else if (min2 > distance)
						{
							min2 = distance;
							this.datas[d].subCluster = k;
						}
					}

					int mK = this.datas[d].mainCluster;
					/*
					Console.WriteLine(this.clusters[this.datas[d].mainCluster] + "Have" + this.datas[d].uid + "\n" +
						"this date " + this.datas[d].date.ToString("yyyyMMdd") + "\n" +
						"this season " + );
						*/
					this.changed.Invoke(this, new ModelEventArgs(
						MODEL_ACTION.ASSIGN_INSTANCE_SUCCESS,
						new Dictionary<string, dynamic>()
						{
						{"data", this.datas[d] },
						{"cluster", this.datas[d].mainCluster }
						}));

					this.clusters[mK].instances.Add(this.datas[d]);
					Season season = DateUtils.DateToSeason(this.datas[d].date);
					if (this.clusters[mK].seasonFrequency.ContainsKey(season))
					{
						this.clusters[mK].seasonFrequency[season] += 1;
					}

				});
			}

			this.clusters.ForEach((c) =>
			{
				Console.WriteLine(string.Format("----{0} season Frequency----", c.uid));
				foreach(KeyValuePair<Season,int> items in c.seasonFrequency)
				{
					Console.WriteLine(string.Format("Season ==> {0}, Frequency ==> {1}", items.Key, items.Value));
				}
			});
			this.changed.Invoke(this, new ModelEventArgs(
				MODEL_ACTION.ASSIGN_ALL_INSTANCE_SUCCESS
				));
		}
	}
}
