using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using houself_cluster.Common;

namespace houself_cluster
{
	public partial class Component : MetroFramework.Forms.MetroForm, IView, IModelObserver
	{
		public event ViewHandler<IView> changed;
		public IController controller;
		public void SetController(IController controller)
		{
			this.controller = controller;
		}
		public void ModelNotify(IModel model, ModelEventArgs e)
		{
			Console.WriteLine(string.Format("[Model -> View] {0}", e.action));
		}
		public Component()
		{
			InitializeComponent();
		}
		private void DayTabs_Selected(object sender, TabControlEventArgs e) => this.changed(
			this, new ViewEventArgs(
				VIEW_ACTION.CHANGE_DAYS,
				new Dictionary<string, dynamic>() { { "tabPageIdx", e.TabPageIndex } }));
		private void SeasonTabs_Selected(object sender, TabControlEventArgs e) => this.changed(
			this, new ViewEventArgs(
				VIEW_ACTION.CHANGE_SEASONS,
				new Dictionary<string, dynamic>() { { "tabPageIdx", e.TabPageIndex } }));
	}
}
