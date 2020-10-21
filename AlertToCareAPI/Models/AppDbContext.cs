using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCareAPI.Controllers;
using Microsoft.EntityFrameworkCore;

namespace AlertToCareAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<IcuModel> Icu { get; set; }
        public DbSet<PatientModel> Patients { get; set; }

        public DbSet<VitalsModel> Vitals { get; set; }

        public DbSet<BedOnAlert> Beds { get; set; }
    }

}
