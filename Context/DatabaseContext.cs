
using PVR.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PVR.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }


    }
}