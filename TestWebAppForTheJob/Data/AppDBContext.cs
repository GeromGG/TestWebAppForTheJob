using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(LogSQL);
        }

        private void LogSQL(string sql)
        {
            Debug.Write(sql);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Founder> Founders { get; set; }
    }
}
