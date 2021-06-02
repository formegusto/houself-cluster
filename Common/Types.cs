using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace houself_cluster.Common
{
	public enum Day
	{
		SUN,
		MON,
		TUE,
		WED,
		THU,
		FRI,
		SAT
	}
	public enum Season
	{
		ALL,
		SPRING = 0,
		SUMMER = 1,
		AUTUMN = 2,
		WINTER = 3
	}

	public enum Timeslot
	{
		H3 = 8,
		H4 = 6,
		H6 = 4,
		H8 = 3,
		H12 = 2,
		H24 = 1
	}
}
