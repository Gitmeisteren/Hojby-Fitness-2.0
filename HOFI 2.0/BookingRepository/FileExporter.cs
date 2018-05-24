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


namespace Model
{
    public class FileExporter
    {

        public void ExportToWord(Booking booking, Member member, string goal, string trainingProgram, string weeklyTrainings, string timePerTraining, string notes)
        {

            string root = @"C:\Users\royga\Documents\" + booking.MemberNumber + ".docx";
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

    }
}