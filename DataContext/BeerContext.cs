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
        DbSet<Bitterness> Bitternesss { get; set; }
        DbSet<Brewer> Brewers { get; set; }
        DbSet<Beer> Beers { get; set; }
        DbSet<BeerUser> BeerUsers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class BeerContext : DbContext, IBeerContext
    {
        public DbSet<Brewer> Brewers { get; set; }
        public DbSet<Bitterness> Bitternesss { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<BeerUser> BeerUsers { get; set; }

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
            modelBuilder.Entity<BeerUser>().HasKey(bu => new {bu.BeerId, bu.UserId});

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
                BeerId = 1, 
                Name = "Stella Artois", 
                Percentage = "5.2",
                Origin = "Leuven",
                BitternessId = 1,
                BrewerId = 1
            });
            modelBuilder.Entity<Beer>().HasData(new Beer(){
                BeerId = 2, 
                Name = "Jupiler", 
                Percentage = "5.2",
                Origin = "Jupille-sur-Meuse",
                BitternessId = 2,
                BrewerId = 2
            });
            modelBuilder.Entity<Beer>().HasData(new Beer(){
                BeerId = 3,  
                Name = "Heineken", 
                Percentage = "5",
                Origin = "Amsterdam",
                BitternessId = 1,
                BrewerId = 1            // nog aanpassen
            });

            modelBuilder.Entity<User>().HasData(new User(){
                UserId = 1,
                Name = "D'Haese",
                Firstname = "Thibault"
            });
            modelBuilder.Entity<User>().HasData(new User(){
                UserId = 2,
                Name = "Claeys",
                Firstname = "Robin"
            });
            modelBuilder.Entity<User>().HasData(new User(){
                UserId = 3,
                Name = "Onderbeke",
                Firstname = "Niels",
            });

            modelBuilder.Entity<BeerUser>().HasData(new BeerUser(){
                BeerId = 1,
                UserId = 1
            });
            modelBuilder.Entity<BeerUser>().HasData(new BeerUser(){
                BeerId = 2,
                UserId = 1
            });
            modelBuilder.Entity<BeerUser>().HasData(new BeerUser(){
                BeerId = 3,
                UserId = 1
            });
        }
    }
}
