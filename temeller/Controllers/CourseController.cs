using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using temeller.Models;

namespace temeller.Controllers
{
     public class CourseController : Controller
    {
        public IActionResult List()
        {

            return View("CourseList", Repository.Courses);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("/course/list");
            }

            var kurs = Repository.GetById(id.Value);
            return View(kurs);
        }
    }
}
