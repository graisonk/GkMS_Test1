﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GkMS_Test1.Printers.Application.Interfaces;
using GkMS_Test1.Printers.Domain.Models;
using GkMS_Test1.Printers.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GkMS_Test1.Printers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrinterController : ControllerBase
    {
        private readonly IPrinterService _printerService;

        public PrinterController(IPrinterService printerService)
        {
            _printerService = printerService;
        }
                
        [HttpGet]
        public ActionResult<IEnumerable<Printer>> Get()
        {
            return Ok(_printerService.GetPrinters());
        }

        //[Route("{id:int}")]
        [HttpGet("{id:int}")]
        public ActionResult<PrinterSlabVM> Get(int id)
        {
            return Ok(_printerService.GetPrinter(id));
        }

        //[Route("{name}")]
        [HttpGet("{userid}")]
        public ActionResult<UserPrinter> GetUserDevices(string userid)
        {
            return Ok(_printerService.GetUserPrinters(userid));
        }

        [HttpPut("{id}")]
        public void PutPrinter(int id, PrinterSlabVM printer)
        {
            _printerService.ModPrinter(id, printer);            
        }

        [HttpDelete("{id}")]
        public void DeletePrinter(int id)
        {
            _printerService.DelPrinter(id);
        }

        [HttpPost]
        public void PostPrinter(PrinterSlabVM printer)
        {
            _printerService.AddPrinter(printer);
        }

        [HttpPost("{tmpName}")]
        public void UpdrefRates(string tmpName, [FromBody] PrinterRates rates)
        {
            _printerService.UpdateRefRates(rates);
        }
    }
}
