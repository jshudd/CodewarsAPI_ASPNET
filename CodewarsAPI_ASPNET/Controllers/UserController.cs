using System;
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
            userObj.JSON = _repo.CallApi(username).Result;

            userObj = _repo.DeserializeJson(userObj);

            return View(userObj);
        }
    }
}

