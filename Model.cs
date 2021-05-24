using Microsoft.Office.Interop.Excel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using houself_cluster.Common;

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
		void StartClustering();
	}
	public class HouselfClusterModel: IModel
	{
		public event ModelHandler<HouselfClusterModel> changed;
		// Load Excel Datas
		public object[,] cell;
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
		}
	}
}
