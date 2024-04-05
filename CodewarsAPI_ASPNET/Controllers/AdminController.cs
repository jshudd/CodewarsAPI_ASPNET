using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodewarsAPI_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}

