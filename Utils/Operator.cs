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

		public static double Distance(double[] energy1, double[] energy2, double maxValue)
		{
			double distance = 0;
			for (int e = 0; e < energy1.Length; e++)
			{
				distance += Math.Pow(energy1[e] - energy2[e], 2);
				if (distance > maxValue)
					return double.MaxValue;
			}
			return distance;
		}

		public static double ECV(Cluster[] clusters, Data[] datas)
		{
			double[] mean = new double[datas[0].timeslot.Length];
			Parallel.For(0, datas[0].timeslot.Length, (e) =>
			{
				for (int d = 0; d < datas.Length; d++)
					mean[e] += datas[d].timeslot[e];
				mean[e] /= datas.Length;
			});

			double TSS = 0; // Total Sum of Squares
			double WSS = 0; // Within cluster Sum of Squares
			for (int d = 0; d < datas.Length; d++)
			{
				TSS += Math.Pow(Distance(datas[d].timeslot, mean), 2);
				WSS += Math.Pow(Distance(datas[d].timeslot, clusters[datas[d].mainCluster].timeslot), 2);
			}
			return 1 - WSS / TSS;
		}
	}
}
