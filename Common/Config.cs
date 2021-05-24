using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace houself_cluster.Common
{
	public class LOAD_EXCEL_CONFIG
	{
		public static int ROW, COLUMN, USER;
		public static int TIMESLOT = 96;
		public static int STARTROW = 6;
		public static int STARTCOLUMN = 8;
		public static string ToString()
		{
			return string.Format(
				"-----Excel Info-----\n" +
				"ROW : {0}\n" +
				"COLUMN : {1}\n" +
				"-----Config Info-----\n" +
				"USER : {2}\n" +
				"TIMESLOT : {3}\n" +
				"STARTROW : {4}\n" +
				"STARTCOLUMN : {5}\n" +
				"---------------------\n",
				ROW, COLUMN,
				USER, TIMESLOT, STARTROW, STARTCOLUMN);
		}
	}
}
