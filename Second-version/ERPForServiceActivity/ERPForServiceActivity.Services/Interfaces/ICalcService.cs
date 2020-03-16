using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface ICalcService {
		public Task<double> CalcRepairPrice(int id);
	}
}
