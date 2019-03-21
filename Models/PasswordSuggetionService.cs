using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bit285_assignment3_api.Models
{
    public class PasswordSuggetionService
    {
        public string generatePassword(ViewModels.PasswordInfo info) { 
            List<string> _passwordOptions = new List<string>();
            int half = info.LastName.Length / 2;
            _passwordOptions.Add(info.FavoriteColor.Substring(0, 2) + "-" +
                                        info.FavoriteColor + "-" +
                                    info.LastName);
            _passwordOptions.Add(info.LastName + info.FavoriteColor);
            _passwordOptions.Add(info.LastName.Substring(0, half) + "-" +
                                    info.BirthYear + "-" +
                                    info.LastName.Substring(half,half));
            Random random = new Random();
            int index = random.Next(0,_passwordOptions.Count);
            return _passwordOptions[index];
        }
    }
}
