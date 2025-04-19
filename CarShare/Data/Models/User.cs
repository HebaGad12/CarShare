using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Data.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserType UserType { get; set; }

        public Admin? AdminProfile { get; set; }
        public Owner? OwnerProfile { get; set; }
        public Renter? RenterProfile { get; set; }
    }
}
