using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Data.Models
{
    public class Feedback
    {
        [Key]
        public int FbId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public int RenterId { get; set; }
        public Renter Renter { get; set; }
    }
}
