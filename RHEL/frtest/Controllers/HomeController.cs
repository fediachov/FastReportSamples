using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using frtest.Models;
using FastReport;
using FastReport.Web;
using FastReport.Utils;
using FastReport.Export.Pdf;

namespace frtest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = new HomeModel();
        model.WebReport = new WebReport();
        model.WebReport.Report.Load(Path.Combine("Reports", "Text.frx"));
        model.WebReport.Width = "100%";
        model.WebReport.Height = "800";
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
