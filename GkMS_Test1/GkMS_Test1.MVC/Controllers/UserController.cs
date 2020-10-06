using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GkMS_Test1.MVC.Models;
using GkMS_Test1.MVC.Services;
using GkMS_Test1.Users.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GkMS_Test1.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserPrinterService _userPrinterService;

        public UserController(IUserPrinterService userPrinterService)
        {
            _userPrinterService = userPrinterService;
        }
        // GET: UserController
        public async Task<IActionResult> Index()
        {
            List<User> users = await _userPrinterService.GetUsers();
            return View(users);
        }

        // GET: UserController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            UserProfileVM model = await _userPrinterService.GetUser(id);
            return View(model);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserProfileVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {                    
                    await _userPrinterService.AddUser(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            UserProfileVM model = await _userPrinterService.GetUser(id);
            return View(model);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserProfileVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userPrinterService.UpdUser(id, model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(model);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userPrinterService.DelUser(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
