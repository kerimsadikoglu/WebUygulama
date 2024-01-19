using Microsoft.EntityFrameworkCore;
using WebUygulamaProje1.Models;

namespace WebUygulamaProje1.Utility
{
    public class UygulamaDBContext : DbContext 
    {
        public UygulamaDBContext(DbContextOptions<UygulamaDBContext> options ) : base(options) { }

        public DbSet<KitapTuru> KitapTurleri { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kiralama> Kiralamalar { get; set; }



    }
}
