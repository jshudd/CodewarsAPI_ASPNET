using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodewarsAPI_ASPNET.Controllers
{
    public class VsGroupController : Controller
    {
        private readonly IApiRepo _apiRepo;
        private readonly ICsvRepo _csvRepo;

        public VsGroupController(IApiRepo apiRepo, ICsvRepo csvRepo)
        {
            _apiRepo = apiRepo;
            _csvRepo = csvRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<string> groupList = new List<string>();

            groupList = _csvRepo.RetrieveCsvFileNames();

            return View(groupList);
        }

        public IActionResult Versus(string fileNameA, string fileNameB)
        {


            return View();
        }
    }
}

