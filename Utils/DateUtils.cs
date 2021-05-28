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
	}
}
