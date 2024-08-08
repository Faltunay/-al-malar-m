using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;

namespace MeetingApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        int UserCount = Repository.Users.Where(u => u.WillAttend).Count();
        var meetingInfo = new MeetingInfo()
        {
            Id = 1,
            Location = "İstanbul ABC Kongre Merkezi",
            Date = new DateTime(2024, 1, 20, 20, 00, 00),
            NumberOfPeople = UserCount
        };
        return View(meetingInfo);
    }

}
