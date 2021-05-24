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
			Console.WriteLine(string.Format("[View -> Model] {0}", e.action));
			switch (e.action)
			{
				case VIEW_ACTION.CHANGE_DAYS:
				case VIEW_ACTION.CHANGE_SEASONS:
					this.model.ChangeOption(e.action, e.payload["tabPageIdx"]);
					break;
			}
		}
		public void Dispatch(string action, Dictionary<string, dynamic> payload = null)
		{
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
