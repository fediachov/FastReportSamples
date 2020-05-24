using System;
using FastReport;
using FastReport.Export.Pdf;
using FastReport.Utils;

namespace testpdf
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Test FastReport Core");
            
	    // create report object
            using Report report = new Report();
	    // create page
            using ReportPage page = new ReportPage();
 	    // add page into report 
            report.Pages.Add(page);

	    // create band
            page.ReportTitle = new ReportTitleBand()
            {
                Height = Units.Centimeters * 10
            };

	    // create text object placed on band
            using TextObject text = new TextObject()
            {
                Left = Units.Centimeters * 7,
                Top = Units.Centimeters * 5,
                Font = new System.Drawing.Font("DejaVu Sans", 24),
                CanGrow = true,
                AutoWidth = true,
                Text = "Hello Raspberry!",
                Parent = page.ReportTitle
            };

	    // make the document
            report.Prepare();
            
            // save the document as PDF file 
            using PDFExport pdf = new PDFExport();
            report.Export(pdf, "file.pdf");
        }
    }
}
