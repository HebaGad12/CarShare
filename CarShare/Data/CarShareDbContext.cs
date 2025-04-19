using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShare.Data
{
    internal class CarShareDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DFH\\MSSQLSERVER01;Database=CompanyDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

    }
}
