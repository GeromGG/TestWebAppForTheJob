using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Interfaces;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Founder> Founders  { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Founder>().HasOne<Client>(c => c.Client).WithMany(b => b.Founders).HasForeignKey(d => d.ClientId);
        //    //SeedData(modelBuilder);
        //}

        //private IAllClients _allClient { get; set; }

        //private IClientFounders _clientFounders { get; set; }

        //public void SeedData(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Client>().HasData(_allClient.Clients);
        //    modelBuilder.Entity<Founder>().HasData(_clientFounders.AllFounders);
        //}
    }
}
