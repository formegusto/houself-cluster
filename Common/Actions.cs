using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace houself_cluster.Common
{
	public static class COMMON_ACTION
	{
		public const string START_LOADING = "start_loading";
		public const string STOP_LOADING = "stop_loadig";
	}
	public static class VIEW_ACTION
	{
		public const string INIT_EXCEL_LOAD = "view/init_excel_load";
		public const string START_CLUSTERING = "view/start_clustering";
		public const string CHANGE_KEYWORD = "view/change_keyword";
		public const string CHANGE_DAYS = "view/change_days";
		public const string CHANGE_SEASONS = "view/change_seasons";
	}
	public static class MODEL_ACTION
	{
		public const string READ_FILE_SUCCESS = "model/read_file/success";

		public const string INIT_EXCEL_LOAD_SUCCESS = "model/init_excel_load/success";
		public const string INIT_EXCEL_LOAD_FAILURE = "model/init_excel_load/failure";

		public const string SEARCH_KEYWORD_FIND = "model/search_keyword/find";
		public const string SEARCH_KEYWORD_NOTFOUND = "model/search_keyword/notfound";
	}
}
