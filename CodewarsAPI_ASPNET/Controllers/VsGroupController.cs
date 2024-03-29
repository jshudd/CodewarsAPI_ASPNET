using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CodewarsAPI_ASPNET.Models;
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

        public Group GetGroup(string fileName)
        {
            fileName = WebUtility.UrlDecode(fileName);

            var tempList = new List<User>();

            var userNames = _csvRepo.ReadCsv(fileName);

            foreach (var user in userNames)
            {
                tempList.Add(_apiRepo.DeserializeJson(_apiRepo.CallApi(user).Result));
            }

            var groupObj = new Group(fileName, tempList.OrderByDescending(x => x.Honor).ToList());

            return groupObj;
        }
    }
}

