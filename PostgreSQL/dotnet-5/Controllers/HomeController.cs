using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using core.Models;
using FastReport;
using FastReport.Web;

using System.IO;

namespace core.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new HomeModel();
            model.WebReport = new WebReport();
            model.WebReport.Report.Load(Path.Combine("Reports", "postgres.frx"));
            model.WebReport.DesignerLocale = "ru";
            model.WebReport.Width = "100%";
            model.WebReport.Height = "800";
            // model.WebReport.Mode = WebReportMode.Designer;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
