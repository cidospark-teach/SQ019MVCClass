using Microsoft.AspNetCore.Mvc;
using UMSProj.Data;
using UMSProj.Models.Entity;
using UMSProj.Models.ViewModels;

namespace UMSProj.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(UserToAdd model)
        {
            // validate model

            // map date from viewmodel to entity
            var user = new User
            {
                Id = Context.Users.Count + 1,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
            };

            Context.Users.Add(user);

            // redirect to homepage on successful addition
            return RedirectToAction("Index", "Home");
        }
    }
}

/*
    GET,
    POST,
    PUT,
    PATCH,
    DELETE
 */ 