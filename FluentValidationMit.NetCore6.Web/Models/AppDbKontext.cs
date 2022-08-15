using Microsoft.EntityFrameworkCore;

namespace FluentValidationMit.NetCore6.Web.Models
{
    public class AppDbKontext:DbContext
    {
        public AppDbKontext(DbContextOptions<AppDbKontext>options):base(options)
        {

        }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Adresse> Adressen { get; set; }
    }
}
