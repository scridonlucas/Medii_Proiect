using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Models;

namespace ProiectMedii.Data
{
    public class ProiectMediiContext : DbContext
    {
        public ProiectMediiContext (DbContextOptions<ProiectMediiContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectMedii.Models.Client> Client { get; set; }

        public DbSet<ProiectMedii.Models.Employee> Employee { get; set; }

        public DbSet<ProiectMedii.Models.Service> Service { get; set; }

        public DbSet<ProiectMedii.Models.Schedule> Schedule { get; set; }

        public DbSet<ProiectMedii.Models.Appointment> Appointment { get; set; }
    }
}
