using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GkMS_Test1.Invoice.Domain.Models;
using GkMS_Test1.MVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GkMS_Test1.MVC.Controllers
{
    public class InvController : Controller
    {
        private readonly IUserPrinterService _userPrinterService;

        public InvController(IUserPrinterService userPrinterService)
        {
            _userPrinterService = userPrinterService;
        }
        // GET: InvController
        public async Task<IActionResult> Index()
        {
            List<Invoices> invs = await _userPrinterService.GetInvoices();
            return View(invs);
        }

        // GET: InvController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Invoices inv = await _userPrinterService.GetInvoice(id);
            return View(inv);
        }

        // GET: InvController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Invoices inv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userPrinterService.AddInvoice(inv);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: InvController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Invoices inv = await _userPrinterService.GetInvoice(id);
            return View(inv);
        }

        // POST: InvController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Invoices inv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userPrinterService.UpdInvoice(id, inv);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(inv);
        }
        
        // POST: InvController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userPrinterService.DelInvoice(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<JsonResult> GetRates(int custId, int ptrId)
        {
            string pattern = custId + "|" + ptrId;
            List<Ref_PrinterRates> rateList = await _userPrinterService.GetRates(pattern);

            //var calcResult = new { rateList };
            return Json(rateList);
            //return Json(calcResult);
        }
    }
}
