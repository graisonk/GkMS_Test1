using GkMS_Test1.MVC.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GkMS_Test1.MVC.Services
{
    public class UserPrinterService : IUserPrinterService
    {
        private readonly HttpClient _apiCLient;

        public UserPrinterService(HttpClient apiCLient)
        {
            _apiCLient = apiCLient;
        }
        public async Task LinkUserPrinter(UserPrinterDto userPrinterDto)
        {
            var uri = "https://localhost:5001/api/User";
            var transferObj = new StringContent(JsonConvert.SerializeObject(userPrinterDto), System.Text.Encoding.UTF8, "application/json");
            var response = await _apiCLient.PostAsync(uri, transferObj);
            response.EnsureSuccessStatusCode();
        }
    }
}
