using houself_cluster.Common;

using System;
namespace houself_cluster.Utils
{
	public class DateUtils
	{
		public static Season DateToSeason(DateTime date)
		{
			switch(date.Month)
			{
				case 12:
				case 1:
				case 2:
					return Season.WINTER;
				case 3:
				case 4:
				case 5:
					return Season.SPRING;
				case 6:
				case 7:
				case 8:
					return Season.SUMMER;
				case 9:
				case 10:
				case 11:
					return Season.AUTUMN;
				default:
					return Season.ALL;
			}	
		}

		public static string DayToKR(Day day)
		{
			string kr = "일";

			switch(day)
			{
				case Day.SUN:
					kr = "일";
					break;
				case Day.MON:
					kr = "월";
					break;
				case Day.TUE:
					kr = "화";
					break;
				case Day.WED:
					kr = "수";
					break;
				case Day.THU:
					kr = "목";
					break;
				case Day.FRI:
					kr = "금";
					break;
				case Day.SAT:
					kr = "토";
					break;

			}
			return kr;
		}
	}
}
