using System;
using System.Collections.Generic;
using System.Text;

namespace ERPForServiceActivity.Common {
	public class BrandsInfo {
		public static List<string> Brands { get; set; } = new List<string>() {
			"LG", "Samsung", "Huawei", "Arielli", "Asus"
		};

		public static List<string> Types { get; set; } = new List<string>() {
			"TV", "Washing Machine", "Oven", "Mobile Phone", "Refrigerator"
		};
	}
}
