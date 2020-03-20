using System;
using System.Text;
using System.Collections.Generic;
using ERPForServiceActivity.CommonModels.BindingModels;
using ERPForServiceActivity.CommonModels.ViewModels.Speedy;

namespace ERPForServiceActivity.Models.Speedy {
	public class SpeedyShipment {
		public int RepairId { get; set; }

		public SpeedyShipmentViewModel Shipment { get; set; }
	}
}
