using System;
using System.Collections.Generic;
using System.Text;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface IDirManagementService {
		public void CreateRootDir(bool cancelled);

		public void CreateSubDirs();

		public void SaveImage();

		public void SaveMultipleImages();

		public void MoveData();
	}
}
