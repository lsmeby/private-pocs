using System.IO;
using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ExcelPoC
{
    public class WorksheetGenerator
    {
        public static void Generate()
        {

            var workBookStream = new MemoryStream();

            // Create a spreadsheet document by supplying the filepath.
           // By default, AutoSave = true, Editable = true, and Type = xlsx.
           var spreadsheetDocument = SpreadsheetDocument.Create(workBookStream, SpreadsheetDocumentType.Workbook);

           // Add a WorkbookPart to the document.
           var workbookpart = spreadsheetDocument.AddWorkbookPart();
           workbookpart.Workbook = new Workbook();

            spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

           // Add a WorksheetPart to the WorkbookPart.
           var worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
           worksheetPart.Worksheet = new Worksheet(new SheetData());
           var sheet1 = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "mySheet" };
           workbookpart.Workbook.Sheets.Append(sheet1);

            var worksheetPart2 = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart2.Worksheet = new Worksheet(new SheetData());
            var sheet2 = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart2), SheetId = 2, Name = "newSheet" };
            workbookpart.Workbook.Sheets.Append(sheet2);

            

           ImageHelper.InsertImage(worksheetPart, 0, 0, 0, 0, new FileStream("C:\\Users\\Lars Smeby\\Desktop\\bekk.png", FileMode.Open));
           ImageHelper.InsertImage(worksheetPart2, 0, 0, 0, 0, new FileStream("C:\\Users\\Lars Smeby\\Desktop\\bekk.png", FileMode.Open));

            workbookpart.Workbook.Save();

           // Close the document.
           spreadsheetDocument.Close();

            var workbook = new XLWorkbook(workBookStream);
            var worksheet = workbook.Worksheets.Worksheet("mySheet");
            worksheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
            worksheet.SheetView.View = XLSheetViewOptions.PageLayout;

            worksheet.PageSetup.Margins.Top = 0.39;
            worksheet.PageSetup.Margins.Bottom = 0.39;
            worksheet.PageSetup.Margins.Left = 0.59;
            worksheet.PageSetup.Margins.Right = 0.39;
            worksheet.PageSetup.Margins.Header = 0.31;
            worksheet.PageSetup.Margins.Footer = 0.31;

            worksheet.Style.Font.SetFontSize(8);
            worksheet.Style.Font.SetFontName("Arial");

            var pageWidth = 21;// -1.4986 - 0.9906;

            worksheet.Column(1).Width = 13.48 / pageWidth * 100;
            worksheet.Column(2).Width = 2.22/pageWidth*100;
            worksheet.Column(3).Width = 2.68/pageWidth*100;
            worksheet.Row(1).Height = CentimeterToPoints(3.15);
            worksheet.Row(14).Height = CentimeterToPoints(1.39);
            worksheet.Row(22).Height = CentimeterToPoints(1.74);
            worksheet.Row(23).Height = CentimeterToPoints(1.06);
            worksheet.Row(25).Height = CentimeterToPoints(1.11);
            worksheet.Row(28).Height = CentimeterToPoints(0.85);
            worksheet.Row(33).Height = CentimeterToPoints(7.41);

            worksheet.Cell("A2").Value = "<Kunde>";
            worksheet.Cell("A2").Style.Font.SetFontSize(13);
            worksheet.Cell("B2").Value = "Bekk Consulting AS";
            worksheet.Cell("B2").Style.Font.SetFontSize(13);

            worksheet.Cell("A3").Value = "<Adresse>";
            worksheet.Cell("A3").Style.Font.SetFontSize(10);
            worksheet.Cell("B3").Value = "Postboks 134, Sentrum";
            worksheet.Cell("B3").Style.Font.SetFontSize(10);

            worksheet.Cell("A4").Value = "<Adresse>";
            worksheet.Cell("A4").Style.Font.SetFontSize(10);
            worksheet.Cell("B4").Value = "0102 OSLO";
            worksheet.Cell("B4").Style.Font.SetFontSize(10);

            worksheet.Cell("A5").Value = "<Postnummer STED>";
            worksheet.Cell("A5").Style.Font.SetFontSize(10);

            worksheet.Cell("A7").Value = "Att: <Deres referanse>";
            worksheet.Cell("B7").Value = "Telefon:";
            worksheet.Cell("C7").Value = "+47 23 35 77 00";
            worksheet.Cell("C7").DataType = XLCellValues.Text;

            worksheet.Cell("B8").Value = "Orgnr.:";
            worksheet.Cell("C8").Value = "981566378MVA";

            worksheet.Cell("A9").Value = "e:<eFaktura-adresse>";
            worksheet.Cell("C9").Value = "Foretaksregisteret";

            worksheet.Cell("B10").Value = "Bank:";
            worksheet.Cell("C10").Value = "16440885628";
            worksheet.Cell("C10").DataType = XLCellValues.Text;

            worksheet.Cell("B11").Value = "eFaktura:";
            worksheet.Cell("C11").Value = "NO981566378";

            worksheet.Cell("B12").Value = "Swift:";
            worksheet.Cell("C12").Value = "DNBANOKKXXX";

            worksheet.Cell("B13").Value = "Iban:";
            worksheet.Cell("C13").Value = "NO8716440885628";

            worksheet.Cell("B14").Value = "Faktura";
            worksheet.Cell("B14").Style.Font.SetFontSize(13);

            worksheet.Cell("B15").Value = "Nummer:";
            worksheet.Cell("C15").Value = "14XXXX";

            worksheet.Cell("B16").Value = "Dato:";
            worksheet.Cell("C16").Value = "31/10/14";
            worksheet.Cell("C16").DataType = XLCellValues.DateTime;

            worksheet.Cell("B17").Value = "Forfallsdato:";
            worksheet.Cell("C17").Value = "30/11/14";
            worksheet.Cell("C17").DataType = XLCellValues.DateTime;

            worksheet.Cell("B19").Value = "Vår kontakt:";
            worksheet.Cell("C19").Value = "<Navn>";

            worksheet.Cell("B20").Value = "Vår referanse:";
            worksheet.Cell("C20").Value = "<Prosjektkode>";

            worksheet.Cell("B21").Value = "Vår avdeling:";

            worksheet.Ranges("A22:C22").Style.Border.BottomBorder = XLBorderStyleValues.Thin;

            worksheet.Cell("A23").Value = "Konsulenttjenester oktober";
            worksheet.Cell("A23").Style.Font.SetFontSize(15);

            worksheet.Cell("A24").Value = "Kontrakt: <nr> / Ordre: <nr> - <Navn på prosjekt>";
            worksheet.Cell("A24").Style.Font.SetFontSize(11);
            worksheet.Cell("A24").Style.Font.SetItalic(true);

            worksheet.Cell("A26").Value = "- Konsulenttjenester, avgiftspliktig";
            worksheet.Cell("C26").Value = "0,00";
            worksheet.Cell("C26").Style.NumberFormat.Format = "#,##0.00";

            worksheet.Cell("A27").Value = "- Viderefakturerte utlegg, avgiftspliktig";
            worksheet.Cell("C27").Value = "0,00";
            worksheet.Cell("C27").Style.NumberFormat.Format = "#,##0.00";

            worksheet.Ranges("A28:C28").Style.Border.BottomBorder = XLBorderStyleValues.Thin;

            worksheet.Cell("B30").Value = "Sum eksl. MVA";
            worksheet.Cell("B30").Style.Font.SetBold(true);
            worksheet.Cell("C30").Value = "0,00";
            worksheet.Cell("C30").Style.NumberFormat.Format = "#,##0.00";

            worksheet.Cell("B31").Value = "25% MVA";
            worksheet.Cell("C31").Value = "0,00";
            worksheet.Cell("C31").Style.NumberFormat.Format = "#,##0.00";

            worksheet.Cell("B32").Value = "Sum inkl. MVA";
            worksheet.Cell("B32").Style.Font.SetBold(true);
            worksheet.Cell("C32").Value = "0,00";
            worksheet.Cell("C32").Style.NumberFormat.Format = "#,##0.00";

            worksheet.Cell("A33").Value = "Vennligst betal til bankkonto 1644.08.85628 innen 30.11.2014 og oppgi " +
                                          "fakturanummer 14XXXX ved innbetaling.\r\n\r\n" +
                                          "Spørsmål om fakturaen kan rettes til din kontaktperson eller til post@bekk.no. " +
                                          "Ønsker du å motta eFaktura fra Bekk Consulting AS i fremtiden? Send en henvendelse " +
                                          "til efaktura@bekk.no";
            worksheet.Cell("A33").Style.Font.SetFontSize(9);
            worksheet.Cell("A33").Style.Alignment.WrapText = true;
            worksheet.Range("A33:C33").Merge();

            var newSheet = workbook.Worksheet("newSheet");

            newSheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
            newSheet.SheetView.View = XLSheetViewOptions.PageLayout;

            newSheet.PageSetup.Margins.Top = 0.39;
            newSheet.PageSetup.Margins.Bottom = 0.39;
            newSheet.PageSetup.Margins.Left = 0.59;
            newSheet.PageSetup.Margins.Right = 0.39;
            newSheet.PageSetup.Margins.Header = 0.31;
            newSheet.PageSetup.Margins.Footer = 0.31;

            newSheet.Cell("A2").Value = "Ikke ny kunde";

            workbook.SaveAs("C:\\Users\\Lars Smeby\\Desktop\\test8.xlsx");
        }

        private static double CentimeterToPoints(double cm)
        {
            var inch = 0.393700787;
            return cm*inch*72;
        }
    }
}
