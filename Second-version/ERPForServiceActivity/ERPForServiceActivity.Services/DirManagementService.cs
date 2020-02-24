using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;
using MatBlazor;
using ERPForServiceActivity.Security;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;
using System.Drawing.Imaging;

namespace ERPForServiceActivity.Services {
	public class DirManagementService : 
		IDirManagementService {

		private int id = 0;
		private RepairImagesBindingModel images;
		private string baseRepairImagesPath = string.Empty;
		private string sNImagePath = string.Empty;
		private string otherImagesPath = string.Empty;
		private string partsImagesPath = string.Empty;

		public DirManagementService() {

		}

		public DirManagementService(
			RepairImagesBindingModel images, int id) {

			this.images = images;
			this.id = id;
		}

		public void CreateRootDir(bool cancelled) {
			string dirName = cancelled ? 
				$"{id}-cancelled" : id.ToString();

			string fullPath = Path.Combine(
				CommonSecurityConstants.BasePathForRepairData,
				dirName);

			if(!Directory.Exists(fullPath)) {
				Directory.CreateDirectory(fullPath);

				fullPath = Path.Combine(fullPath, @"\Images");
				Directory.CreateDirectory(fullPath);

				baseRepairImagesPath = fullPath;
			}
		}

		public void CreateSubDirs() {
			if(Directory.Exists(baseRepairImagesPath)) {
				sNImagePath = Path.Combine(
					baseRepairImagesPath,
					@"\SN");

				Directory.CreateDirectory(sNImagePath);

				otherImagesPath = Path.Combine(
					baseRepairImagesPath,
					@"\Other-images");

				Directory.CreateDirectory(otherImagesPath);

				partsImagesPath = Path.Combine(
					baseRepairImagesPath,
					@"\Parts-images");

				Directory.CreateDirectory(partsImagesPath);
			}
		}

		public void MoveData() {
			if(Directory.Exists(baseRepairImagesPath
				.Replace(@"\Images", ""))) {

				Directory.Move(
					baseRepairImagesPath, 
					baseRepairImagesPath
						.Replace(@"\Images", "-cancelled"));

				Directory.Delete(baseRepairImagesPath, true);
			}
		}

		public void SaveImage() {
			if(Directory.Exists(sNImagePath)) {
				string imagePath = @$"{sNImagePath}\{images
					.SNImage
					.Name
					.ToLower()
					.Replace("\\s+", "-")}.jpeg";

				ConvertToBitmap(images.SNImage)
					.Result
					.Save(imagePath, ImageFormat.Jpeg);
			}
		}

		private async Task<Bitmap> ConvertToBitmap(MatFileUploadEntry file) {
			MemoryStream stream = new MemoryStream();
			await file.WriteToStreamAsync(stream);

			return new Bitmap(stream);
		} 

		public void SaveMultipleImages() {
			if(Directory.Exists(otherImagesPath)) {
				images.OtherImages
					.ToList()
					.ForEach(file => {
						string imagePath = @$"{sNImagePath}\{file
							.Name
							.ToLower()
							.Replace("\\s+", "-")}.jpeg";

						ConvertToBitmap(file)
							.Result
							.Save(imagePath, ImageFormat.Jpeg);
					});
			}
		}
	}
}
