using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;


namespace Model
{
    public class FileExporter
    {

        public void ExportToPDF(Booking memberNumber, Member name, string goal, string trainingProgram, string weeklyTrainings, string timePerTraining, string notes)
        {

            string root = @"C:\Users\royga\Documents\" + memberNumber + ".docx";
            //Creates application
            Microsoft.Office.Interop.Word.Application objWord = new Microsoft.Office.Interop.Word.Application();

            objWord.Visible = true;
            objWord.WindowState = WdWindowState.wdWindowStateNormal;

            //Creates document
            Document objDoc = objWord.Documents.Add();

           

            //Adds paragraphs
            Paragraph objParagraph;
            objParagraph = objDoc.Paragraphs.Add();
            objParagraph.Range.Text =
                "Træningsprogram for " + memberNumber + "\n"
                + "Navn: " + name + "\n"
                + "Formål: " + goal + "\n"
                + "Træningsprogram: " + trainingProgram + "\n"
                + "Antal træninger om ugen: " + weeklyTrainings + "\n"
                + "Varighed pr. træning: " + timePerTraining + "\n"
                + "Noter: " + notes + "\n";

            objDoc.SaveAs2(root);
            objDoc.Close();
            objWord.Quit();
            Process.Start(root);

            //string root = @"C:\Users\royga\Documents\HOFI-journaler";
            //// Create a new PDF document
            //PdfDocument document = new PdfDocument();

            //// Create an empty page
            //PdfPage page = document.AddPage();

            //// Get an XGraphics object for drawing
            //XGraphics gfx = XGraphics.FromPdfPage(page);

            //// Create a font
            //XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            //XFont font_Headline = new XFont("Verdana", 35, XFontStyle.Bold);



            //// Draw the text
            //gfx.DrawString("Træningsforløb for " + memberNumber + "\n", font_Headline, XBrushes.Blue,
            //  new XRect(0, 0, page.Width, page.Height),
            //  XStringFormats.TopCenter);

            //gfx.DrawString(name, font, XBrushes.Black,
            //  new XRect(0, 50, page.Width, page.Height),
            //  XStringFormats.TopLeft);
            //gfx.DrawString("Formål: " + goal, font, XBrushes.Black,
            //  new XRect(0, 100, page.Width, page.Height),
            //  XStringFormats.TopLeft);

            //gfx.DrawString("Ønsket træningsprogram: " + trainingProgram, font, XBrushes.Black,
            //  new XRect(0, 150, page.Width, page.Height),
            //  XStringFormats.TopLeft);

            //gfx.DrawString("Antal træninger pr. uge: " + weeklyTrainings, font, XBrushes.Black,
            //  new XRect(0, 200, page.Width, page.Height),
            //  XStringFormats.TopLeft);

            //gfx.DrawString("Varighed pr. træning" + timePerTraining, font, XBrushes.Black,
            //  new XRect(0, 250, page.Width, page.Height),
            //  XStringFormats.TopLeft);
            //gfx.DrawString("Evt. noter: " + notes, font, XBrushes.Black,
            //  new XRect(0, 300, page.Width, page.Height),
            //  XStringFormats.TopLeft);


            //root += @"\\" + memberNumber + @"\\" + goal;
            //System.IO.Directory.CreateDirectory(root);

            //// Save the document...
            //string filename = goal + ".pdf";
            //document.Save(filename);
            //// ...and start a viewer.
            //Process.Start(filename);







        }

       

        public void UpdateStatisticTExcel(List<int> fileNumbersList)
        {
            string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string primaryFoldername = folderpath + "\\HøjRegistrering";
            string statisticFoldername = primaryFoldername + "\\Statistik";
            if (!Directory.Exists(primaryFoldername))
            {
                Directory.CreateDirectory(primaryFoldername);
            }
            if (!Directory.Exists(statisticFoldername))
            {
                Directory.CreateDirectory(statisticFoldername);
            }
            string filename = "Statestik.csv";
            string pathname = Path.Combine(statisticFoldername, filename);
            using (StreamWriter sw = File.CreateText(pathname))
            {
            }
            Excel.Application ExcelAppObj = new Excel.Application();
            ExcelAppObj.DisplayAlerts = false;
            Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            

            //Åbner den et excelprojekt (En "Workbook")
            Excel.Workbook workbook = ExcelAppObj.Workbooks.Open(pathname, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false);

            //Åbner den første side i excelprojektet
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);

            //Test! Skriver 20 i en bestemt celle
            worksheet.Cells[2, 2] = fileNumbersList[0];
            worksheet.Cells[3, 2] = fileNumbersList[0];
            worksheet.Cells[4, 2] = fileNumbersList[0];
            worksheet.Cells[5, 2] = fileNumbersList[0];
            worksheet.Cells[6, 2] = fileNumbersList[0];

            //Gemmer det vi lige har gjort og lukker vores projekt
            workbook.SaveAs(pathname, Excel.XlFileFormat.xlOpenXMLWorkbook, null, null, false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, null, null, null);
        }
    }
}