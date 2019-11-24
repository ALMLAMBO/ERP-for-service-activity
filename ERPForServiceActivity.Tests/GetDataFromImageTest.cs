using System;
using System.Collections.Generic;
using System.Text;
using Google.Cloud.Vision.V1;
using Xunit;
using ERPForServiceActivity.DataFromImage;

namespace ERPForServiceActivity.Tests {
	public class GetDataFromImageTest {
		[Fact]
		public void TestGetSerialNumber() {
			GetDataFromImage data = new GetDataFromImage();
			string sn = data.GetSerialNumber();
			
			Assert.NotNull(sn);
			Assert.Equal("803MAPN5L200", sn);
		}
	}
}
