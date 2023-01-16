using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;

namespace Proiect.Data
{
    public class ProiectContext : IdentityDbContext<IdentityUser>
    {
        public ProiectContext (DbContextOptions<ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect.Models.Patient> Patient { get; set; } = default!;

        public DbSet<Proiect.Models.Doctor> Doctor { get; set; }

        public DbSet<Proiect.Models.Appointment> Appointment { get; set; }

        public DbSet<Proiect.Models.Review> Review { get; set; }
    }
}
