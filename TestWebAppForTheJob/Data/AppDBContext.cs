using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Founder> Founders { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            this.SavingChanges += ContextSavingChanges; ;
        }

        private void ContextSavingChanges(object sender, SavingChangesEventArgs e)
        {
            var allEntity = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var item in allEntity)
            {
                if (item.Entity is Client client)
                {
                    client.DateOfUpdate = DateTime.Now;
                }
                if (item.Entity is Founder founder)
                {
                    founder.Client.DateOfUpdate = DateTime.Now;
                    founder.DateOfUpdate = DateTime.Now;
                }
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(LogSQL);
        }

        private void LogSQL(string sql)
        {
            Debug.Write(sql);
        }
    }
}
