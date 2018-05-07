using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    public class FileExporter
    {

        public void ExportToPDF(string memberNumber, string name, string goal, string trainingProgram, string weeklyTrainings, string timePerTraining, string notes)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            XFont font_Headline = new XFont("Verdana", 35, XFontStyle.Bold);



            // Draw the text
            gfx.DrawString("Træningsforløb for " + memberNumber + "\n", font_Headline, XBrushes.Blue,
              new XRect(0, 0, page.Width, page.Height),
              XStringFormats.TopCenter);

            gfx.DrawString(name, font, XBrushes.Black,
              new XRect(0, 50, page.Width, page.Height),
              XStringFormats.TopLeft);
            gfx.DrawString("Formål: " + goal, font, XBrushes.Black,
              new XRect(0, 100, page.Width, page.Height),
              XStringFormats.TopLeft);

            gfx.DrawString("Ønsket træningsprogram: " + trainingProgram, font, XBrushes.Black,
              new XRect(0, 150, page.Width, page.Height),
              XStringFormats.TopLeft);

            gfx.DrawString("Antal træninger pr. uge: " + weeklyTrainings, font, XBrushes.Black,
              new XRect(0, 200, page.Width, page.Height),
              XStringFormats.TopLeft);

            gfx.DrawString("Varighed pr. træning" + timePerTraining, font, XBrushes.Black,
              new XRect(0, 250, page.Width, page.Height),
              XStringFormats.TopLeft);
            gfx.DrawString("Evt. noter: " + notes, font, XBrushes.Black,
              new XRect(0, 300, page.Width, page.Height),
              XStringFormats.TopLeft);

            // Save the document...
            string filename = memberNumber + ".pdf";
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }

    }
}