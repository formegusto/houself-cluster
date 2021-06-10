
namespace houself_cluster.Atom
{
	partial class AllChart
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Body = new MetroFramework.Controls.MetroPanel();
			this.Chart = new LiveCharts.WinForms.CartesianChart();
			this.Body.SuspendLayout();
			this.SuspendLayout();
			// 
			// Body
			// 
			this.Body.Controls.Add(this.Chart);
			this.Body.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Body.HorizontalScrollbarBarColor = true;
			this.Body.HorizontalScrollbarHighlightOnWheel = false;
			this.Body.HorizontalScrollbarSize = 10;
			this.Body.Location = new System.Drawing.Point(20, 60);
			this.Body.Name = "Body";
			this.Body.Size = new System.Drawing.Size(1160, 920);
			this.Body.TabIndex = 0;
			this.Body.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Body.VerticalScrollbarBarColor = true;
			this.Body.VerticalScrollbarHighlightOnWheel = false;
			this.Body.VerticalScrollbarSize = 10;
			// 
			// Chart
			// 
			this.Chart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Chart.Location = new System.Drawing.Point(0, 0);
			this.Chart.Name = "Chart";
			this.Chart.Size = new System.Drawing.Size(1160, 920);
			this.Chart.TabIndex = 2;
			this.Chart.Text = "cartesianChart1";
			// 
			// AllChart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1200, 1000);
			this.Controls.Add(this.Body);
			this.Name = "AllChart";
			this.Text = "AllChart";
			this.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Body.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroPanel Body;
		private LiveCharts.WinForms.CartesianChart Chart;
	}
}