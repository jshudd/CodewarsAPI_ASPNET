using System;
using CodewarsAPI_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodewarsAPI_ASPNET.Controllers
{
    public class UserController : Controller
    {
        private readonly IApiRepo _apiRepo;
        private readonly ICsvRepo _csvRepo;

        public UserController(IApiRepo apiRepo, ICsvRepo csvRepo)
        {
            _apiRepo = apiRepo;
            _csvRepo = csvRepo;
        }

        public IActionResult Index(string username)
        {
            var userObj = new User();

            if (username == null)
                return View(userObj);

            // wrap in try-catch after exception found
            var json = _apiRepo.CallApi(username).Result;

            if (json == "incorrect")
            {
                userObj.IncorrectUsername = true;
                return View(userObj);
            }    

            userObj = _apiRepo.DeserializeJson(json);

            userObj.JSON = json;

            return View(userObj);
        }

        public IActionResult ViewAllGroups()
        {
            IEnumerable<string> groupList = new List<string>();

            groupList = _csvRepo.RetrieveCsvFileNames();

            return View(groupList);
        }

        public IActionResult ViewGroup(string fileName)
        {
            var groupList = new List<User>();

            var userNames = _csvRepo.ReadCsv(fileName);

            foreach (var user in userNames)
            {
                groupList.Add(_apiRepo.DeserializeJson(_apiRepo.CallApi(user).Result));
            }

            return View(groupList);
        }
    }
}

