using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;

namespace MeetingApp.Controllers
{
    public class MeetingController : Controller
    {
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                Repository.CreateUser(userInfo);
                ViewBag.UserCount = Repository.Users.Where(u => u.WillAttend).Count();
                return View("Thanks", userInfo);
            }

            else 
            {
                return View(userInfo);
            }

        }

        public IActionResult List()
        {
            var users = Repository._users;
            int attendeeCount = users.Count(u => u.WillAttend == true);
            ViewBag.AttendeeCount = attendeeCount;
            return View(users);
        }

        public IActionResult Details(int id)
        {
            return View(Repository.GetById(id));
        }
    }
}
