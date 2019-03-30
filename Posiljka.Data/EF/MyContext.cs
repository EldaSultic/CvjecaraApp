using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Posiljka.Data.EntityModels;
using System.IO;

namespace Posiljka.Data.EF
{
    public class MyContext : DbContext
    {

        public MyContext(DbContextOptions<MyContext> x) : base(x)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Odjeljenje>()
            //    .HasOne(x => x.Razrednik)
            //    .WithMany()
            //    .HasForeignKey(x => x.RazrednikID)
            //    .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Narudzba>()
            //    .HasOne(x => x.VrstaCvijeta)
            //    .WithMany()
            //    .HasForeignKey(x => x.VrstaCvijetaId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Narudzba>()
            // .HasOne(x => x.Korisnik)
            // .WithMany()
            // .HasForeignKey(x => x.KorisnikId)
            // .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<Narudzba>()
            // .HasOne(x => x.Ukras)
            // .WithMany()
            // .HasForeignKey(x => x.UkrasId)
             //.OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<OznaceniOdgovori>()
            //    .HasOne(x => x.Polaze)
            //    .WithMany()
            //    .HasForeignKey(x => x.PolazeId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Boja> Boja { get; set; }
        public DbSet<Cijena> Cijena { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<TopPonuda> TopPonuda { get; set; }
        public DbSet<Ukras> Ukras { get; set; }
        public DbSet<VrstaCvijeta> VrstaCvijeta { get; set; }
        public DbSet<Narudzba_Stavka> Narudzba_Stavka { get; set; }
        public DbSet<VrstaCvijeta_Boja> VrstaCvijeta_Boja { get; set; }
    }
}
