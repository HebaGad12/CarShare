using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Data.Models
{
    public class Proposal
    {
        [Key]
        public int ProbId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Documents { get; set; }
        public string LicenseVar { get; set; }

        public int RenterId { get; set; }
        public Renter Renter { get; set; }

        public int CarId { get; set; }
        public CarPost CarPost { get; set; }

        public ICollection<RentalContract> RentalContracts { get; set; }
    }
}
