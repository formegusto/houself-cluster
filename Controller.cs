using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using houself_cluster.Common;

namespace houself_cluster
{
	public interface IController
	{
		void Dispatch(string action, Dictionary<string, dynamic> payload = null);
	}
	public class HouselfClusterController: IController
	{
		IView view;
		IModel model;
		public void ViewChanged(IView v, ViewEventArgs e)
		{
			Console.WriteLine(string.Format("[View:ViewEventArgs -> Model] {0}", e.action));
			switch (e.action)
			{
				case VIEW_ACTION.CHANGE_KEYWORD:
					this.model.ChangeOption(e.action, e.payload);
					break;
				case VIEW_ACTION.CHANGE_DAYS:
				case VIEW_ACTION.CHANGE_SEASONS:
				case VIEW_ACTION.CHANGE_TIMESLOT:
					this.model.ChangeOption(e.action, e.payload);
					break;
				case VIEW_ACTION.INIT_EXCEL_LOAD:
					this.model.InitLoadExcel();
					break;
				case VIEW_ACTION.START_CLUSTERING:
					this.model.StartClustering();
					break;
				case VIEW_ACTION.RECLUSTER:
					this.model.ReSetCluster();
					break;
				case VIEW_ACTION.SAVEMODE:
					this.model.SaveMode();
					break;
				case VIEW_ACTION.MERGECLUSTER:
					this.model.MergeCluster();
					break;
				case VIEW_ACTION.EVALUATE:
					this.model.Evaluate();
					break;
				case VIEW_ACTION.SEASON_STATISTIC:
					this.model.SeasonStatistic();
					break;
				case VIEW_ACTION.CONFIRM:
					this.model.Confirm();
					break;
				case VIEW_ACTION.REQUEST_FS:
					this.model.FeatureScaling();

					break;
			}
		}
		public void Dispatch(string action, Dictionary<string, dynamic> payload = null)
		{
			Console.WriteLine(string.Format("[View:ModelEvent -> Model] {0}", action));

			switch(action)
			{
				case MODEL_ACTION.REQUEST_DATAS:
					this.model.SetDatas();

					break;
				case MODEL_ACTION.DATA_PREPROCESSING:
					this.model.DataPreprocessing();

					break;
				case MODEL_ACTION.SET_CLUSTER:
					this.model.SetCluster();

					break;
				case MODEL_ACTION.ASSIGN_INSTANCE:
					this.model.AssignInstance();

					break;
				default:
					return;
			}
		}
		public HouselfClusterController(IView v, IModel m)
		{
			this.view = v;
			this.model = m;
			this.view.SetController(this);
			this.model.Attach((IModelObserver)this.view);
			this.view.changed += new ViewHandler<IView>(this.ViewChanged);
		}
	}
}
