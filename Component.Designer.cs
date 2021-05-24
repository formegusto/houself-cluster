﻿namespace houself_cluster
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
			this.SeasonComponent = new MetroFramework.Controls.MetroPanel();
			this.SeasonTabs = new MetroFramework.Controls.MetroTabControl();
			this.All = new MetroFramework.Controls.MetroTabPage();
			this.Spring = new MetroFramework.Controls.MetroTabPage();
			this.Summer = new MetroFramework.Controls.MetroTabPage();
			this.Autumn = new MetroFramework.Controls.MetroTabPage();
			this.Winter = new MetroFramework.Controls.MetroTabPage();
			this.DayComponent = new MetroFramework.Controls.MetroPanel();
			this.DayTabs = new MetroFramework.Controls.MetroTabControl();
			this.Sun = new MetroFramework.Controls.MetroTabPage();
			this.Mon = new MetroFramework.Controls.MetroTabPage();
			this.Tue = new MetroFramework.Controls.MetroTabPage();
			this.Wed = new MetroFramework.Controls.MetroTabPage();
			this.Thu = new MetroFramework.Controls.MetroTabPage();
			this.Fri = new MetroFramework.Controls.MetroTabPage();
			this.Sat = new MetroFramework.Controls.MetroTabPage();
			this.Body = new MetroFramework.Controls.MetroPanel();
			this.SideBar = new MetroFramework.Controls.MetroPanel();
			this.ClusteringBtn = new MetroFramework.Controls.MetroButton();
			this.KeywordBox = new MetroFramework.Controls.MetroTextBox();
			this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
			this.LoadingTitle = new MetroFramework.Controls.MetroLabel();
			this.LoadingComponent = new MetroFramework.Controls.MetroPanel();
			this.Header.SuspendLayout();
			this.SeasonComponent.SuspendLayout();
			this.SeasonTabs.SuspendLayout();
			this.DayComponent.SuspendLayout();
			this.DayTabs.SuspendLayout();
			this.SideBar.SuspendLayout();
			this.LoadingComponent.SuspendLayout();
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
			// SeasonComponent
			// 
			this.SeasonComponent.Controls.Add(this.SeasonTabs);
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
			// SeasonTabs
			// 
			this.SeasonTabs.Controls.Add(this.All);
			this.SeasonTabs.Controls.Add(this.Spring);
			this.SeasonTabs.Controls.Add(this.Summer);
			this.SeasonTabs.Controls.Add(this.Autumn);
			this.SeasonTabs.Controls.Add(this.Winter);
			this.SeasonTabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SeasonTabs.Location = new System.Drawing.Point(0, 0);
			this.SeasonTabs.Name = "SeasonTabs";
			this.SeasonTabs.SelectedIndex = 0;
			this.SeasonTabs.Size = new System.Drawing.Size(1234, 50);
			this.SeasonTabs.TabIndex = 2;
			this.SeasonTabs.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.SeasonTabs.UseSelectable = true;
			this.SeasonTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.SeasonTabs_Selected);
			// 
			// All
			// 
			this.All.HorizontalScrollbarBarColor = true;
			this.All.HorizontalScrollbarHighlightOnWheel = false;
			this.All.HorizontalScrollbarSize = 10;
			this.All.Location = new System.Drawing.Point(4, 38);
			this.All.Name = "All";
			this.All.Size = new System.Drawing.Size(1226, 8);
			this.All.TabIndex = 0;
			this.All.Text = "All";
			this.All.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.All.VerticalScrollbarBarColor = true;
			this.All.VerticalScrollbarHighlightOnWheel = false;
			this.All.VerticalScrollbarSize = 10;
			// 
			// Spring
			// 
			this.Spring.HorizontalScrollbarBarColor = true;
			this.Spring.HorizontalScrollbarHighlightOnWheel = false;
			this.Spring.HorizontalScrollbarSize = 10;
			this.Spring.Location = new System.Drawing.Point(4, 38);
			this.Spring.Name = "Spring";
			this.Spring.Size = new System.Drawing.Size(1226, 8);
			this.Spring.TabIndex = 1;
			this.Spring.Text = "Spring";
			this.Spring.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Spring.VerticalScrollbarBarColor = true;
			this.Spring.VerticalScrollbarHighlightOnWheel = false;
			this.Spring.VerticalScrollbarSize = 10;
			// 
			// Summer
			// 
			this.Summer.HorizontalScrollbarBarColor = true;
			this.Summer.HorizontalScrollbarHighlightOnWheel = false;
			this.Summer.HorizontalScrollbarSize = 10;
			this.Summer.Location = new System.Drawing.Point(4, 38);
			this.Summer.Name = "Summer";
			this.Summer.Size = new System.Drawing.Size(1226, 8);
			this.Summer.TabIndex = 2;
			this.Summer.Text = "Summer";
			this.Summer.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Summer.VerticalScrollbarBarColor = true;
			this.Summer.VerticalScrollbarHighlightOnWheel = false;
			this.Summer.VerticalScrollbarSize = 10;
			// 
			// Autumn
			// 
			this.Autumn.HorizontalScrollbarBarColor = true;
			this.Autumn.HorizontalScrollbarHighlightOnWheel = false;
			this.Autumn.HorizontalScrollbarSize = 10;
			this.Autumn.Location = new System.Drawing.Point(4, 38);
			this.Autumn.Name = "Autumn";
			this.Autumn.Size = new System.Drawing.Size(1226, 8);
			this.Autumn.TabIndex = 3;
			this.Autumn.Text = "Autumn";
			this.Autumn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Autumn.VerticalScrollbarBarColor = true;
			this.Autumn.VerticalScrollbarHighlightOnWheel = false;
			this.Autumn.VerticalScrollbarSize = 10;
			// 
			// Winter
			// 
			this.Winter.HorizontalScrollbarBarColor = true;
			this.Winter.HorizontalScrollbarHighlightOnWheel = false;
			this.Winter.HorizontalScrollbarSize = 10;
			this.Winter.Location = new System.Drawing.Point(4, 38);
			this.Winter.Name = "Winter";
			this.Winter.Size = new System.Drawing.Size(1226, 8);
			this.Winter.TabIndex = 4;
			this.Winter.Text = "Winter";
			this.Winter.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Winter.VerticalScrollbarBarColor = true;
			this.Winter.VerticalScrollbarHighlightOnWheel = false;
			this.Winter.VerticalScrollbarSize = 10;
			// 
			// DayComponent
			// 
			this.DayComponent.Controls.Add(this.DayTabs);
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
			// DayTabs
			// 
			this.DayTabs.Controls.Add(this.Sun);
			this.DayTabs.Controls.Add(this.Mon);
			this.DayTabs.Controls.Add(this.Tue);
			this.DayTabs.Controls.Add(this.Wed);
			this.DayTabs.Controls.Add(this.Thu);
			this.DayTabs.Controls.Add(this.Fri);
			this.DayTabs.Controls.Add(this.Sat);
			this.DayTabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DayTabs.Location = new System.Drawing.Point(0, 0);
			this.DayTabs.Name = "DayTabs";
			this.DayTabs.SelectedIndex = 0;
			this.DayTabs.Size = new System.Drawing.Size(1234, 50);
			this.DayTabs.TabIndex = 2;
			this.DayTabs.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.DayTabs.UseSelectable = true;
			this.DayTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.DayTabs_Selected);
			// 
			// Sun
			// 
			this.Sun.HorizontalScrollbarBarColor = true;
			this.Sun.HorizontalScrollbarHighlightOnWheel = false;
			this.Sun.HorizontalScrollbarSize = 10;
			this.Sun.Location = new System.Drawing.Point(4, 38);
			this.Sun.Name = "Sun";
			this.Sun.Size = new System.Drawing.Size(1226, 8);
			this.Sun.Style = MetroFramework.MetroColorStyle.Orange;
			this.Sun.TabIndex = 0;
			this.Sun.Text = "Sun";
			this.Sun.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Sun.VerticalScrollbarBarColor = true;
			this.Sun.VerticalScrollbarHighlightOnWheel = false;
			this.Sun.VerticalScrollbarSize = 10;
			// 
			// Mon
			// 
			this.Mon.HorizontalScrollbarBarColor = true;
			this.Mon.HorizontalScrollbarHighlightOnWheel = false;
			this.Mon.HorizontalScrollbarSize = 10;
			this.Mon.Location = new System.Drawing.Point(4, 38);
			this.Mon.Name = "Mon";
			this.Mon.Size = new System.Drawing.Size(1226, 8);
			this.Mon.TabIndex = 1;
			this.Mon.Text = "Mon";
			this.Mon.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Mon.VerticalScrollbarBarColor = true;
			this.Mon.VerticalScrollbarHighlightOnWheel = false;
			this.Mon.VerticalScrollbarSize = 10;
			// 
			// Tue
			// 
			this.Tue.HorizontalScrollbarBarColor = true;
			this.Tue.HorizontalScrollbarHighlightOnWheel = false;
			this.Tue.HorizontalScrollbarSize = 10;
			this.Tue.Location = new System.Drawing.Point(4, 38);
			this.Tue.Name = "Tue";
			this.Tue.Size = new System.Drawing.Size(1226, 8);
			this.Tue.TabIndex = 2;
			this.Tue.Text = "Tue";
			this.Tue.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Tue.VerticalScrollbarBarColor = true;
			this.Tue.VerticalScrollbarHighlightOnWheel = false;
			this.Tue.VerticalScrollbarSize = 10;
			// 
			// Wed
			// 
			this.Wed.HorizontalScrollbarBarColor = true;
			this.Wed.HorizontalScrollbarHighlightOnWheel = false;
			this.Wed.HorizontalScrollbarSize = 10;
			this.Wed.Location = new System.Drawing.Point(4, 38);
			this.Wed.Name = "Wed";
			this.Wed.Size = new System.Drawing.Size(1226, 8);
			this.Wed.TabIndex = 3;
			this.Wed.Text = "Wed";
			this.Wed.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Wed.VerticalScrollbarBarColor = true;
			this.Wed.VerticalScrollbarHighlightOnWheel = false;
			this.Wed.VerticalScrollbarSize = 10;
			// 
			// Thu
			// 
			this.Thu.HorizontalScrollbarBarColor = true;
			this.Thu.HorizontalScrollbarHighlightOnWheel = false;
			this.Thu.HorizontalScrollbarSize = 10;
			this.Thu.Location = new System.Drawing.Point(4, 38);
			this.Thu.Name = "Thu";
			this.Thu.Size = new System.Drawing.Size(1226, 8);
			this.Thu.TabIndex = 4;
			this.Thu.Text = "Thu";
			this.Thu.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Thu.VerticalScrollbarBarColor = true;
			this.Thu.VerticalScrollbarHighlightOnWheel = false;
			this.Thu.VerticalScrollbarSize = 10;
			// 
			// Fri
			// 
			this.Fri.HorizontalScrollbarBarColor = true;
			this.Fri.HorizontalScrollbarHighlightOnWheel = false;
			this.Fri.HorizontalScrollbarSize = 10;
			this.Fri.Location = new System.Drawing.Point(4, 38);
			this.Fri.Name = "Fri";
			this.Fri.Size = new System.Drawing.Size(1226, 8);
			this.Fri.TabIndex = 5;
			this.Fri.Text = "Fri";
			this.Fri.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Fri.VerticalScrollbarBarColor = true;
			this.Fri.VerticalScrollbarHighlightOnWheel = false;
			this.Fri.VerticalScrollbarSize = 10;
			// 
			// Sat
			// 
			this.Sat.HorizontalScrollbarBarColor = true;
			this.Sat.HorizontalScrollbarHighlightOnWheel = false;
			this.Sat.HorizontalScrollbarSize = 10;
			this.Sat.Location = new System.Drawing.Point(4, 38);
			this.Sat.Name = "Sat";
			this.Sat.Size = new System.Drawing.Size(1226, 8);
			this.Sat.TabIndex = 6;
			this.Sat.Text = "Sat";
			this.Sat.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Sat.VerticalScrollbarBarColor = true;
			this.Sat.VerticalScrollbarHighlightOnWheel = false;
			this.Sat.VerticalScrollbarSize = 10;
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
			this.SideBar.Controls.Add(this.ClusteringBtn);
			this.SideBar.Controls.Add(this.KeywordBox);
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
			// ClusteringBtn
			// 
			this.ClusteringBtn.Dock = System.Windows.Forms.DockStyle.Top;
			this.ClusteringBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.ClusteringBtn.Location = new System.Drawing.Point(0, 40);
			this.ClusteringBtn.Name = "ClusteringBtn";
			this.ClusteringBtn.Size = new System.Drawing.Size(428, 40);
			this.ClusteringBtn.TabIndex = 3;
			this.ClusteringBtn.Text = "Clustering";
			this.ClusteringBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.ClusteringBtn.UseSelectable = true;
			this.ClusteringBtn.Click += new System.EventHandler(this.ClusteringBtn_Click);
			// 
			// KeywordBox
			// 
			// 
			// 
			// 
			this.KeywordBox.CustomButton.Image = null;
			this.KeywordBox.CustomButton.Location = new System.Drawing.Point(390, 2);
			this.KeywordBox.CustomButton.Name = "";
			this.KeywordBox.CustomButton.Size = new System.Drawing.Size(35, 35);
			this.KeywordBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.KeywordBox.CustomButton.TabIndex = 1;
			this.KeywordBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.KeywordBox.CustomButton.UseSelectable = true;
			this.KeywordBox.CustomButton.Visible = false;
			this.KeywordBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.KeywordBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
			this.KeywordBox.Lines = new string[0];
			this.KeywordBox.Location = new System.Drawing.Point(0, 0);
			this.KeywordBox.MaxLength = 32767;
			this.KeywordBox.Name = "KeywordBox";
			this.KeywordBox.PasswordChar = '\0';
			this.KeywordBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.KeywordBox.SelectedText = "";
			this.KeywordBox.SelectionLength = 0;
			this.KeywordBox.SelectionStart = 0;
			this.KeywordBox.ShortcutsEnabled = true;
			this.KeywordBox.Size = new System.Drawing.Size(428, 40);
			this.KeywordBox.TabIndex = 2;
			this.KeywordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.KeywordBox.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.KeywordBox.UseSelectable = true;
			this.KeywordBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.KeywordBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.KeywordBox.TextChanged += new System.EventHandler(this.Keyword_Changed);
			// 
			// metroProgressSpinner1
			// 
			this.metroProgressSpinner1.Location = new System.Drawing.Point(498, 129);
			this.metroProgressSpinner1.Maximum = 100;
			this.metroProgressSpinner1.Name = "metroProgressSpinner1";
			this.metroProgressSpinner1.Size = new System.Drawing.Size(250, 250);
			this.metroProgressSpinner1.TabIndex = 2;
			this.metroProgressSpinner1.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.metroProgressSpinner1.UseSelectable = true;
			// 
			// LoadingTitle
			// 
			this.LoadingTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.LoadingTitle.AutoSize = true;
			this.LoadingTitle.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.LoadingTitle.Location = new System.Drawing.Point(509, 396);
			this.LoadingTitle.Name = "LoadingTitle";
			this.LoadingTitle.Size = new System.Drawing.Size(229, 25);
			this.LoadingTitle.TabIndex = 3;
			this.LoadingTitle.Text = "파일을 불러오는 중 입니다.";
			this.LoadingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.LoadingTitle.Theme = MetroFramework.MetroThemeStyle.Dark;
			// 
			// LoadingComponent
			// 
			this.LoadingComponent.Controls.Add(this.LoadingTitle);
			this.LoadingComponent.Controls.Add(this.metroProgressSpinner1);
			this.LoadingComponent.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.LoadingComponent.HorizontalScrollbarBarColor = true;
			this.LoadingComponent.HorizontalScrollbarHighlightOnWheel = false;
			this.LoadingComponent.HorizontalScrollbarSize = 10;
			this.LoadingComponent.Location = new System.Drawing.Point(23, 189);
			this.LoadingComponent.Name = "LoadingComponent";
			this.LoadingComponent.Size = new System.Drawing.Size(1234, 508);
			this.LoadingComponent.TabIndex = 1;
			this.LoadingComponent.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.LoadingComponent.VerticalScrollbarBarColor = true;
			this.LoadingComponent.VerticalScrollbarHighlightOnWheel = false;
			this.LoadingComponent.VerticalScrollbarSize = 10;
			// 
			// Component
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1280, 720);
			this.Controls.Add(this.LoadingComponent);
			// this.Controls.Add(this.SideBar);
			// this.Controls.Add(this.Body);
			this.Controls.Add(this.Header);
			this.Name = "Component";
			this.Resizable = false;
			this.Text = "Houself-Cluster";
			this.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.Shown += new System.EventHandler(this.Component_Shown);
			this.Header.ResumeLayout(false);
			this.SeasonComponent.ResumeLayout(false);
			this.SeasonTabs.ResumeLayout(false);
			this.DayComponent.ResumeLayout(false);
			this.DayTabs.ResumeLayout(false);
			this.SideBar.ResumeLayout(false);
			this.LoadingComponent.ResumeLayout(false);
			this.LoadingComponent.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroPanel Header;
		private MetroFramework.Controls.MetroPanel Body;
		private MetroFramework.Controls.MetroPanel SideBar;
		private MetroFramework.Controls.MetroPanel DayComponent;
		private MetroFramework.Controls.MetroPanel SeasonComponent;
		private MetroFramework.Controls.MetroTabControl DayTabs;
		private MetroFramework.Controls.MetroTabControl SeasonTabs;
		private MetroFramework.Controls.MetroTabPage Sun;
		private MetroFramework.Controls.MetroTabPage Mon;
		private MetroFramework.Controls.MetroTabPage Tue;
		private MetroFramework.Controls.MetroTabPage Wed;
		private MetroFramework.Controls.MetroTabPage Thu;
		private MetroFramework.Controls.MetroTabPage Fri;
		private MetroFramework.Controls.MetroTabPage Sat;
		private MetroFramework.Controls.MetroTabPage All;
		private MetroFramework.Controls.MetroTabPage Spring;
		private MetroFramework.Controls.MetroTabPage Summer;
		private MetroFramework.Controls.MetroTabPage Autumn;
		private MetroFramework.Controls.MetroTabPage Winter;
		private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
		private MetroFramework.Controls.MetroLabel LoadingTitle;
		private MetroFramework.Controls.MetroPanel LoadingComponent;
		private MetroFramework.Controls.MetroTextBox KeywordBox;
		private MetroFramework.Controls.MetroButton ClusteringBtn;
	}
}

