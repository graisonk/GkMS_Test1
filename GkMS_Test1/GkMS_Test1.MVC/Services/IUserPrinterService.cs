using GkMS_Test1.MVC.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GkMS_Test1.MVC.Services
{
    public interface IUserPrinterService
    {
        Task LinkUserPrinter(UserPrinterDto userPrinterDto);
    }
}
