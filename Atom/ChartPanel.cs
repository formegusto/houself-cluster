using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace houself_cluster.Atom
{
	public partial class ChartPanel :  MetroFramework.Controls.MetroPanel
	{
		public ChartPanel()
		{
			this.SuspendLayout();

			this.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Theme = MetroFramework.MetroThemeStyle.Light;

			this.ResumeLayout(false);
		}
	}
}
