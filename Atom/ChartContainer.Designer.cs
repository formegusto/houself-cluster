
namespace houself_cluster.Atom
{
	partial class ChartContainer
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 구성 요소 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.ChartBlock = new MetroFramework.Controls.MetroPanel();
			this.BlockTable = new System.Windows.Forms.TableLayoutPanel();
			this.ChartBlock.SuspendLayout();
			this.SuspendLayout();
			// 
			// ChartBlock
			// 
			this.ChartBlock.Controls.Add(this.BlockTable);
			this.ChartBlock.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ChartBlock.HorizontalScrollbarBarColor = true;
			this.ChartBlock.HorizontalScrollbarHighlightOnWheel = false;
			this.ChartBlock.HorizontalScrollbarSize = 10;
			this.ChartBlock.Location = new System.Drawing.Point(0, 0);
			this.ChartBlock.Name = "ChartBlock";
			this.ChartBlock.Size = new System.Drawing.Size(300, 300);
			this.ChartBlock.TabIndex = 0;
			this.ChartBlock.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.ChartBlock.VerticalScrollbarBarColor = true;
			this.ChartBlock.VerticalScrollbarHighlightOnWheel = false;
			this.ChartBlock.VerticalScrollbarSize = 10;
			// 
			// BlockTable
			// 
			this.BlockTable.ColumnCount = 1;
			this.BlockTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.BlockTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.BlockTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BlockTable.Location = new System.Drawing.Point(0, 0);
			this.BlockTable.Name = "BlockTable";
			this.BlockTable.RowCount = 2;
			this.BlockTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.BlockTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.BlockTable.Size = new System.Drawing.Size(300, 300);
			this.BlockTable.TabIndex = 0;
			this.ChartBlock.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroPanel ChartBlock;
		private System.Windows.Forms.TableLayoutPanel BlockTable;
	}
}
