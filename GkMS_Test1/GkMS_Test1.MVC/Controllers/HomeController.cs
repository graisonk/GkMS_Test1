using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GkMS_Test1.MVC.Models;
using GkMS_Test1.MVC.Models.DTO;
using GkMS_Test1.MVC.Services;

namespace GkMS_Test1.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserPrinterService _userPrinterService;

        public HomeController(ILogger<HomeController> logger, IUserPrinterService userPrinterService)
        {
            _logger = logger;
            _userPrinterService = userPrinterService;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public async Task<IActionResult> LinkDevice(UserPrinterVM model)
        {
            UserPrinterDto deviceDto = new UserPrinterDto()
            {
                UserId = model.UserId,
                PrinterId = model.PrinterId,
                IsAssigned = model.IsAssigned
            };

            await _userPrinterService.LinkUserPrinter(deviceDto);

            return View("Index");
        }
    }
}
