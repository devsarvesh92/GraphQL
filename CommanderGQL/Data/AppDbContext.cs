using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Platforms table in the database
        /// </summary>
        /// <value></value>
        public DbSet<Platform> Platforms { get; set; }

        /// <summary>
        /// Commands
        /// </summary>
        /// <value></value>
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasMany(p=>p.Commands).WithOne(p=>p.Platform!).HasForeignKey(p=>p.PlatformId);
            
            modelBuilder.Entity<Command>().HasOne(p=>p.Platform).WithMany(p=>p.Commands).HasForeignKey(p=>p.PlatformId);
        }


        
    }
}