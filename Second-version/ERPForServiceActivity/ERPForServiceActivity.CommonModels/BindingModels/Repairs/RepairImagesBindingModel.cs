using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MatBlazor;

namespace ERPForServiceActivity.CommonModels.BindingModels.Repairs {
	public class RepairImagesBindingModel {
		public MatFileUploadEntry SNImage { get; set; }

		public MatFileUploadEntry OtherImages { get; set; }

		public RepairImagesBindingModel() {

		}

		public MatFileUploadEntry ConvertInterfaceToClass(
			IMatFileUploadEntry file) {

			return new MatFileUploadEntry() {
				Name = file.Name,
				Size = file.Size,
				Type = file.Type,
				LastModified = file.LastModified
			};
		}

		public MatFileUploadEntry[] 
			ConvertMultipleInterfacesToClasses(
				IMatFileUploadEntry[] files) {

			MatFileUploadEntry[] resultFiles = 
				new MatFileUploadEntry[files.Length];

			files
				.ToList()
				.ForEach(file => {
					resultFiles
						.ToList()
						.Add(ConvertInterfaceToClass(file));
				});

			return resultFiles;
		}
	}
}
