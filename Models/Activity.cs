using System;
using System.ComponentModel.DataAnnotations;

namespace bit285_assignment3_api.Models
{
    public class Activity
    {
        public long Id { get; set; }

        public ActivityType Type { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ActivityDate { get; set; }  

        //Navigation Property
        public User Actor { get; set; }


        //public string FullName
        //{
        //    get { return LastName + ", " + FirstName; }
        //}
    }

    //Designate only specific types of Activities
    public enum ActivityType
    {
        Login,
        Logout
    }
}
