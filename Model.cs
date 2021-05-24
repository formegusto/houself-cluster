using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace houself_cluster
{
	public delegate void ModelHandler<IModel>(IModel sender, ModelEventArgs e);
	public class ModelEventArgs: EventArgs
	{

	}

	public interface IModelObserver
	{
		void ModelNotify(IModel model, ModelEventArgs e);
	}

	public interface IModel
	{
		void Attach(IModelObserver observer);
	}

	public class HouselfClusterModel: IModel
	{
		public event ModelHandler<HouselfClusterModel> changed;

		public void Attach(IModelObserver imo)
		{
			this.changed += new ModelHandler<HouselfClusterModel>(imo.ModelNotify);
		}
	}
}
