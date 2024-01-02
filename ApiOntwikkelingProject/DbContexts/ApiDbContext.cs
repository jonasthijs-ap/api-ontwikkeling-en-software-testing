using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Entities.Properties;
using Microsoft.EntityFrameworkCore;

namespace ApiOntwikkelingProject.DbContexts
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Camping> Campings { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Camper> Campers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}