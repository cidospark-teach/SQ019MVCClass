using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UMSProj.Data;
using UMSProj.Models;
using UMSProj.Models.ViewModels;

namespace UMSProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = Context.Users;
            var usersToReturn = new List<UserToReturn>();
            if(users != null && users.Any())
            {
                usersToReturn = users.Select(x => new UserToReturn
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                }).ToList();
            }

            return View(usersToReturn);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}