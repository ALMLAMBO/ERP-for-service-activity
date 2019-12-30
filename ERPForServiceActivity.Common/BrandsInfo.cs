using System;
using System.Collections.Generic;
using System.Text;

namespace ERPForServiceActivity.Common {
	public class BrandsInfo {
		public static List<string> Brands { get; set; } = new List<string>() {
			"LG", "Samsung", "Huawei", "Arielli", "Asus"
		};

		public static Dictionary<string, List<string>>
			ModelsForBrand { get; set; } = 
			new Dictionary<string, List<string>>() {
				{"LG", new List<string>() {
					"", "", ""
				} },

				{"Samsung", new List<string>() {
					"", "", ""
				} },

				{"Asus", new List<string>() {
					"", "", "" 
				} },

				{"Huawei", new List<string>() { 
					"", "", "" 
				} },

				{"Arielli", new List<string>() { 
					"", "", ""
				} }
			};
	}
}
