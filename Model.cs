using Microsoft.Office.Interop.Excel;

using System;
using System.Collections.Generic;
using System.Threading;
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
		void StartClustering(bool isNotify = false);
		// 2. Datas 구성
		void SetDatas(bool isNotify = false);
		// 3. Data Preprocessing : Timeslot 기반
		void DataPreprocessing(bool isNotify = false);
		// 4. Cluster 구성
		void SetCluster();
		// 5. Assign Instance 
		void AssignInstance();
		void ReSetCluster();
		void SaveMode();
		void MergeCluster();
		void Evaluate();
		void SeasonStatistic();
		void Confirm();
		void FeatureScaling();
	}
	public class HouselfClusterModel: IModel
	{
		public event ModelHandler<HouselfClusterModel> changed;
		// Load Excel Datas
		public object[,] cell;
		public int mergeLv;
		public List<Data> initDatas;
		public List<Data> datas;
		public List<Cluster> clusters;
		public ClusterOptions options;
		public HouselfClusterModel()
		{
			//
			// Cluster Option Config
			//
			this.mergeLv = 0;
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
		public void FeatureScaling()
		{
			this.StartClustering(true);
			this.SetDatas(true);
			this.DataPreprocessing(true);


			double maxTS = -1;
			double minTS = Double.MaxValue;
			this.datas.ForEach((data) =>
			{
				for(int t=0;t< data.timeslot.Length; t++)
				{
					if (data.timeslot[t] > 0 && data.timeslot[t] > maxTS) { 
						maxTS = data.timeslot[t];
					}
					if (data.timeslot[t] > 0 && data.timeslot[t] < minTS){ 
						minTS = data.timeslot[t];
					}
				}
			});

			// 정규화
			this.datas.ForEach((data) =>
			{
				for (int t = 0; t < data.timeslot.Length; t++)
				{
					data.timeslot[t] = Math.Round((data.timeslot[t] - minTS) / (maxTS - minTS), 2);
				}
			});

			this.changed.Invoke(this,
				new ModelEventArgs(
					MODEL_ACTION.DATA_PREPROCESSING_SUCCESS));
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
				case VIEW_ACTION.CHANGE_TIMESLOT:
					switch(p["tabPageIdx"])
					{
						case 0:
							this.options.timeslot = Timeslot.H3;
							break;
						case 1:
							this.options.timeslot = Timeslot.H4;
							break;
						case 2:
							this.options.timeslot = Timeslot.H6;
							break;
						case 3:
							this.options.timeslot = Timeslot.H8;
							break;
						case 4:
							this.options.timeslot = Timeslot.H12;
							break;
						case 5:
							this.options.timeslot = Timeslot.H24;
							break;
					}
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
				if(this.clusters[k].direct)
				{
					this.clusters[k].direct = false;
					continue;
				}

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

			/*
			List<Cluster> movingClusters = new List<Cluster>();
			this.clusters.ForEach((cluster) =>
			{
				Cluster newData = new Cluster(
					cluster.date,
					cluster.uid,
					new double[(int)this.options.timeslot]
					);

				double partialSum = 0.0;
				for (int t = 0; t < cluster.timeslot.Length; t++)
				{
					partialSum += cluster.timeslot[t];
					if (t < (1))
					{
						newData.timeslot[t] = cluster.timeslot[t];
					}
					else
					{
						newData.timeslot[t] = partialSum / 2;
						partialSum -= cluster.timeslot[t - 1];
					}
				}
				movingClusters.Add(newData);
			});
			this.clusters = movingClusters;
			
			/*
			this.clusters.ForEach((data) =>
			{
				double k = 2 / (data.timeslot.Length + 1);
				for (int t = data.timeslot.Length - 1; t > 0; t--)
				{
					data.timeslot[t] = (data.timeslot[t] - data.timeslot[t - 1]) * k + data.timeslot[t - 1];
				}
			});
			/**/

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
		public void StartClustering(bool isNotify=false)
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

			if(!isNotify)
			{
				this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTION.SEARCH_KEYWORD_FIND));
			}
			
		}

		public void SetDatas(bool isNotify = false)
		{
			List<Data> datas = new List<Data>();
			List<int> targetMonth = SeasonUtils.SeasonToMonth(this.options.season);


			for(int r = LOAD_EXCEL_CONFIG.STARTROW; r <= LOAD_EXCEL_CONFIG.ROW; r+=96)
			{
				// Date Parse
				DateTime date = DateTime.ParseExact(
					cell[r, LOAD_EXCEL_CONFIG.DATECOLUMN].ToString(),
					"yyyyMMdd",
					null
					);

				
				if (!targetMonth.Contains(date.Month)) {
					// Console.WriteLine("왜 안드러와");
					continue;
				}

				if ((int)date.DayOfWeek == (int)this.options.day)
				{
					// TimeSlot Parse
					List<double> timeslot = new List<double>();
					for(int rr = r; rr < r + 96; rr++) {
						double parseData = 0;
						try
						{
							parseData = double.Parse(cell[rr, this.options.searchCol].ToString()) * 1000;
							
						} catch(FormatException e)
						{
							parseData = 0;
						} finally
						{
							timeslot.Add(parseData);
						}
						
					}

					Data newData = new Data(
						date,
						this.options.keyword,
						timeslot.ToArray());

					// 검증
					if(!newData.isZero())
						datas.Add(newData);
				}
			}

			if(this.options.season != Season.ALL)
			{
				this.options.K = (int)Math.Pow(datas.Count / 2, 1f / 2) + 1;
			} else
			{
				this.options.K = (int)Math.Pow(datas.Count / 2, 1f / 2);
			}
			
			this.datas = datas;

			Console.WriteLine(LOAD_EXCEL_CONFIG.ToString());
			Console.WriteLine(this.options.ToString());

			if(!isNotify)
			{
				this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTION.REQUEST_DATAS_SUCCESS));
			}
			
		}

		public void DataPreprocessing(bool isNotify = false)
		{
			this.initDatas = this.datas;
			// 이동평균
			// 3h로 일단 고정
				
			List<Data> movingDatas = new List<Data>();
			this.datas.ForEach((data) =>
			{
				Data newData = new Data(
					data.date,
					data.uid,
					new double[data.timeslot.Length]
					);

				double partialSum = 0.0;
				for(int t = 0; t < data.timeslot.Length ; t++)
				{
					partialSum += data.timeslot[t];
					if (t < (3 - 1))
					{
						newData.timeslot[t] = data.timeslot[t];
					} else
					{
						newData.timeslot[t] = partialSum / 3;
						partialSum -= data.timeslot[t - (3 - 1)];
					}
				}
				movingDatas.Add(newData);
			});
			this.datas = movingDatas;
		
			/*
			// 지수 이동 평균
			List<Data> SMA = new List<Data>();
			this.datas.ForEach((data) =>
			{
				double k = 2 / (data.timeslot.Length + 1);
				Data newData = new Data(
						data.date,
						data.uid,
						new double[data.timeslot.Length]
					);
				for(int t = data.timeslot.Length - 1; t > 0; t--)
				{
					data.timeslot[t] = (data.timeslot[t] - data.timeslot[t - 1]) * k + data.timeslot[t - 1];
				}
			});
			/*
			*/
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
				{
					newData.timeslot
						[t /
							(LOAD_EXCEL_CONFIG.TIMESLOT /
								(int)this.options.timeslot)]
						+= data.timeslot[t];
					if(((t + 1) /
							(LOAD_EXCEL_CONFIG.TIMESLOT /
								(int)this.options.timeslot)) != 
						(t /
							(LOAD_EXCEL_CONFIG.TIMESLOT /
								(int)this.options.timeslot)))
					{
						data.timeslot[t] /= (int)this.options.timeslot;
					}
				}

				newDatas.Add(newData);
			});
			
			this.datas = newDatas;
			// this.initDatas = this.datas;

			/*
			List<Data> movingDatas = new List<Data>();
			this.datas.ForEach((data) =>
			{
				Data newData = new Data(
					data.date,
					data.uid,
					new double[(int)this.options.timeslot]
					);

				double partialSum = 0.0;
				for (int t = 0; t < data.timeslot.Length; t++)
				{
					partialSum += data.timeslot[t];
					if (t < (1))
					{
						newData.timeslot[t] = data.timeslot[t];
					}
					else
					{
						newData.timeslot[t] = partialSum / 2;
						partialSum -= data.timeslot[t - 1];
					}
				}
				movingDatas.Add(newData);
			});
			this.datas = movingDatas;

			/*
			this.datas.ForEach((data) =>
			{
				double k = 2 / (data.timeslot.Length + 1);
				for (int t = data.timeslot.Length - 1; t > 0; t--)
				{
					data.timeslot[t] = (data.timeslot[t] - data.timeslot[t - 1]) * k + data.timeslot[t - 1];
				}
			});
			*/

			Console.WriteLine(newDatas[0].timeslot.Length);

			if (!isNotify)
			{
				this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTION.DATA_PREPROCESSING_SUCCESS));
			}
			
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

			mergeLv = 0;
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

			// cluster 이동평균 설정
			/*
			List<Cluster> movingClusters = new List<Cluster>();
			this.clusters.ForEach((cluster) =>
			{
				Cluster newData = new Cluster(
					cluster.date,
					cluster.uid,
					new double[(int)this.options.timeslot]
					);

				double partialSum = 0.0;
				for (int t = 0; t < cluster.timeslot.Length; t++)
				{
					partialSum += cluster.timeslot[t];
					if (t < (1))
					{
						newData.timeslot[t] = cluster.timeslot[t];
					}
					else
					{
						newData.timeslot[t] = partialSum / 2;
						partialSum -= cluster.timeslot[t - 1];
					}
				}
				movingClusters.Add(newData);
			});
			this.clusters = movingClusters;
			/*
			this.clusters.ForEach((data) =>
			{
				double k = 2 / (data.timeslot.Length + 1);
				for (int t = data.timeslot.Length - 1; t > 0; t--)
				{
					data.timeslot[t] = (data.timeslot[t] - data.timeslot[t - 1]) * k + data.timeslot[t - 1];
				}
			});
			/**/

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
					if(min1 < 0.095)
					{
						this.changed.Invoke(this, new ModelEventArgs(
						MODEL_ACTION.ASSIGN_INSTANCE_SUCCESS,
						new Dictionary<string, dynamic>()
						{
							{"data", this.datas[d] },
							{"cluster", this.datas[d].mainCluster }
						}));
					}
					

					this.clusters[mK].instances.Add(this.datas[d]);
					Season season = DateUtils.DateToSeason(this.datas[d].date);
					this.clusters[mK].seasonFrequency[(int)season - 1].frequency++;

				});
			}

			this.clusters.ForEach((c) =>
			{
				c.seasonFrequency.Sort();
				Console.WriteLine(string.Format("----{0} season Frequency----", c.uid));
				c.seasonFrequency.ForEach((sf) =>
				{
					Console.WriteLine(string.Format("Season ==> {0}, Frequency ==> {1}", sf.season, sf.frequency));
				});
				/*
				foreach(KeyValuePair<Season,int> items in c.seasonFrequency)
				{
					Console.WriteLine(string.Format("Season ==> {0}, Frequency ==> {1}", items.Key, items.Value));
				}
				*/
			});
			this.changed.Invoke(this, new ModelEventArgs(
				MODEL_ACTION.ASSIGN_ALL_INSTANCE_SUCCESS,
				new Dictionary<string, dynamic>() {
					{ "clusters", this.clusters },
					{ "K", this.options.K },
				}));
		}

		public void SaveMode()
		{
			this.changed.Invoke(this, new ModelEventArgs(
				MODEL_ACTION.SAVEMODE_DATA,
				new Dictionary<string, dynamic>() {
					{ "option", this.options }
				}));
		}

		public void MergeCluster()
		{
			/*
			Console.WriteLine("현재 클러스터들 값");
			this.clusters.ForEach((cluster) =>
			{
				cluster.ToPrint();
			});
			*/
			if (this.options.season == Season.ALL) return;
			mergeLv++;
			int maxFrequencyIdx = 0;
			int frequency = clusters[0].seasonFrequency.Find((sf) => sf.season == this.options.season).frequency;

			// 1위 클러스터 만들기
			for (int i = 1; i < clusters.Count; i++)
			{
				if (frequency < clusters[i].seasonFrequency.Find((sf) => sf.season == this.options.season).frequency)
				{
					frequency = clusters[i].seasonFrequency.Find((sf) => sf.season == this.options.season).frequency;
					maxFrequencyIdx = i;
				}
			}

			List<int> secondIdx = new List<int>();
			int secondFrequency = maxFrequencyIdx != 0 ? 
				clusters[0].seasonFrequency.Find((sf) => sf.season == this.options.season).frequency
					:
				clusters[1].seasonFrequency.Find((sf) => sf.season == this.options.season).frequency;
			secondIdx.Add(maxFrequencyIdx != 0 ? 0 : 1);
			for(int i = 0; i < clusters.Count; i++)
			{
				if (maxFrequencyIdx == i) continue;
				if(secondIdx.FindIndex((sec) => sec == i) == -1)
				{
					if (!clusters[i].isUnique(this.options.season))
					{
						if (secondFrequency < clusters[i].seasonFrequency.Find((sf) => sf.season == this.options.season).frequency)
						{
							secondIdx.Clear();
							secondIdx.Add(i);
							secondFrequency = clusters[i].seasonFrequency.Find((sf) => sf.season == this.options.season).frequency;

						}
						else if (secondFrequency == clusters[i].seasonFrequency.Find((sf) => sf.season == this.options.season).frequency)
						{
							secondIdx.Add(i);

						}
					}
					
				}
			}

			Console.WriteLine(string.Format("현재 {0}에 가장 높은 빈도수를 가진\n " +
				"클러스터는 {1} 번째 클러스터입니다.", this.options.season, maxFrequencyIdx));
			Console.WriteLine("2순위");
			secondIdx.ForEach((sec) =>
			{
				Console.WriteLine("{0}", sec);
			});

			// 2순위 합병
			Cluster newCluster = null;
			if (secondIdx.Count > 1)
			{
				double[] timeslot = new double[clusters[secondIdx[0]].timeslot.Length];
				for(int t=0; t < clusters[secondIdx[0]].timeslot.Length; t++)
				{
					double mean = (clusters[secondIdx[0]].timeslot[t]
						+ clusters[secondIdx[1]].timeslot[t]) / 2;
					timeslot[t] = mean;
				}
				Cluster DelCluster_1 = this.clusters[secondIdx[0]];
				Cluster DelCluster_2 = this.clusters[secondIdx[1]];
				newCluster = new Cluster(DateTime.Now, clusters[secondIdx[0]].uid, timeslot, true);
				this.clusters.Remove(DelCluster_1);
				this.clusters.Remove(DelCluster_2);
			} 
			else
			{
				double[] timeslot = new double[clusters[maxFrequencyIdx].timeslot.Length];
				for (int t = 0; t < clusters[maxFrequencyIdx].timeslot.Length; t++)
				{
					double mean = (clusters[maxFrequencyIdx].timeslot[t]
						+ clusters[secondIdx[0]].timeslot[t]) / 2;
					timeslot[t] = mean;
				}
				Cluster DelCluster_1 = this.clusters[maxFrequencyIdx];
				Cluster DelCluster_2 = this.clusters[secondIdx[0]];
				newCluster = new Cluster(DateTime.Now, clusters[maxFrequencyIdx].uid, timeslot, true);
				this.clusters.Remove(DelCluster_1);
				this.clusters.Remove(DelCluster_2);
			}
			this.clusters.Add(newCluster);
			this.options.K--;
			this.changed.Invoke(this, new ModelEventArgs(
				MODEL_ACTION.MERGECLUSTER_SUCCESS,
				new Dictionary<string, dynamic>() {
					{ "cluster", newCluster },
					{ "K", this.options.K },
					{ "Lv", this.mergeLv }
				}));
		}

		public void Evaluate()
		{
			double ECV = Operator.ECV(this.clusters.ToArray(), this.datas.ToArray());

			Console.WriteLine(string.Format("ECV ----> {0} ",ECV));
		}

		public void SeasonStatistic()
		{

			for(int c = 0; c < this.clusters.Count; c++)
			{
				List<Cluster> statistics = new List<Cluster>();

				// 초기화
				for (int s = 0; s < 4; s++)
				{
					double[] timeslot = new double[clusters[c].timeslot.Length];
					for (int t = 0; t < timeslot.Length; t++)
						timeslot[t] = 0;

					statistics.Add(new Cluster(DateTime.Now, string.Format("{0}-{1}", clusters[c].uid, (Season)(s + 1)), timeslot));
				}

				clusters[c].instances.ForEach((data) =>
				{
					for (int t = 0; t < data.timeslot.Length; t++)
						statistics[((int)data.season) - 1].timeslot[t] += data.timeslot[t];
				});

				// 평균 정리
				for (int s = 0; s < 4; s++)
				{
					for (int t = 0; t < statistics[s].timeslot.Length; t++)
						if (statistics[s].timeslot[t] != 0 && clusters[c].seasonFrequency.Find((sf) => sf.season == (Season) (s+1)).frequency != 0)
						{
							statistics[s].timeslot[t] /= clusters[c].seasonFrequency.Find((sf) => sf.season == (Season)(s + 1)).frequency;
						}
				}

				this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTION.SEASON_STATISTIC_SUCCESS, new Dictionary<string, dynamic> { { "statistics", statistics }, { "idx", c } }));

			}
		}

		public void Confirm()
		{
			
			List<Data> newDatas = new List<Data>();
			this.initDatas.ForEach((data) =>
			{
				Data newData = new Data(
					data.date,
					data.uid,
					new double[(int)this.options.timeslot]
					);
				for (int t = 0; t < data.timeslot.Length; t++)
				{
					newData.timeslot
						[t /
							(LOAD_EXCEL_CONFIG.TIMESLOT /
								(int)this.options.timeslot)]
						+= data.timeslot[t];
					if (((t + 1) /
							(LOAD_EXCEL_CONFIG.TIMESLOT /
								(int)this.options.timeslot)) !=
						(t /
							(LOAD_EXCEL_CONFIG.TIMESLOT /
								(int)this.options.timeslot)))
					{
						data.timeslot[t] /= (int)this.options.timeslot;
					}
				}

				newDatas.Add(newData);
			});
			
			
			this.initDatas = newDatas;
			/**/

			// 3h로 일단 고정
			List<Data> movingDatas = new List<Data>();
			this.initDatas.ForEach((data) =>
			{
			Data newData = new Data(
				data.date,
				data.uid,
				new double[data.timeslot.Length]
				);

			double partialSum = 0.0;
			for(int t = 0; t < data.timeslot.Length ; t++)
			{
				partialSum += data.timeslot[t];
				if (t < (3 - 1))
				{
					newData.timeslot[t] = data.timeslot[t];
				} else
				{
					newData.timeslot[t] = partialSum / 3;
					partialSum -= data.timeslot[t - (3 - 1)];
				}
			}
			movingDatas.Add(newData);
			});
			this.initDatas = movingDatas;

			this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTION.CONFIRM_SUCCESS,
				new Dictionary<string, dynamic>
				{
					{"datas", this.initDatas },
					{"clusters", this.clusters },
					{"season", this.options.season }
				}
				));
		}
	}
}
