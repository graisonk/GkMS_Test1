using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GkMS_Test1.MVC.Services;
using GkMS_Test1.Printers.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GkMS_Test1.MVC.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IUserPrinterService _userPrinterService;

        public DeviceController(IUserPrinterService userPrinterService)
        {
            _userPrinterService = userPrinterService;

        }
        // GET: DeviceController
        public async Task<IActionResult> Index()
        {
            List<Printer> printers = await _userPrinterService.GetPrinters();
            return View(printers);
        }

        // GET: DeviceController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Printer printer = await _userPrinterService.GetPrinter(id);
            return View(printer);
        }

        // GET: DeviceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeviceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeviceController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Printer printer = await _userPrinterService.GetPrinter(id);
            return View(printer);
        }

        // POST: DeviceController/Edit/5
        //[HttpPut("{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Printer printer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userPrinterService.UpdPrinter(id, printer);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(printer);
        }
                
        // POST: DeviceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userPrinterService.DelPrinter(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
