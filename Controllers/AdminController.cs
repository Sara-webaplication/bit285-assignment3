using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bit285_assignment3_api.Models;
using bit285_assignment3_api.Controllers;
using bit285_assignment3_api.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bit285_assignment3_api.Controllers
{
    public class AdminController : Controller

    {
        private BitDataContext _bdc;

        public AdminController(BitDataContext dbContext)

        {
            _bdc = dbContext;
        }

        // GET: /<controller>/
     
        
        public IActionResult Index()
        {
            UserAdmin UA = new UserAdmin();
            UA.Users = _bdc.Users.ToList<User>();
            return View(UA);
        }


        [HttpPost]
        public IActionResult Index(UserAdmin newUser)
        {


            if (newUser.FullName != null)
            {
                newUser.Users = _bdc.Users.Where(u => u.FullName.Contains(newUser.FullName));
            }
            else
            {
                newUser.Users = _bdc.Users;
            }

            return View(newUser);
        }




        [HttpGet]
        public IActionResult CreateUser()
        {
            return View("EditUser");
        }




        [HttpGet]
        public IActionResult UpdateUser(long id)
        {
            User user = _bdc.Users.Single(u => u.Id == id);
            return View("EditUser", user);
        }




        [HttpPost]
        public IActionResult EditUser(User user)
        {
            if(user.Id == 0)

            {
                _bdc.Add(user);
            }
            else
            {
                _bdc.Update(user);
            }

            _bdc.SaveChanges();
            return RedirectToAction("Index");

        }


        /// <DELETE>

        [HttpGet]
        public IActionResult RemoveUser(long id)
        {
            //Remove the user associated with the given id number; Save Changes
            User user = new User { Id = id };
            _bdc.Remove(user);
            _bdc.SaveChanges();

            return RedirectToAction("Index");
        }




        [HttpGet]
        public IActionResult UserActivities(long id)
        {
            User user = _bdc.Users.Include(a => a.Activities).SingleOrDefault(u => u.Id == id);
            return View("UserActivities", user); 

        
        }


    }
}
