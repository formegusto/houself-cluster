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
		public const string MERGECLUSTER = "view/mergeclutser";
		public const string EVALUATE = "view/evaluate";
		public const string SAVEMODE = "view/savemode";
		public const string SEASON_STATISTIC = "view/season_statistic";
		public const string CONFIRM = "view/confirm";
		public const string CHANGE_KEYWORD = "view/change_keyword";
		public const string CHANGE_DAYS = "view/change_days";
		public const string CHANGE_SEASONS = "view/change_seasons";
		public const string CHANGE_TIMESLOT = "view/change_timeslot";
		public const string REQUEST_FS = "view/request_fs";
		public const string DETAIL_TS_CLUSTER = "view/detail_ts_cluster";
		public const string API_TEST = "view/api_test";
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

		public const string SAVEMODE_DATA = "model/savemode/data";

		public const string MERGECLUSTER_SUCCESS = "view/mergeclutser/success";

		public const string SEASON_STATISTIC_SUCCESS = "view/season_statistic/success";
		public const string SEASON_STATISTIC_FAILURE = "view/season_statistic/failure";

		public const string CONFIRM_SUCCESS = "view/confirm/success";
		public const string CONFIRM_FAILURE = "view/confirm/failure";

		public const string REQUEST_FS_SUCCESS = "veiw/request_fs/success";
		public const string REQUEST_FS_FAILURE = "veiw/request_fs/failure";

		public const string DETAIL_TS_CLUSTER_SUCCESS = "view/detail_ts_cluster/success";

		public const string API_TEST_SUCCESS = "view/api_test/success";
		public const string API_TEST_FAILURE = "view/api_test/failure";
	}
}
