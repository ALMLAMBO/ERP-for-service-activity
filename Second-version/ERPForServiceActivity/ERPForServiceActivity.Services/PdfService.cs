using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Data;
using ERPForServiceActivity.Models.Repairs;
using ERPForServiceActivity.Services.Interfaces;

namespace ERPForServiceActivity.Services {
	public class PdfService : IPdfService {
		public async void CreatePdf(int id, string type, string notes) {
			if(type == "Accept") {
				await CreateAcceptPdf(id, notes);
			}
			else if(type == "Resign") {
				CreateResignPdf(id, notes);
			}
		}

		private async Task CreateAcceptPdf(int id, string notes) {
			ConnectionConfig connection = new ConnectionConfig();
			FirestoreDb db = connection.GetFirestoreDb();

			QuerySnapshot snapshot = await db
				.Collection("service-repairs")
				.WhereEqualTo("RepairId", id)
				.GetSnapshotAsync();

			Repair repair = snapshot
				.FirstOrDefault()
				.ConvertTo<Repair>();
			
			PdfDocument document = new PdfDocument();
			document.Info.Title = "Created with PdfSharp";
			PdfPage page = document.AddPage();
			page.Size = PageSize.A4;
			XGraphics gfx = XGraphics.FromPdfPage(page);
			XFont font = new XFont("Times New Roman", 36, XFontStyle.Bold);
			gfx.DrawString("Сервизна карта", font, XBrushes.Black,
				new XRect(0, 94, page.Width, page.Height),
				XStringFormats.TopCenter);

			string reclaim = "A";
			for (int i = 0; i < 8 - repair.RepairId.ToString().Length; i++) {
				reclaim += "0";
			}
			reclaim += repair.RepairId.ToString();

			gfx.DrawString($"{reclaim} / {repair.CreatedAt.ToString("dd.MM.yyyy")}",
				new XFont("Times New Roman", 20, XFontStyle.Bold),
				XBrushes.Black, new XRect(0, 140, page.Width, page.Height),
				XStringFormats.TopCenter);

			gfx.DrawString("Издадена от: сервиз Бай Пешо",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(0, 170, page.Width, page.Height),
				XStringFormats.TopCenter);

			gfx.DrawString("Клиент:",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(96, -190, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString(repair.CustomerName,
				new XFont("Times New Roman", 14, XFontStyle.Regular),
				XBrushes.Black, new XRect(96, -170, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString("Марка:",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(347.5, -190, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString(repair.ApplianceBrand,
				new XFont("Times New Roman", 14, XFontStyle.Regular),
				XBrushes.Black, new XRect(347.5, -170, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString("Адрес:",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(96, -150, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString(repair.CustomerAddress,
				new XFont("Times New Roman", 14, XFontStyle.Regular),
				XBrushes.Black, new XRect(96, -130, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString("Модел:",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(347.5, -150, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString(repair.ApplianceModel,
				new XFont("Times New Roman", 14, XFontStyle.Regular),
				XBrushes.Black, new XRect(347.5, -130, page.Width, page.Height),
				XStringFormats.CenterLeft);



			gfx.DrawString("Телефон:",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(96, -110, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString(repair.CustomerPhoneNumber,
				new XFont("Times New Roman", 14, XFontStyle.Regular),
				XBrushes.Black, new XRect(96, -90, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString("Сериен номер:",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(347.5, -110, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString(repair.ApplianceSerialNumber,
				new XFont("Times New Roman", 14, XFontStyle.Regular),
				XBrushes.Black, new XRect(347.5, -90, page.Width, page.Height),
				XStringFormats.CenterLeft);



			gfx.DrawString("Дефект според клиента:",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(96, -70, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString(repair.DefectByCustomer,
				new XFont("Times New Roman", 14, XFontStyle.Regular),
				XBrushes.Black, new XRect(96, -50, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString("IMEI:",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(347.5, -70, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString(repair.ApplianceProductCodeOrImei,
				new XFont("Times New Roman", 14, XFontStyle.Regular),
				XBrushes.Black, new XRect(347.5, -50, page.Width, page.Height),
				XStringFormats.CenterLeft);



			gfx.DrawString("Комплектация:",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(96, -30, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString(repair.ApplianceEquipment,
				new XFont("Times New Roman", 14, XFontStyle.Regular),
				XBrushes.Black, new XRect(96, -10, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString("Дата на покупка:",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(347.5, -30, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString($"{repair.BoughtAt.ToString("dd.MM.yyyy hh:MM:ss")}",
				new XFont("Times New Roman", 14, XFontStyle.Regular),
				XBrushes.Black, new XRect(347.5, -10, page.Width, page.Height),
				XStringFormats.CenterLeft);



			gfx.DrawString("Доп. информация:",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(96, 10, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString(repair.AdditionalInformation,
				new XFont("Times New Roman", 14, XFontStyle.Regular),
				XBrushes.Black, new XRect(96, 30, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString("Гаранционен период/месеци/:",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(347.5, 10, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString(repair.WarrantyPeriod.ToString(),
				new XFont("Times New Roman", 14, XFontStyle.Regular),
				XBrushes.Black, new XRect(347.5, 30, page.Width, page.Height),
				XStringFormats.CenterLeft);



			gfx.DrawString("Забележки външен вид:",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(96, 50, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString(notes,
				new XFont("Times New Roman", 14, XFontStyle.Regular),
				XBrushes.Black, new XRect(96, 70, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString("Покупка от:",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(347.5, 50, page.Width, page.Height),
				XStringFormats.CenterLeft);

			gfx.DrawString(repair.BoughtFrom,
				new XFont("Times New Roman", 14, XFontStyle.Regular),
				XBrushes.Black, new XRect(347.5, 70, page.Width, page.Height),
				XStringFormats.CenterLeft);



			gfx.DrawString("Приел в сервиза: ……………",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(0, 170, page.Width - 94, page.Height),
				XStringFormats.CenterRight);

			gfx.DrawString("/ Бай Пешо /",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(0, 190, page.Width - 94, page.Height),
				XStringFormats.CenterRight);

			gfx.DrawString("Предал: ………………………",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(0, 210, page.Width - 94, page.Height),
				XStringFormats.CenterRight);

			gfx.DrawString($"/ {repair.CustomerName} /",
				new XFont("Times New Roman", 14, XFontStyle.Bold),
				XBrushes.Black, new XRect(0, 230, page.Width - 94, page.Height),
				XStringFormats.CenterRight);

			string path = @$"C:\Users\aleks\Desktop\Приемане-{repair.RepairId}.pdf";

			document.Save(path);

		}

		private void CreateResignPdf(int id, string notes) {

		}
	}
}
