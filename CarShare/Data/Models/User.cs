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

        public AdminProfile? AdminProfile { get; set; }
        public OwnerProfile? OwnerProfile { get; set; }
        public RenterProfile? RenterProfile { get; set; }
    }
}
