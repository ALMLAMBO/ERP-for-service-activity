namespace ERPForServiceActivity.Common {
	public class ApiUrlAddresses {
		private const string baseAddress = "https://localhost:44333/";

		private static string repairBaseAddress =
			$"{baseAddress}repair/";

		public static string AddRepairUrl { get; set; } =
			$"{repairBaseAddress}add-repair";
	}
}
