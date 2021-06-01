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
	public partial class ChartContainer : Control
	{
		public ChartContainer(MetroFramework.Controls.MetroLabel title)
		{
			InitializeComponent();

			this.BlockTable.Controls.Add(title, 0, 0);
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
	}
}
