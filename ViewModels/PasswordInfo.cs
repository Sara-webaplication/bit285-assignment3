using System;
using System.ComponentModel.DataAnnotations;

namespace bit285_assignment3_api.ViewModels
{
    public class PasswordInfo
    {
        //Used for passing data
        public long Id { get; set; }
        public string Password { get; set; }

        [Required(ErrorMessage="*")]
        public string FavoriteColor { get; set; }
        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "*")]
        [Range(1901,2010,ErrorMessage ="Please enter year between 1900 and 2010")]
        public int BirthYear { get; set; }

    }
}
