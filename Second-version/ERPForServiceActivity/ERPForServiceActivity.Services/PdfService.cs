using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using ERPForServiceActivity.Models.Repairs;
using ERPForServiceActivity.Services.Interfaces;

namespace ERPForServiceActivity.Services {
	public class PdfService : IPdfService {
		public void CreatePdf(Repair reapir) {
			WordprocessingDocument document =
				WordprocessingDocument.Open(
					@"C:\Users\aleks\Desktop\add.docx", true);

			DocumentFormat.OpenXml.Drawing.Table table = document
				.MainDocumentPart
				.Document.Body.Elements<DocumentFormat
					.OpenXml.Drawing.Table>().FirstOrDefault();

			DocumentFormat.OpenXml.Drawing.TableRow row = table.Elements<DocumentFormat
				.OpenXml.Drawing.TableRow>().ElementAt(2);

			Cell cell = row.Elements<Cell>().ElementAt(0);

			DocumentFormat.OpenXml.Drawing.Paragraph paragraph = cell
				.Elements<DocumentFormat.OpenXml.Drawing.Paragraph>()
				.FirstOrDefault();

			DocumentFormat.OpenXml.Drawing.Run run = paragraph
				.Elements<DocumentFormat.OpenXml.Drawing.Run>()
				.FirstOrDefault();

			DocumentFormat.OpenXml.Drawing.Text text = run
				.Elements<DocumentFormat.OpenXml.Drawing.Text>()
				.FirstOrDefault();

			text.Text = "";
		}

		private void AddToWord(string data) {

		}
	}
}
