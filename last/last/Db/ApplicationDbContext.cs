using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace last.Db
{
    internal class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "thedatabase.db");
            optionsBuilder.UseSqlite($"Data Source={path}");

        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Tabel>()
            //     .Property(p => p.Profit)
            //     .HasComputedColumnSql("[SellingPrice]-[PurchasingPrice]");
            //modelBuilder.Entity<Tabel>()
            //    .Property(s => s.SellingPrice)
            //    .HasDefaultValue(0);
            //modelBuilder.Entity<Tabel>()
            //    .Property(p => p.PurchasingPrice)
            //    .HasDefaultValue(0);
        }
        public DbSet<Tabel> Tables { get; set; }
    }
}
