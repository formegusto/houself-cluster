namespace houself_cluster.Atom
{
	partial class AllTableChart
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
			this.ChartTable = new System.Windows.Forms.TableLayoutPanel();
			this.Body.SuspendLayout();
			this.SuspendLayout();
			// 
			// Body
			// 
			this.Body.Controls.Add(this.ChartTable);
			this.Body.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Body.HorizontalScrollbarBarColor = true;
			this.Body.HorizontalScrollbarHighlightOnWheel = false;
			this.Body.HorizontalScrollbarSize = 10;
			this.Body.Location = new System.Drawing.Point(20, 60);
			this.Body.Name = "Body";
			this.Body.Size = new System.Drawing.Size(1400, 820);
			this.Body.TabIndex = 0;
			this.Body.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Body.VerticalScrollbarBarColor = true;
			this.Body.VerticalScrollbarHighlightOnWheel = false;
			this.Body.VerticalScrollbarSize = 10;
			// 
			// ChartTable
			// 
			this.ChartTable.ColumnCount = 3;
			this.ChartTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.ChartTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.ChartTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.ChartTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ChartTable.Location = new System.Drawing.Point(0, 0);
			this.ChartTable.Name = "ChartTable";
			this.ChartTable.RowCount = 3;
			this.ChartTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.ChartTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.ChartTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.ChartTable.Size = new System.Drawing.Size(1400, 820);
			this.ChartTable.TabIndex = 2;
			// 
			// AllTableChart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1440, 900);
			this.Controls.Add(this.Body);
			this.Name = "AllTableChart";
			this.Text = "AllTableChart";
			this.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Body.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroPanel Body;
		private System.Windows.Forms.TableLayoutPanel ChartTable;
	}
}