using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
		public void ModelNotify(string action, ModelEventArgs e)
		{
			
		}
		public Component()
		{
			InitializeComponent();
		}
	}
}
