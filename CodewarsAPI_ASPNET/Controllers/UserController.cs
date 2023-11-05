﻿using System;
using CodewarsAPI_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodewarsAPI_ASPNET.Controllers
{
    public class UserController : Controller
    {
        private readonly IApiRepo _repo;

        public UserController(IApiRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string username)
        {
            var userObj = new User();

            if (username == null)
                return View(userObj);

            // wrap in try-catch after exception found
            var Json = _repo.CallApi(username).Result;

            if (Json == "incorrect")
            {
                userObj.IncorrectUsername = true;
                return View(userObj);
            }    

            userObj = _repo.DeserializeJson(Json);

            userObj.JSON = Json;

            return View(userObj);
        }

        public IActionResult ViewAllGroups()
        {
            IEnumerable<Group> groupObj = new List<Group>();

            // read all files from csv folder
            // create groups for each file
            // create list of groups; store in groupObj

            return View(groupObj);
        }
    }
}

