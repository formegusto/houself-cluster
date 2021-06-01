using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace houself_cluster.Atom
{
	public partial class ChartPanel :  MetroFramework.Controls.MetroPanel
	{
		public System.Windows.Forms.TableLayoutPanel Table;
		public MetroFramework.Controls.MetroLabel Title;
		public ChartPanel(LiveCharts.WinForms.CartesianChart chart)
		{
			this.Table = new System.Windows.Forms.TableLayoutPanel();
			this.Title = new MetroFramework.Controls.MetroLabel();

			this.SuspendLayout();
			this.Table.SuspendLayout();
			this.Title.SuspendLayout();

			this.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Theme = MetroFramework.MetroThemeStyle.Light;

			this.Table.RowCount = 2;
			this.Table.ColumnCount = 1;
			this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10f));
			this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90f));
			this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Table.Location = Location = new System.Drawing.Point(0, 0);

			this.Title.Text = "";
			this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Title.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Title.Theme = MetroFramework.MetroThemeStyle.Dark;

			this.Table.Controls.Add(this.Title, 0, 0);
			this.Table.Controls.Add(chart, 0, 1);
			this.Controls.Add(this.Table);

			this.ResumeLayout(false);
			this.Title.ResumeLayout(false);
			this.Table.ResumeLayout(false);
		}

		public void SetText(string text)
		{
			this.Title.Text = text;
		}
	}
}
