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

        public void ExportToWord(Booking booking, Member member, string goal, string trainingProgram, string weeklyTrainings, string timePerTraining, string notes)
        {

            string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string primaryFoldername = folderpath + "\\HOFI";
            string sessionFoldername = primaryFoldername + "\\Forløb";
            string memberNumberFoldername = sessionFoldername + "\\" + booking.MemberNumber;
            string goalFoldername = memberNumberFoldername + "\\" + goal;
            //Directory.CreateDirectory(primaryFoldername);

            //Directory.CreateDirectory(sessionFoldername);

            //Directory.Exists(memberNumberFoldername)

            //Directory.CreateDirectory(memberNumberFoldername);
            Directory.CreateDirectory(goalFoldername);
              
            //Creates application
            Application objWord = new Application();

            objWord.Visible = true;
            objWord.WindowState = WdWindowState.wdWindowStateNormal;

            //Creates document
            Document objDoc = objWord.Documents.Add();

           

            //Adds paragraphs
            Paragraph objParagraph;
            objParagraph = objDoc.Paragraphs.Add();
            objParagraph.Range.Text =
                "Træningsprogram for " + booking.MemberNumber + "\n"
                + "Navn: " + member.Name + "\n"
                + "Formål: " + goal + "\n"
                + "Træningsprogram: " + trainingProgram + "\n"
                + "Antal træninger om ugen: " + weeklyTrainings + "\n"
                + "Varighed pr. træning: " + timePerTraining + "\n"
                + "Noter: " + notes + "\n";

            objDoc.SaveAs2(goalFoldername + "\\" + goal);
            objDoc.Close();
            objWord.Quit();

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

       

        public void UpdateStatisticToExcel(List<int> fileNumbersList)
        {
            string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string primaryFoldername = folderpath + "\\HOFI";
            string statisticFoldername = primaryFoldername + "\\Statistik";

            Directory.CreateDirectory(statisticFoldername);
            
            string filename = "Statistik.csv";
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
            worksheet.Cells[2, 1] = "Styrketræning";
            worksheet.Cells[3, 1] = "Vægttab";
            worksheet.Cells[4, 1] = "Opstramning";
            worksheet.Cells[5, 1] = "Konditionstræning";
            worksheet.Cells[6, 1] = "Kom-Godt-Igang";

            worksheet.Cells[1, 2] = "18-25";
            worksheet.Cells[1, 3] = "26-35";
            worksheet.Cells[1, 4] = "36-45";
            worksheet.Cells[1, 5] = "46-55";
            worksheet.Cells[1, 6] = "55+";

            worksheet.Cells[2, 2] = fileNumbersList[0];
            worksheet.Cells[3, 2] = fileNumbersList[1];
            worksheet.Cells[4, 2] = fileNumbersList[2];
            worksheet.Cells[5, 2] = fileNumbersList[3];
            worksheet.Cells[6, 2] = fileNumbersList[4];

            worksheet.Cells[2, 3] = fileNumbersList[5];
            worksheet.Cells[3, 3] = fileNumbersList[6];
            worksheet.Cells[4, 3] = fileNumbersList[7];
            worksheet.Cells[5, 3] = fileNumbersList[8];
            worksheet.Cells[6, 3] = fileNumbersList[9];

            worksheet.Cells[2, 4] = fileNumbersList[10];
            worksheet.Cells[3, 4] = fileNumbersList[11];
            worksheet.Cells[4, 4] = fileNumbersList[12];
            worksheet.Cells[5, 4] = fileNumbersList[13];
            worksheet.Cells[6, 4] = fileNumbersList[14];

            worksheet.Cells[2, 5] = fileNumbersList[15];
            worksheet.Cells[3, 5] = fileNumbersList[16];
            worksheet.Cells[4, 5] = fileNumbersList[17];
            worksheet.Cells[5, 5] = fileNumbersList[18];
            worksheet.Cells[6, 5] = fileNumbersList[19];

            worksheet.Cells[2, 6] = fileNumbersList[20];
            worksheet.Cells[3, 6] = fileNumbersList[21];
            worksheet.Cells[4, 6] = fileNumbersList[22];
            worksheet.Cells[5, 6] = fileNumbersList[23];
            worksheet.Cells[6, 6] = fileNumbersList[24];

            //Gemmer det vi lige har gjort og lukker vores projekt
            workbook.SaveAs(pathname, Excel.XlFileFormat.xlOpenXMLWorkbook, null, null, false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, null, null, null);
        }
    }
}