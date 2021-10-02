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
    }
}