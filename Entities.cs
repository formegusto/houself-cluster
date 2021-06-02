using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using houself_cluster.Common;
using houself_cluster.Utils;

namespace houself_cluster
{
	public class ClusterOptions
	{
		public int K;
		public int searchCol;
		public string keyword { get; set; }
		public Day day { get; set; }
		public Season season { get; set; }

		public Timeslot timeslot { get; set; }

		public string ToString()
		{
			return string.Format(
				"-----Option Info-----\n" +
				"K : {0} \n" +
				"SEARCH_COL : {1}\n" +
				"KEYWORD : {2}\n" +
				"DAY : {3}\n" +
				"SEASON : {4}\n" +
				"TIMESLOT : {5}\n" +
				"---------------------\n",
				K, searchCol,
				keyword == "" ? "[Empty]" : keyword, day, season, timeslot);
		}
	}

	public class Data
	{
		public DateTime date;
		public string uid;
		public double[] timeslot;
		public int mainCluster;
		public int subCluster;
		public double distance;

		public Data(DateTime d, string u, double[] ts)
		{
			this.date = d;
			this.uid = u;
			this.timeslot = ts;
			this.distance = Math.Sqrt(double.MaxValue);
		}

		public void ToPrint()
		{
			Console.WriteLine(string.Format("Date : {0}\n" +
				"UID : {1}", this.date.ToString("yyyyMMdd"), this.uid));
			for(int t = 0; t < this.timeslot.Length; t++)
			{
				Console.WriteLine(this.timeslot[t] + " ");
				if ((t != 0) && ((t % 8) == 0))
					Console.WriteLine();
			}
		}

		public bool CompareTS(Data cts)
		{
			for(int t = 0; t < this.timeslot.Length; t++)
			{
				if (cts.timeslot[t] != this.timeslot[t])
					return false;
			}
			return true;
		}
	}

	public class Cluster : Data
	{
		public List<Data> instances;
		public Dictionary<Season, int> seasonFrequency;
		public Cluster(DateTime d, string u, double[] ts) : base(d, u, ts)
		{
			this.instances = new List<Data>();
			this.seasonFrequency = new Dictionary<Season, int>();
			this.seasonFrequency.Add(Season.SPRING, 0);
			this.seasonFrequency.Add(Season.SUMMER, 0);
			this.seasonFrequency.Add(Season.AUTUMN, 0);
			this.seasonFrequency.Add(Season.WINTER, 0);
		}

		public void initSeasonFrequeny()
		{
			this.seasonFrequency[Season.SPRING] = 0;
			this.seasonFrequency[Season.SUMMER] = 0;
			this.seasonFrequency[Season.AUTUMN] = 0;
			this.seasonFrequency[Season.WINTER] = 0;
		}

		public string SeasonStatistic()
		{
			string mainSeason = "";
			string subSeason = "";

			int main = -1;
			int sub = -1;
			foreach (KeyValuePair<Season, int> items in this.seasonFrequency)
			{
				if(main < this.seasonFrequency[items.Key])
				{
					sub = main;
					main = this.seasonFrequency[items.Key];

					mainSeason = string.Format("{0}:{1}", SeasonUtils.SeasonToKR(items.Key), main);
					subSeason = mainSeason;
				}
				else
				{
					if(sub < this.seasonFrequency[items.Key])
					{
						sub = this.seasonFrequency[items.Key];
						subSeason = string.Format("{0}:{1}", SeasonUtils.SeasonToKR(items.Key), sub);
					}
				}
			}

			return string.Format("{0} {1}", mainSeason, subSeason);
		}
	}

	public class SeasonFrequency: IComparable
	{
		public Season season;
		public int frequency;

		public SeasonFrequency(int idx)
		{
			this.season = (Season)idx;
			this.frequency = 0;
		}

		public int CompareTo(object obj)
		{
			if (obj is SeasonFrequency)
				return ((obj as SeasonFrequency).frequency).CompareTo(this.frequency);
			throw new ArgumentException("Object is not a SeasonFrequency");
		}
	}
}
