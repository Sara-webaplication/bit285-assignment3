using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bit285_assignment3_api.Models;
using bit285_assignment3_api.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bit285_assignment3_api.Controllers
{
    public class LoginController : Controller
    {
        private BitDataContext _dbc;
        /*
         * Constructor
         */
        public LoginController(BitDataContext dbc)
        {
            _dbc = dbc;
        }


        [HttpGet]
        public IActionResult Index(long id)
        {
            //Set the view to display the username if the given id matches a user
            if(id != 0)
            {
                User user = _dbc.Users.Find(id);
                if (user != null)
                {
                    Login login = new Login()
                    {
                        UserName = user.EmailAddress
                    };
                    return View(login);
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(Login login)
        { 
            //First check if the form values are valid
            if (!ModelState.IsValid) { return View(); }

            //Second check if the user credentials are correct
            if (_dbc.Users.Any<User>(u => u.EmailAddress == login.UserName && u.Password == login.Password))
            {
                return RedirectToAction("Welcome");
            }
            else //go back to an empty view to try again
            {
                ViewBag.LoginIssue = "There is a problem with your username or password.";
                return View();
            }
        }


        [HttpGet]
        public IActionResult Welcome()
        {
            IEnumerable<User> users = _dbc.Users.OrderBy(u => u.Program).ToList<User>();
            return View(users);
        }
    }
}
