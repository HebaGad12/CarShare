using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Data.Models
{
    internal class CarPost
    {
        [Key]
        public int CarId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CarType { get; set; }
        public string Model { get; set; }
        public string Transmission { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public DateTime AvailStart { get; set; }
        public DateTime AvailEnd { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        public ICollection<Proposal> Proposals { get; set; }
    }
}
