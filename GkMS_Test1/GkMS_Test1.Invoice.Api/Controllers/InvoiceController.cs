using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GkMS_Test1.Invoice.Application.Interfaces;
using GkMS_Test1.Invoice.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GkMS_Test1.Invoice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        // GET: api/<InvoiceController>
        [HttpGet]
        public ActionResult<IEnumerable<Invoices>> Get()
        {
            return Ok(_invoiceService.GetInvoices());
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id:int}")]
        public ActionResult<Invoices> Get(int id)
        {
            return Ok(_invoiceService.GetInvoice(id));
        }

        [HttpGet("{pattern}")]
        public ActionResult<List<Ref_PrinterRates>> Get(string pattern)
        {
            string[] asd = { "" };
            asd = pattern.Split('|');
            int uid = Convert.ToInt32(asd[0]);
            int pid = Convert.ToInt32(asd[1]);
            return Ok(_invoiceService.PrinterRates(uid, pid));
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public void Post([FromBody] Invoices Inv )
        {
            _invoiceService.AddInvoice(Inv);
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Invoices Inv)
        {
            _invoiceService.ModInvoice(id, Inv);
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _invoiceService.DelInvoice(id);
        }
    }
}
