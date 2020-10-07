using GkMS_Test1.MVC.Models;
using GkMS_Test1.MVC.Models.DTO;
using GkMS_Test1.Printers.Domain.Models;
using GkMS_Test1.Users.Domain.Models;
using GkMS_Test1.Users.Domain.ViewModels;
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

        public async Task<Printer> GetPrinter(int id)
        {
            var uri = "https://localhost:5003/api/Printer/" + id;
            Printer printer = new Printer();
            HttpResponseMessage response = await _apiCLient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsStringAsync().Result;
                printer = JsonConvert.DeserializeObject<Printer>(readTask);
            }
            return printer;
        }

        public async Task<List<Printer>> GetPrinters()
        {
            var uri = "https://localhost:5003/api/Printer";
            List<Printer> printerList = new List<Printer>();
            HttpResponseMessage response = await _apiCLient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsStringAsync().Result;
                printerList = JsonConvert.DeserializeObject<List<Printer>>(readTask);
            }
            return printerList;
        }

        public async Task LinkUserPrinter(UserPrinterDto userPrinterDto)
        {
            var uri = "https://localhost:5001/api/User";
            var transferObj = new StringContent(JsonConvert.SerializeObject(userPrinterDto), System.Text.Encoding.UTF8, "application/json");
            var response = await _apiCLient.PostAsync(uri, transferObj);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdPrinter(int id, Printer printer)
        {
            var uri = "https://localhost:5003/api/Printer/" + id;
            var transferObj = new StringContent(JsonConvert.SerializeObject(printer), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _apiCLient.PutAsync(uri, transferObj);
            response.EnsureSuccessStatusCode();
        }
        public async Task DelPrinter(int id)
        {
            var uri = "https://localhost:5003/api/Printer/" + id;
            HttpResponseMessage response = await _apiCLient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddPrinter(Printer printer)
        {
            var uri = "https://localhost:5003/api/Printer";
            var transferObj = new StringContent(JsonConvert.SerializeObject(printer), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _apiCLient.PostAsync(uri, transferObj);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<User>> GetUsers()
        {
            var uri = "https://localhost:5001/api/User";
            List<User> userList = new List<User>();
            HttpResponseMessage response = await _apiCLient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsStringAsync().Result;
                userList = JsonConvert.DeserializeObject<List<User>>(readTask);
            }
            return userList;
        }

        public async Task<UserProfileVM> GetUser(int id)
        {
            var uri = "https://localhost:5001/api/User/" + id;
            UserVM uservm = new UserVM();
            HttpResponseMessage response = await _apiCLient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsStringAsync().Result;
                uservm = JsonConvert.DeserializeObject<UserVM>(readTask);
            }

            //List<UserPrinter> devices = new List<UserPrinter>();
            string tmp = "userid=" + id;
            List<UserPrinter> devices = await GetUserDevices(tmp);
            if (devices == null)
            {
                devices = new List<UserPrinter>();
            }
            UserProfileVM model = new UserProfileVM() { User = uservm.User, Personal = uservm.Personal, UserPrinters = devices };
            return model;
        }

        public async Task AddUser(UserProfileVM model)
        {
            UserVM userVM = new UserVM() { User = model.User, Personal = model.Personal };
            var uri = "https://localhost:5001/api/User";
            var transferObj = new StringContent(JsonConvert.SerializeObject(userVM), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _apiCLient.PostAsync(uri, transferObj);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdUser(int id, UserProfileVM model)
        {
            UserVM userVM = new UserVM() { User = model.User, Personal = model.Personal };
            var uri = "https://localhost:5001/api/User/" + id;
            var transferObj = new StringContent(JsonConvert.SerializeObject(userVM), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _apiCLient.PutAsync(uri, transferObj);
            response.EnsureSuccessStatusCode();
        }

        public async Task DelUser(int id)
        {
            var uri = "https://localhost:5001/api/User/" + id;
            HttpResponseMessage response = await _apiCLient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<UserPrinter>> GetUserDevices(string userid)
        {
            var uri = "https://localhost:5003/api/Printer/" + userid;
            List<UserPrinter> userDevices = new List<UserPrinter>();
            HttpResponseMessage response = await _apiCLient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsStringAsync().Result;
                userDevices = JsonConvert.DeserializeObject<List<UserPrinter>>(readTask);
            }
            return userDevices;
        }
    }
}
