using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zadanie_Testowe.Models
{
    public class User
    {
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(5)]
        public string Username { get; set; }
        [MinLength(5)]
        public string Password { get; set; }
    }
}