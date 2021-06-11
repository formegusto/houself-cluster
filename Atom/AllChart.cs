using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace houself_cluster.Atom
{
	public partial class AllChart : MetroFramework.Forms.MetroForm
	{
		public AllChart(List<Data> datas, List<Cluster> clusters,System.Windows.Media.Brush brush)
		{
			InitializeComponent();

			datas.ForEach((data) =>
			{
				ChartValues<ObservablePoint> cv = new ChartValues<ObservablePoint>();
				for (int t = 0; t < data.timeslot.Length; t++)
					cv.Add(new ObservablePoint(t * (24 / data.timeslot.Length), data.timeslot[t]));

				LineSeries ls = new LineSeries
				{
					Title = string.Format("{0}", data.uid),
					Stroke = brush,
					Values = cv,
					StrokeThickness = 1,
					PointGeometry = null,
					Fill = System.Windows.Media.Brushes.Transparent
				};

				this.Chart.Series.Add(ls);
			});

			clusters.ForEach((cluster) =>
			{
				ChartValues<ObservablePoint> cv = new ChartValues<ObservablePoint>();
				for (int t = 0; t < cluster.timeslot.Length; t++)
					cv.Add(new ObservablePoint(t * (24 / cluster.timeslot.Length), cluster.timeslot[t]));

				LineSeries ls = new LineSeries
				{
					Title = string.Format("{0}", cluster.uid),
					Stroke = System.Windows.Media.Brushes.AliceBlue,
					Values = cv,
					StrokeThickness = 4,
					PointGeometry = null,
				};

				this.Chart.Series.Add(ls);
			});
		}
	}
}
