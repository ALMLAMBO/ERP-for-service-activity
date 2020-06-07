using System.Collections.Generic;

namespace ERPForServiceActivity.Common {
	public class BrandsInfo {
		public static List<string> Brands {
			get {
				return new List<string>() {
					"LG", "Samsung", "Huawei",
					"Arielli", "Asus"
				};
			}
		} 
			

		public static List<string> Types {
			get {
				return new List<string>() {
					"TV", "Washing Machine", "Oven",
					"Mobile Phone", "Refrigerator"
				};
			}
		} 
			
	}
}
