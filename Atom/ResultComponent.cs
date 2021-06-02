using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace houself_cluster.Atom
{
	public partial class ResultComponent : MetroFramework.Forms.MetroForm
	{
		public ResultComponent(List<ChartPanel> chartPanelGroup)
		{
			InitializeComponent();

			for (int c = 0; c < chartPanelGroup.Count; c++)
				this.ChartTable.Controls.Add(chartPanelGroup[c], c % 3, c / 3);
		}
	}
}
