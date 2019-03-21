using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bit285_assignment3_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bit285_assignment3_api.Controllers
{
    [Route("api/[controller]")]
    public class userController : Controller
    {

        private BitDataContext _bdc;

        public userController(BitDataContext dbContext)

        {
            _bdc = dbContext;
        }



        // GET api/<controller>/5
        [HttpGet]
        [Route("FullName")] 
        public IActionResult Get(string term)
        {
            var user = _bdc.Users.Where(U => U.FullName.Contains(term)).Select(c=> new { id = c.Id, value = c.FullName } );
            //if (user == null)
                //return NotFound();
            return Json(user);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]User user)
        {
            _bdc.Users.Add(user);
            _bdc.SaveChanges();
        }

        //// PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]string term, User user)
        {
            var dbu = _bdc.Users.SingleOrDefault(u => u.FullName == term);

            if (dbu != null)

            {
                //dbu.Activities = term.Activities;
                _bdc.Update(dbu);
                _bdc.SaveChanges();
                return Ok();

            }
            else

            return NotFound();
        }

        //// DELETE api/values/5
        ////[HttpDelete("{id}")]
        ////public void Delete(int id)
        //{
        //}
    }
}
