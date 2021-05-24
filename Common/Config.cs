using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace houself_cluster.Common
{
	public class LOAD_EXCEL_CONFIG
	{
		public static int USER = 0;
		public static int TIMESLOT = 96;
		public static int STARTROW = 6;
		public static int STARTCOLUMN = 8;
		public static string ToString()
		{
			return string.Format("-----Config Info-----\n" +
				"USER : {0}\n" +
				"TIMESLOT : {1}\n" +
				"STARTROW : {2}\n" +
				"STARTCOLUMN : {3}\n",
				USER, TIMESLOT, STARTROW, STARTCOLUMN);
		}
	}
}
