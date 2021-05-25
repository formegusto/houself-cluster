using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using houself_cluster.Common;

namespace houself_cluster
{
	public partial class Component : MetroFramework.Forms.MetroForm, IView, IModelObserver
	{
		public event ViewHandler<IView> changed;
		public IController controller;
		public void SetController(IController controller)
		{
			this.controller = controller;
		}
		public void ModelNotify(IModel model, ModelEventArgs e)
		{
			Console.WriteLine(string.Format("[Model -> View] {0}", e.action));
			switch(e.action)
			{
				case MODEL_ACTION.READ_FILE_SUCCESS:
					this.Invoke((System.Action)(() => this.LoadingTitle.Text = "셀을 읽는 중 입니다."));
					
					break;
				case MODEL_ACTION.INIT_EXCEL_LOAD_SUCCESS:
					this.Invoke((System.Action)(() => Body_Allocate()));

					break;
				case MODEL_ACTION.SEARCH_KEYWORD_FIND:
					Console.WriteLine("찾음");
					this.controller.Dispatch(MODEL_ACTION.REQUEST_DATAS);

					break;
				case MODEL_ACTION.SEARCH_KEYWORD_NOTFOUND:
					Console.WriteLine("못 찾음");

					break;
				case MODEL_ACTION.REQUEST_DATAS_SUCCESS:
					Console.WriteLine("초기 데이터 구성 완료");
					this.controller.Dispatch(MODEL_ACTION.DATA_PREPROCESSING);

					break;
				default:
					return;
			}
		}
		public Component()
		{
			InitializeComponent();
		}
		public void Body_Allocate()
		{
			//
			// Loading Component Disallocate
			//
			this.Controls.Remove(this.LoadingComponent);

			//
			// Body Contents Allocate
			//
			this.Controls.Add(this.Body);
			this.Controls.Add(this.SideBar);
		}

		public void ClusteringBtn_Click(object sender, EventArgs e) => this.changed(
			this, new ViewEventArgs(
				VIEW_ACTION.START_CLUSTERING));

		public void Component_Shown(object sender, EventArgs e) => this.changed(
			this, new ViewEventArgs(
				VIEW_ACTION.INIT_EXCEL_LOAD));
		private void DayTabs_Selected(object sender, TabControlEventArgs e) => this.changed(
			this, new ViewEventArgs(
				VIEW_ACTION.CHANGE_DAYS,
				new Dictionary<string, dynamic>() { { "tabPageIdx", e.TabPageIndex } }));
		private void SeasonTabs_Selected(object sender, TabControlEventArgs e) => this.changed(
			this, new ViewEventArgs(
				VIEW_ACTION.CHANGE_SEASONS,
				new Dictionary<string, dynamic>() { { "tabPageIdx", e.TabPageIndex } }));
		private void Keyword_Changed(object sender, EventArgs e) => this.changed(
			this, new ViewEventArgs(
				VIEW_ACTION.CHANGE_KEYWORD,
				new Dictionary<string, dynamic>() { { "keyword", this.KeywordBox.Text } }));
	}
}
