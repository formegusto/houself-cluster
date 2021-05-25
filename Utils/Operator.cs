using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace houself_cluster.Utils
{
	public class Operator
	{
		public static double Distance(double[] energy1, double[] energy2)
		{
			double distance = 0;
			for (int e = 0; e < energy1.Length; e++)
				distance += Math.Pow(energy1[e] - energy2[e], 2);
			return distance;
		}
	}
}
