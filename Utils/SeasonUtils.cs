using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using houself_cluster.Common;

namespace houself_cluster.Utils
{
	public class SeasonUtils
	{
		public static List<int> SeasonToMonth(Season s)
		{
			List<int> targetMonth = null;

			switch (s)
			{
				case Season.ALL:
					targetMonth = new List<int>()
					{
						1,2,3,4,5,6,7,8,9,10,11,12
					};

					break;

				case Season.SPRING:
					targetMonth = new List<int>()
					{
						3,4,5
					};

					break;

				case Season.SUMMER:
					targetMonth = new List<int>()
					{
						6,7,8
					};

					break;

				case Season.AUTUMN:
					targetMonth = new List<int>()
					{
						9,10,11
					};

					break;

				case Season.WINTER:
					targetMonth = new List<int>()
					{
						12,1,2
					};

					break;
			}

			return targetMonth;
		}
		public static List<DateTime> SeasonToDate(Season s)
		{
			List<DateTime> dates = new List<DateTime>();
			List<int> targetMonth = null;

			switch (s)
			{
				case Season.ALL:
					targetMonth = new List<int>()
					{
						1,2,3,4,5,6,7,8,9,10,11,12
					};

					break;

				case Season.SPRING:
					targetMonth = new List<int>()
					{
						3,4,5
					};

					break;

				case Season.SUMMER:
					targetMonth = new List<int>()
					{
						6,7,8
					};

					break;

				case Season.AUTUMN:
					targetMonth = new List<int>()
					{
						9,10,11
					};

					break;

				case Season.WINTER:
					targetMonth = new List<int>()
					{
						12,1,2
					};

					break;
			}

			DateTime startTime = new DateTime(2018, 5, 1);
			DateTime endTime = new DateTime(2019, 4, 29);

			for (DateTime d = startTime; d < endTime; d = d.AddMonths(1))
			{
				int month = d.Month;
				int test = targetMonth.Find(tm => tm == month);
				if (test != 0)
				{
					DateTime seasonStartTime = new DateTime(d.Year, d.Month, d.Day);
					for (DateTime dd = seasonStartTime; dd.Month == seasonStartTime.Month; dd = dd.AddDays(1))
					{
						if (dd <= endTime)
							dates.Add(dd);
					}
				}
			}

			return dates;
		}

		public static string SeasonToKR(Season season)
		{
			string kr = "봄";

			switch(season)
			{
				case Season.SPRING:
					kr = "봄";
					break;
				case Season.SUMMER:
					kr = "여름";
					break;
				case Season.AUTUMN:
					kr = "가을";
					break;
				case Season.WINTER:
					kr = "겨울";
					break;
			}

			return kr;
		}
	}
}
