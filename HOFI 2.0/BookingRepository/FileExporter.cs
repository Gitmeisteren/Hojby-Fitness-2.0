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

        public void CreateJournal(Booking booking, Member member, BookingJournal bookingJournal)
        {

            string _Folderpath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string _PrimaryFoldername = _Folderpath + "\\HOFI";
            string _SessionFoldername = _PrimaryFoldername + "\\Forløb";
            string _MemberNumberFoldername = _SessionFoldername + "\\" + booking.MemberNumber;
            string _GoalFoldername = _MemberNumberFoldername + "\\" + bookingJournal.Goal;
            Directory.CreateDirectory(_GoalFoldername);
              
            //Creates application
            Application _ObjWord = new Application();

            _ObjWord.Visible = true;
            _ObjWord.WindowState = WdWindowState.wdWindowStateNormal;

            //Creates document
            Document _ObjDoc = _ObjWord.Documents.Add();

            //Adds paragraphs
            Paragraph _ObjParagraph;
            _ObjParagraph = _ObjDoc.Paragraphs.Add();
            _ObjParagraph.Range.Text =
                "Træningsprogram for " + booking.MemberNumber + "\n"
                + "Navn: " + member.Name + "\n"
                + "Formål: " + bookingJournal.Goal + "\n"
                + "Træningsprogram: " + bookingJournal.TrainingProgram + "\n"
                + "Antal træninger om ugen: " + bookingJournal.WeeklyTrainings + "\n"
                + "Varighed pr. træning: " + bookingJournal.TimePerTraining + "\n"
                + "Noter: " + bookingJournal.Notes + "\n";

            _ObjDoc.SaveAs2(_GoalFoldername + "\\" + bookingJournal.Goal);
            _ObjDoc.Close();
            _ObjWord.Quit();
        }
        
        public void UpdateStatisticToExcel(List<int> fileNumbersList)
        {
            string _Folderpath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string _PrimaryFoldername = _Folderpath + "\\HOFI";
            string _StatisticFoldername = _PrimaryFoldername + "\\Statistik";

            Directory.CreateDirectory(_StatisticFoldername);
            
            string _Filename = "Statistik.csv";
            string _Pathname = Path.Combine(_StatisticFoldername, _Filename);
            using (StreamWriter sw = File.CreateText(_Pathname))
            {
            }
            Excel.Application _ExcelAppObj = new Excel.Application();
            _ExcelAppObj.DisplayAlerts = false;
            Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            

            //Åbner den et excelprojekt (En "Workbook")
            Excel.Workbook _Workbook = _ExcelAppObj.Workbooks.Open(_Pathname, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false);

            //Åbner den første side i excelprojektet
            Excel.Worksheet _Worksheet = (Excel.Worksheet)_Workbook.Worksheets.get_Item(1);

            //Test! Skriver 20 i en bestemt celle
            _Worksheet.Cells[2, 1] = "Styrketræning";
            _Worksheet.Cells[3, 1] = "Vægttab";
            _Worksheet.Cells[4, 1] = "Opstramning";
            _Worksheet.Cells[5, 1] = "Konditionstræning";
            _Worksheet.Cells[6, 1] = "Kom-Godt-Igang";

            _Worksheet.Cells[1, 2] = "18-25";
            _Worksheet.Cells[1, 3] = "26-35";
            _Worksheet.Cells[1, 4] = "36-45";
            _Worksheet.Cells[1, 5] = "46-55";
            _Worksheet.Cells[1, 6] = "55+";

            _Worksheet.Cells[2, 2] = fileNumbersList[0];
            _Worksheet.Cells[3, 2] = fileNumbersList[1];
            _Worksheet.Cells[4, 2] = fileNumbersList[2];
            _Worksheet.Cells[5, 2] = fileNumbersList[3];
            _Worksheet.Cells[6, 2] = fileNumbersList[4];

            _Worksheet.Cells[2, 3] = fileNumbersList[5];
            _Worksheet.Cells[3, 3] = fileNumbersList[6];
            _Worksheet.Cells[4, 3] = fileNumbersList[7];
            _Worksheet.Cells[5, 3] = fileNumbersList[8];
            _Worksheet.Cells[6, 3] = fileNumbersList[9];

            _Worksheet.Cells[2, 4] = fileNumbersList[10];
            _Worksheet.Cells[3, 4] = fileNumbersList[11];
            _Worksheet.Cells[4, 4] = fileNumbersList[12];
            _Worksheet.Cells[5, 4] = fileNumbersList[13];
            _Worksheet.Cells[6, 4] = fileNumbersList[14];

            _Worksheet.Cells[2, 5] = fileNumbersList[15];
            _Worksheet.Cells[3, 5] = fileNumbersList[16];
            _Worksheet.Cells[4, 5] = fileNumbersList[17];
            _Worksheet.Cells[5, 5] = fileNumbersList[18];
            _Worksheet.Cells[6, 5] = fileNumbersList[19];

            _Worksheet.Cells[2, 6] = fileNumbersList[20];
            _Worksheet.Cells[3, 6] = fileNumbersList[21];
            _Worksheet.Cells[4, 6] = fileNumbersList[22];
            _Worksheet.Cells[5, 6] = fileNumbersList[23];
            _Worksheet.Cells[6, 6] = fileNumbersList[24];

            //Gemmer det vi lige har gjort og lukker vores projekt
            _Workbook.SaveAs(_Pathname, Excel.XlFileFormat.xlOpenXMLWorkbook, null, null, false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, null, null, null);

            _Workbook.Close();
        }
    }
}