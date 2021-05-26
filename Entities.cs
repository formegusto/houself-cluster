using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using houself_cluster.Common;

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

		public Data(DateTime d, string u, double[] ts)
		{
			this.date = d;
			this.uid = u;
			this.timeslot = ts;
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
}
