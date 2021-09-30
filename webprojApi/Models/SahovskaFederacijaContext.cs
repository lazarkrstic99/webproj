using Microsoft.EntityFrameworkCore;
namespace webproj.Models
{
    public class SahovskaFederacijaContext : DbContext
    {
        public DbSet<Sahista> Sahisti {get;set;}
        public DbSet<Partija> Partije {get;set;}
        public DbSet<Turnir> Turniri {get;set;}
        public SahovskaFederacijaContext(DbContextOptions options) : base(options)
        {

        }
    }
}