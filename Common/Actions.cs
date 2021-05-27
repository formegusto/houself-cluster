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
		public const string RECLUSTER = "view/recluster";
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

		public const string REQUEST_DATAS = "model/request_datas";
		public const string REQUEST_DATAS_SUCCESS = "model/request_datas/success";
		public const string REQUEST_DATAS_FAILURE = "model/request_datas/failure";

		public const string DATA_PREPROCESSING = "model/data_ppro";
		public const string DATA_PREPROCESSING_SUCCESS = "model/data_ppro/success";
		public const string DATA_PREPROCESSING_FAILURE = "model/data_ppro/failure";

		public const string SET_CLUSTER = "model/set_cluster";
		public const string SET_CLUSTER_SUCCESS = "model/set_cluster/success";
		public const string SET_CLUSTER_FAILURE = "model/set_cluster/failure";

		public const string ASSIGN_INSTANCE = "model/assign_instance";
		public const string ASSIGN_INSTANCE_SUCCESS = "model/assign_instance/success";
		public const string ASSIGN_INSTANCE_FAILURE = "model/assign_instance/failure";
		public const string ASSIGN_ALL_INSTANCE_SUCCESS = "model/assign_all_instance/success";

		public const string RECLUSTER_SUCCESS = "model/recluster/success";
		public const string RECLUSTER_FAILURE = "model/recluster/failure";
	}
}
