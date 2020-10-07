using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GkMS_Test1.Printers.Application.Interfaces;
using GkMS_Test1.Printers.Domain.Models;
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

        [HttpGet("{id}")]
        public ActionResult<Printer> Get(int id)
        {
            return Ok(_printerService.GetPrinter(id));
        }

        [HttpPut("{id}")]
        public void PutPrinter(int id, Printer printer)
        {
            _printerService.ModPrinter(id, printer);            
        }

        [HttpDelete("{id}")]
        public void DeletePrinter(int id)
        {
            _printerService.DelPrinter(id);
        }

    }
}
