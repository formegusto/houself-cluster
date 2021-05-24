using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using houself_cluster.Common;

namespace houself_cluster
{
	public delegate void ViewHandler<IView>(IView sender, ViewEventArgs e);

	public class ViewEventArgs: EventArgs
	{
		public string action;
		public Dictionary<string, dynamic> payload;

		public ViewEventArgs(string a)
		{
			this.action = a;
		}
		public ViewEventArgs(string a, Dictionary<string, dynamic> p = null) {
			this.action = a;
			this.payload = p;
		}
	}

	public interface IView
	{
		event ViewHandler<IView> changed;
		void SetController(IController controller);
	}
}
