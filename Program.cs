using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace houself_cluster
{
	static class Program
	{
		/// <summary>
		/// 해당 애플리케이션의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Component comp = new Component();
			IModel model = new HouselfClusterModel();
			IController controller = new HouselfClusterController(comp, model);

			Application.Run(comp);
		}
	}
}
