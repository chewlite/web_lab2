using Microsoft.EntityFrameworkCore;
using MvcH.Models;

namespace MvcH.Data
{
    public class MvcHContext : DbContext
    {
        public MvcHContext (DbContextOptions<MvcHContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patient { get; set; }
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Relation> Relation { get; set; }
    }
}