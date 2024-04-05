using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodewarsAPI_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CodewarsAPI_ASPNET.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var adminObj = new Admin();
            return View(adminObj);
        }

        public IActionResult Settings(Admin adminObj)
        {
            var jsonFilePath = "/appsettings.json";
            var jsonString = System.IO.File.ReadAllText(jsonFilePath);
            List<Admin>? admins = JsonSerializer.Deserialize<List<Admin>>(jsonString);

            foreach (var user in admins)
            {
                if (user.UserName == adminObj.UserName)
                {
                    if(user.PW == adminObj.PW)
                    {
                        adminObj.IsCorrectPW = true;
                        return View(adminObj);
                    }
                }
            }

            return RedirectToAction("Index", "User");
        }
    }
}

