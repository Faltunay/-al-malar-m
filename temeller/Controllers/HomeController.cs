using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using temeller.Models;

namespace temeller.Controllers;

public class HomeController : Controller
{
     public IActionResult Contact()
    {
        return View();
    }

   public IActionResult index()
    {
        return View(Repository.Courses);
    }   
}
