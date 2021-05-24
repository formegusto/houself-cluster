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
	}
	public class HouselfClusterModel: IModel
	{
		public event ModelHandler<HouselfClusterModel> changed;
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
	}
}
