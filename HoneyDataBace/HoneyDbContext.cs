using HoneyDataBace.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyDataBace
{
    public interface IBillContext
    {
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
    }

    public class HoneyDbContext : DbContext, IBillContext
    {
        private readonly string _connectionString;

        public DbSet<Honey> Honeys { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<SupplyWare> SupplyWares { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }

        public HoneyDbContext(string connectionString)
        {
            _connectionString = connectionString;
           // Database.EnsureCreated();
        }
        public HoneyDbContext(DbContextOptions<HoneyDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
      
    }
}
