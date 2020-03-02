using System;
using System.Text;
using System.Collections.Generic;
using ERPForServiceActivity.Models.Repairs;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface IPdfService {
		public void CreatePdf(Repair reapir);
	}
}
