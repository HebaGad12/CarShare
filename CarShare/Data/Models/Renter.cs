using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Data.Models
{
    public class Renter
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Proposal> Proposals { get; set; }
        public ICollection<RentalContract> RentalContracts { get; set; }
    }
}
