using GraphAppPermissionsMvcDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Identity.Web;

namespace GraphAppPermissionsMvcDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GraphServiceClient _graphServiceClient;

        public HomeController(
            ILogger<HomeController> logger, GraphServiceClient graphServiceClient)
        {
            _logger = logger;
            _graphServiceClient = graphServiceClient;
        }

        public async Task<IActionResult> Index()
        {
            var topFiveGroups = await _graphServiceClient.Groups.Request().Top(5).GetAsync();

            // or if using DelegatedPermissions in Startup, but wanna call here with App:
            //var topFiveGroups = await _graphServiceClient.Groups.Request().WithAppOnly().Top(5).GetAsync();

            var result = topFiveGroups.Select(g => new GroupModel {Id = g.Id, DisplayName = g.DisplayName});

            return View(result);
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
