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
		public string keyword { get; set; }
		public Day day { get; set; }
		public Season season { get; set; }

		public string ToString()
		{
			return string.Format(
				"-----Option Info-----\n" +
				"KEYWORD : {0}\n" +
				"DAY : {1}\n" +
				"SEASON : {2}\n" +
				"---------------------\n",
				keyword == "" ? "[Empty]" : keyword, day, season);
		}
	}
}
