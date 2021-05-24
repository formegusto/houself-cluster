namespace houself_cluster
{
	partial class Component
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

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.Header = new MetroFramework.Controls.MetroPanel();
			this.Body = new MetroFramework.Controls.MetroPanel();
			this.SideBar = new MetroFramework.Controls.MetroPanel();
			this.DayComponent = new MetroFramework.Controls.MetroPanel();
			this.SeasonComponent = new MetroFramework.Controls.MetroPanel();
			this.Header.SuspendLayout();
			this.SuspendLayout();
			// 
			// Header
			// 
			this.Header.Controls.Add(this.SeasonComponent);
			this.Header.Controls.Add(this.DayComponent);
			this.Header.HorizontalScrollbarBarColor = true;
			this.Header.HorizontalScrollbarHighlightOnWheel = false;
			this.Header.HorizontalScrollbarSize = 10;
			this.Header.Location = new System.Drawing.Point(23, 63);
			this.Header.Name = "Header";
			this.Header.Size = new System.Drawing.Size(1234, 120);
			this.Header.TabIndex = 0;
			this.Header.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Header.VerticalScrollbarBarColor = true;
			this.Header.VerticalScrollbarHighlightOnWheel = false;
			this.Header.VerticalScrollbarSize = 10;
			// 
			// Body
			// 
			this.Body.HorizontalScrollbarBarColor = true;
			this.Body.HorizontalScrollbarHighlightOnWheel = false;
			this.Body.HorizontalScrollbarSize = 10;
			this.Body.Location = new System.Drawing.Point(23, 189);
			this.Body.Name = "Body";
			this.Body.Size = new System.Drawing.Size(800, 508);
			this.Body.TabIndex = 2;
			this.Body.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Body.VerticalScrollbarBarColor = true;
			this.Body.VerticalScrollbarHighlightOnWheel = false;
			this.Body.VerticalScrollbarSize = 10;
			// 
			// SideBar
			// 
			this.SideBar.HorizontalScrollbarBarColor = true;
			this.SideBar.HorizontalScrollbarHighlightOnWheel = false;
			this.SideBar.HorizontalScrollbarSize = 10;
			this.SideBar.Location = new System.Drawing.Point(829, 189);
			this.SideBar.Name = "SideBar";
			this.SideBar.Size = new System.Drawing.Size(428, 508);
			this.SideBar.TabIndex = 2;
			this.SideBar.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.SideBar.VerticalScrollbarBarColor = true;
			this.SideBar.VerticalScrollbarHighlightOnWheel = false;
			this.SideBar.VerticalScrollbarSize = 10;
			// 
			// DayComponent
			// 
			this.DayComponent.HorizontalScrollbarBarColor = true;
			this.DayComponent.HorizontalScrollbarHighlightOnWheel = false;
			this.DayComponent.HorizontalScrollbarSize = 10;
			this.DayComponent.Location = new System.Drawing.Point(0, 0);
			this.DayComponent.Name = "DayComponent";
			this.DayComponent.Size = new System.Drawing.Size(1234, 50);
			this.DayComponent.TabIndex = 2;
			this.DayComponent.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.DayComponent.VerticalScrollbarBarColor = true;
			this.DayComponent.VerticalScrollbarHighlightOnWheel = false;
			this.DayComponent.VerticalScrollbarSize = 10;
			// 
			// SeasonComponent
			// 
			this.SeasonComponent.HorizontalScrollbarBarColor = true;
			this.SeasonComponent.HorizontalScrollbarHighlightOnWheel = false;
			this.SeasonComponent.HorizontalScrollbarSize = 10;
			this.SeasonComponent.Location = new System.Drawing.Point(0, 66);
			this.SeasonComponent.Name = "SeasonComponent";
			this.SeasonComponent.Size = new System.Drawing.Size(1234, 50);
			this.SeasonComponent.TabIndex = 2;
			this.SeasonComponent.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.SeasonComponent.VerticalScrollbarBarColor = true;
			this.SeasonComponent.VerticalScrollbarHighlightOnWheel = false;
			this.SeasonComponent.VerticalScrollbarSize = 10;
			// 
			// Component
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1280, 720);
			this.Controls.Add(this.SideBar);
			this.Controls.Add(this.Body);
			this.Controls.Add(this.Header);
			this.Name = "Component";
			this.Resizable = false;
			this.Text = "Houself-Cluster";
			this.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Header.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroPanel Header;
		private MetroFramework.Controls.MetroPanel Body;
		private MetroFramework.Controls.MetroPanel SideBar;
		private MetroFramework.Controls.MetroPanel DayComponent;
		private MetroFramework.Controls.MetroPanel SeasonComponent;
	}
}

