using System;
using System.Net;
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

        public IActionResult Versus(VsGroup versus)
        {
            versus.FileNameA = WebUtility.UrlDecode(versus.FileNameA);
            versus.FileNameB = WebUtility.UrlDecode(versus.FileNameB);

            var groupA = new Group();
            var groupB = new Group();

            var tempList = new List<User>();

            var userNames = _csvRepo.ReadCsv(versus.FileNameA);

            foreach (var user in userNames)
            {
                tempList.Add(_apiRepo.DeserializeJson(_apiRepo.CallApi(user).Result));
            }

            versus.GroupA = new Group(versus.FileNameA, tempList.OrderByDescending(x => x.Honor).ToList());

            tempList.Clear();

            userNames = _csvRepo.ReadCsv(versus.FileNameB);

            foreach (var user in userNames)
            {
                tempList.Add(_apiRepo.DeserializeJson(_apiRepo.CallApi(user).Result));
            }

            versus.GroupB = new Group(versus.FileNameB, tempList.OrderByDescending(x => x.Honor).ToList());

            return View(versus);
        }

        public IActionResult VersusNext(string fileName)
        {
            fileName = WebUtility.UrlDecode(fileName);

            var tempList = new List<User>();

            var userNames = _csvRepo.ReadCsv(fileName);

            foreach (var user in userNames)
            {
                tempList.Add(_apiRepo.DeserializeJson(_apiRepo.CallApi(user).Result));
            }

            var groupObj = new Group(fileName, tempList.OrderByDescending(x => x.Honor).ToList());

            var tempList2 = new List<string>();

            tempList2 = _csvRepo.RetrieveCsvFileNames().ToList();

            tempList2.Remove(fileName);

            groupObj.FileNames = tempList2;

            return View(groupObj);
        }

        public IActionResult VersusStart()
        {
            IEnumerable<string> groupList = new List<string>();

            groupList = _csvRepo.RetrieveCsvFileNames();

            return View(groupList);
        }

        public IActionResult ViewAllGroups()
        {
            IEnumerable<string> groupList = new List<string>();

            groupList = _csvRepo.RetrieveCsvFileNames();

            return View(groupList);
        }
                
        public IActionResult ViewGroup(string fileName)
        {
            // from ChatGPT: decodes fileName from Razor page
            fileName = WebUtility.UrlDecode(fileName);

            var tempList = new List<User>();

            var userNames = _csvRepo.ReadCsv(fileName);

            foreach (var user in userNames)
            {
                tempList.Add(_apiRepo.DeserializeJson(_apiRepo.CallApi(user).Result));
            }

            var groupObj = new Group(fileName, tempList.OrderByDescending(x => x.Honor).ToList());

            return View(groupObj);
        }
    }
}

