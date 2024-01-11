using Microsoft.EntityFrameworkCore;
using WebUygulamaProje1.Models;

namespace WebUygulamaProje1.Utility
{
    public class UygulamaDBContext : DbContext 
    {
        public UygulamaDBContext(DbContextOptions<UygulamaDBContext> options ) : base(options) { }

        public DbSet<KitapTuru> KitapTurleri { get; set; }


    }
}
