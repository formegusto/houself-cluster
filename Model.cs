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
		void ChangeOption(string action, int tabPageIdx);
		void InitLoadExcel();
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
			this.options.day = Day.SUN;
			this.options.season = Season.ALL;
		}
		public void Attach(IModelObserver imo)
		{
			this.changed += new ModelHandler<HouselfClusterModel>(imo.ModelNotify);
		}
		public void ChangeOption(string a, int tabPageIdx)
		{
			switch(a)
			{
				case VIEW_ACTION.CHANGE_DAYS:
					this.options.day = (Day)tabPageIdx;
					Console.WriteLine(this.options.day);
					break;
				case VIEW_ACTION.CHANGE_SEASONS:
					this.options.season = (Season)tabPageIdx;
					Console.WriteLine(this.options.season);
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
				Console.WriteLine(1);
				Workbook wb = wbs.Open(path);
				Console.WriteLine(2);
				Sheets shs = wb.Worksheets;
				Console.WriteLine(3);
				Worksheet ws = shs.get_Item(1) as Worksheet;
				Console.WriteLine(4);
				Range range = ws.UsedRange;
				Console.WriteLine(5);

				try
				{
					this.cell = ws.UsedRange.Value;
					Console.WriteLine(6);
				}
				catch
				{
					Console.WriteLine("Error!");
					this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTION.INIT_EXCEL_LOAD_FAILURE));
					return;
				}

				this.changed.Invoke(this, new ModelEventArgs(COMMON_ACTION.STOP_LOADING));
				this.changed.Invoke(this, new ModelEventArgs(MODEL_ACTION.INIT_EXCEL_LOAD_SUCCESS));
			});
		}
	}
}
