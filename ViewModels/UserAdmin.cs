using System;
using System.Collections.Generic;
using bit285_assignment3_api.Models;

namespace bit285_assignment3_api.ViewModels
{
    public class UserAdmin
    {
        //TODO : Add properties to support the /Views/Admin/Index.cshtml View
       public string FullName { get; set; }

       // public  ICollection<User>Users { get; set; }

        public string Program { get; set; }

        public string LastName { get; set; }

        public string FirstName { get;set;}

        public long UserId { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
