

using GkMS_Test1.MVC.Models;
using GkMS_Test1.MVC.Models.DTO;
using GkMS_Test1.Printers.Domain.Models;
using GkMS_Test1.Printers.Domain.ViewModels;
using GkMS_Test1.Users.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GkMS_Test1.MVC.Services
{
    public interface IUserPrinterService
    {
        Task<List<User>> GetUsers();
        Task<UserProfileVM> GetUser(int id);
        Task AddUser(UserProfileVM user);
        Task UpdUser(int id, UserProfileVM user);
        Task DelUser(int id);

        Task<List<Printer>> GetPrinters();
        Task<PrinterSlabVM> GetPrinter(int id);
        Task AddPrinter(PrinterSlabVM printer);
        Task UpdPrinter(int id, PrinterSlabVM printer);
        Task DelPrinter(int id);

        Task LinkUserPrinter(UserPrinterDto userPrinterDto);
        Task UpdRefUsers(User userProfile);
        Task<List<UserPrinter>> GetUserDevices(string userid);
    }
}
