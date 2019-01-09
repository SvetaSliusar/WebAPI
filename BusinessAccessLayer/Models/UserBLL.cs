using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessAccessLayer.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BusinessAccessLayer.Models
{
    public class UserBLL
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public IEnumerable<IdentityUserLogin> Logins { get; set; }
    }
}
