﻿using System;
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
            var Json = _apiRepo.CallApi(username).Result;

            if (Json == "incorrect")
            {
                userObj.IncorrectUsername = true;
                return View(userObj);
            }    

            userObj = _apiRepo.DeserializeJson(Json);

            userObj.JSON = Json;

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
            throw new NotImplementedException();

            //var groupList = new List<User>();

            // read csv file with filename

            // retrieve usernames from file; return as list
            //var usernames;

            // foreach usernames contact api
            //foreach (var user in userNames)
            //{
            //    groupList.Add(_apiRepo.CallApi(user));
            //}
        }
    }
}

