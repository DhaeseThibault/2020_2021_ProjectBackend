using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using ProjectBackend.Configuration;
using ProjectBackend.Models;


namespace ProjectBackend.DataContext
{
    public interface IBeerContext
    {
        DbSet<Bitterness> Bitterness { get; set; }
        DbSet<Brewer> Brewer { get; set; }
        DbSet<Beer> Beer { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class BeerContext : DbContext, IBeerContext
    {
        public DbSet<Brewer> Brewer { get; set; }
        public DbSet<Bitterness> Bitterness { get; set; }
        public DbSet<Beer> Beer { get; set; }

        private ConnectionStrings _connectionStrings;

        public BeerContext(DbContextOptions<BeerContext> options, IOptions<ConnectionStrings> connectionStrings)
        { 
            _connectionStrings = connectionStrings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionStrings.SQL);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brewer>().HasData(new Brewer(){
                BrewerId = 1,
                Name = "AB InBev",
                HeadOffice = "Leuven"
            });
            modelBuilder.Entity<Brewer>().HasData(new Brewer(){
                BrewerId = 2,
                Name = "Piedboeuf",
                HeadOffice = "Luik"
            });

            modelBuilder.Entity<Bitterness>().HasData(new Bitterness(){
                BitternessId = 1,
                AmountIBU = 25
            });
            modelBuilder.Entity<Bitterness>().HasData(new Bitterness(){
                BitternessId = 2,
                AmountIBU = 20
            });

            modelBuilder.Entity<Beer>().HasData(new Beer(){
                BeerId = Guid.NewGuid(), 
                Name = "Stella Artois", 
                Percentage = "5.2",
                Origin = "Leuven",
                BitternessId = 1,
                BrewerId = 1
            });
            modelBuilder.Entity<Beer>().HasData(new Beer(){
                BeerId = Guid.NewGuid(), 
                Name = "Jupiler", 
                Percentage = "5.2",
                Origin = "Jupille-sur-Meuse",
                BitternessId = 2,
                BrewerId = 2
            });
            modelBuilder.Entity<Beer>().HasData(new Beer(){
                BeerId = Guid.NewGuid(),  
                Name = "Heineken", 
                Percentage = "5",
                Origin = "Amsterdam",
                BitternessId = 1,
                BrewerId = 1            // nog aanpassen
            });
        }
    }
}
