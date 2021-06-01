using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

using houself_cluster.Common;
using houself_cluster.Atom;

namespace houself_cluster
{
	public partial class Component : MetroFramework.Forms.MetroForm, IView, IModelObserver
	{
		public event ViewHandler<IView> changed;
		public IController controller;
		List<LiveCharts.WinForms.CartesianChart> chartList;

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
				case MODEL_ACTION.DATA_PREPROCESSING_SUCCESS:
					Console.WriteLine("데이터 전처리 완료");
					this.controller.Dispatch(MODEL_ACTION.SET_CLUSTER);

					break;
				case MODEL_ACTION.SET_CLUSTER_SUCCESS:
					Console.WriteLine("초기 클러스터 구성 완료");
					Chart_Allocate(e.payload["clusters"], e.payload["K"]);
					Delay(3000);
					Task.Run(() =>
					{
						this.controller.Dispatch(MODEL_ACTION.ASSIGN_INSTANCE);
					});
					
					break;
				case MODEL_ACTION.ASSIGN_INSTANCE_SUCCESS:
					// Console.WriteLine("{0} 데이터는 {1} 클러스터에 할당", (Data)e.payload["data"], e.payload["cluster"]);
					Line_Allocate(e.payload["data"], e.payload["cluster"]);

					break;
				case MODEL_ACTION.ASSIGN_ALL_INSTANCE_SUCCESS:
					this.Invoke((System.Action)(() =>
				   {
					   this.SideBar.Controls.Clear();
					   Cluster_Line_Allocate(e.payload["clusters"], e.payload["K"]);

					   this.SideBar.Controls.Add(this.NextClusteringBtn);
					   this.SideBar.Controls.Add(this.ClusteringBtn);
					   this.SideBar.Controls.Add(this.KeywordBox);
				   }));

					break;
				case MODEL_ACTION.RECLUSTER_SUCCESS:
					this.Line_Reset(e.payload["clusters"], e.payload["K"]);
					Delay(3000);
					Task.Run(() =>
					{
						this.controller.Dispatch(MODEL_ACTION.ASSIGN_INSTANCE);
					});

					break;
				default:
					return;
			}
		}
		private static DateTime Delay(int MS)
		{
			DateTime ThisMoment = DateTime.Now;
			TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
			DateTime AfterWards = ThisMoment.Add(duration);

			while (AfterWards >= ThisMoment)
			{
				System.Windows.Forms.Application.DoEvents();
				ThisMoment = DateTime.Now;
			}

			return DateTime.Now;
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
		public void Line_Reset(List<Cluster> clusters, int K)
		{
			for (int c = 0; c < K; c++)
			{
				this.Invoke((System.Action)(() =>
				{
					this.chartList[c].Series.Clear();
				}));
			}
		}
		public void Line_Allocate(Data data, int K)
		{
			this.Invoke((System.Action)(() =>
		   {
			   Console.WriteLine(string.Format("{0} --- Distance : {1}", data.date.ToString("yyyyMMdd"), data.distance));
			   ChartValues<ObservablePoint> cv = new ChartValues<ObservablePoint>();
			   for (int t = 0; t < data.timeslot.Length; t++)
				   cv.Add(new ObservablePoint(t * (24 / data.timeslot.Length), data.timeslot[t]));
			   

			   LineSeries ls = new LineSeries
			   {
				   Title = string.Format("{0}", data.date.ToString("yyyyMMdd")),
				   Stroke = Brushes.Red,
				   Values = cv,
				   StrokeThickness = 1,
			   };
			   Task.Run(() =>
			   {
				   this.chartList[K].Series.Add(ls);
			   });
			   
		   }));
		}
		public void Cluster_Line_Allocate(List<Cluster> clusters, int K)
		{
			for (int c = 0; c < K; c++)
			{
				this.Invoke((System.Action)(() =>
				{
					ChartValues<ObservablePoint> cv = new ChartValues<ObservablePoint>();
					for (int t = 0; t < clusters[c].timeslot.Length; t++)
						cv.Add(new ObservablePoint(t * (24 / clusters[c].timeslot.Length), clusters[c].timeslot[t]));

					LineSeries ls = new LineSeries
					{
						Title = string.Format("{0}", clusters[c].uid),
						Stroke = Brushes.Blue,
						Values = cv,
						StrokeThickness = 4,
					};
					this.chartList[c].Series.Add(ls);
				}));
			}
		}

		public void Chart_Allocate(List<Cluster> clusters, int K)
		{
			this.chartList = new List<LiveCharts.WinForms.CartesianChart>();

			for (int c = 0; c < K; c++)
			{
				this.Invoke((System.Action)(() =>
				{
					LiveCharts.WinForms.CartesianChart chart = new LiveCharts.WinForms.CartesianChart();
					chartList.Add(chart);
					chart.Dock = System.Windows.Forms.DockStyle.Fill;

					MetroFramework.Controls.MetroLabel title = new MetroFramework.Controls.MetroLabel();
					title.Text = string.Format("title - {0}", c);
					this.ChartTable.Controls.Add(new ChartPanel(), c % 3, c / 3);
				}));
			}
		}

		public void Chart_Clear()
		{
			this.chartList.ForEach((chart) =>
			{
				this.ChartTable.Controls.Remove(chart);
				chart.Dispose();
			});

			this.chartList = null;
			Delay(3000);
		}
		public void ClusteringBtn_Click(object sender, EventArgs e) {
			if(this.chartList != null)
			{
				Chart_Clear();
			}
			this.changed(
			this, new ViewEventArgs(
				VIEW_ACTION.START_CLUSTERING));
		}
		public void ReClusteringBtn_Click(object sender, EventArgs e) => this.changed(
			this, new ViewEventArgs(
				VIEW_ACTION.RECLUSTER));
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
		private void TimeslotTabs_Selected(object sender, TabControlEventArgs e) => this.changed(
			this, new ViewEventArgs(
				VIEW_ACTION.CHANGE_TIMESLOT,
				new Dictionary<string, dynamic>() { { "tabPageIdx", e.TabPageIndex } }));
		private void Keyword_Changed(object sender, EventArgs e) => this.changed(
			this, new ViewEventArgs(
				VIEW_ACTION.CHANGE_KEYWORD,
				new Dictionary<string, dynamic>() { { "keyword", this.KeywordBox.Text } }));
	}
}
