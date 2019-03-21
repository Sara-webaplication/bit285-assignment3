using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bit285_assignment3_api.Models;
using bit285_assignment3_api.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace bit285_assignment3_api.Controllers
{
    public class NapsController : Controller
    {
        private BitDataContext _dbc;
        /*
         * Constructor
         */
         public NapsController(BitDataContext dbc)
        {
            _dbc = dbc;
        }

        /* 
         * 1) Account Info 
        */
        public IActionResult AccountInfo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AccountInfo(User user)
        {
            //Add User information to the database
            _dbc.Users.Add(user);
            _dbc.SaveChanges();

            return RedirectToAction("PasswordInfo", new { id=user.Id});
        }
        /* 
         * 2) Password Info 
        */
        [HttpGet]
        public IActionResult PasswordInfo(long id)
        {
            //Get the User information from the db
            User dbUser = _dbc.Users.Single(u=>u.Id==id);
            //Create a new PasswordInfo object
            PasswordInfo passwordInfo = new PasswordInfo
            {
                Id = dbUser.Id,
                LastName = dbUser.LastName
            };

             return View(passwordInfo);
        }
        [HttpPost]
        public IActionResult PasswordInfo(PasswordInfo info)
        {
            return RedirectToAction("SelectPassword", info);
        }
        /* 
         * 3) Select Password  
        */
        [HttpGet]
        public IActionResult SelectPassword(PasswordInfo info)
        {
            return View(info);
        }
        [HttpPost]
        public IActionResult SelectPassword(long id, PasswordInfo info)
        {
            //PasswordInfo ViewModel includes the UserId, get the User
            User dbUser = _dbc.Users.Single(u=>u.Id == id);

            //Update the user password from the form
            dbUser.Password = info.Password;
            _dbc.SaveChanges();

            return RedirectToAction("ConfirmAccount", dbUser);
        }
        /* 
         * 4) Confirm Account 
        */
        [HttpGet]
        public IActionResult ConfirmAccount(User user)
        {
            return View(user);
        }

    }
}
