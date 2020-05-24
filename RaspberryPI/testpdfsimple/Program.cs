using System;
using FastReport;
using FastReport.Export.PdfSimple;
using FastReport.Utils;

namespace testpdfsimple
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Test FastReport Open Source");
            
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
            using PDFSimpleExport pdf = new PDFSimpleExport();
            report.Export(pdf, "file.pdf");
        }
    }
}
