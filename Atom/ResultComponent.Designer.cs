namespace houself_cluster.Atom
{
	partial class ResultComponent
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.Body.SuspendLayout();
			this.SuspendLayout();
			// 
			// Body
			// 
			this.Body.Controls.Add(this.tableLayoutPanel1);
			this.Body.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Body.HorizontalScrollbarBarColor = true;
			this.Body.HorizontalScrollbarHighlightOnWheel = false;
			this.Body.HorizontalScrollbarSize = 10;
			this.Body.Location = new System.Drawing.Point(20, 60);
			this.Body.Name = "Body";
			this.Body.Size = new System.Drawing.Size(1160, 520);
			this.Body.TabIndex = 0;
			this.Body.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Body.VerticalScrollbarBarColor = true;
			this.Body.VerticalScrollbarHighlightOnWheel = false;
			this.Body.VerticalScrollbarSize = 10;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1160, 520);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// ResultComponent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1200, 600);
			this.Controls.Add(this.Body);
			this.Name = "ResultComponent";
			this.Resizable = false;
			this.Text = "Title";
			this.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Body.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroPanel Body;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}