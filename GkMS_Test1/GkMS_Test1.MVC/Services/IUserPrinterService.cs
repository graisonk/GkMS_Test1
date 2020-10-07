using GkMS_Test1.MVC.Models.DTO;
using GkMS_Test1.Printers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GkMS_Test1.MVC.Services
{
    public interface IUserPrinterService
    {
        Task<List<Printer>> GetPrinters();
        Task<Printer> GetPrinter(int id);

        Task UpdPrinter(int id, Printer printer);
        Task DelPrinter(int id);
        Task LinkUserPrinter(UserPrinterDto userPrinterDto);
    }
}
