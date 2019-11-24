using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ERPForServiceActivity.Security;
using Google.Cloud.Vision.V1;

namespace ERPForServiceActivity.DataFromImage {
	public class GetDataFromImage {
		private string filepath = @"E:\Diploma-project\ERP-for-service-activity\ERPForServiceActivity.DataFromImage\erp-for-service-activity-7896e2fd1fc6.json";
		private ImageAnnotatorClient client;

		public GetDataFromImage() {
			Environment.SetEnvironmentVariable(
				"GOOGLE_APPLICATION_CREDENTIALS", filepath);

			client = ImageAnnotatorClient.Create();
		}

		private IReadOnlyList<EntityAnnotation> GetImageData() {
			Image image = Image.FromFile(@"E:\ALEKS\test_photo4.jpg");

			return client.DetectText(image);
		}

		public string GetSerialNumber() {
			var response = GetImageData();
			string serialNumber = "";

			foreach (var annotation in response) {
				Match snMatch = CommonSecurityConstants
					.getLGSerialNumber.Match(annotation.Description);

				if(snMatch.Success) {
					serialNumber = annotation.Description;
				}
			}

			return serialNumber;
		}
	}
}
