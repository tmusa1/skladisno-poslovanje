using Microsoft.EntityFrameworkCore;
using Model.VVG.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.VVG.Database
{
    internal class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        //public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
        //    : base(options)
        //{
        //}

        public DbSet<Article>? Article { get; set; }
        public DbSet<Company>? Company { get; set; }
        public DbSet<DocumentHeader>? DocumentHeader { get; set; }
        public DbSet<DocumentItems>? DocumentItems { get; set; }
        public DbSet<DocumentType>? DocumentType { get; set; }
        public DbSet<Inventory>? Inventory { get; set; }
        public DbSet<Warehouse>? Warehouse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=warehouse;Username=postgres;Password=postgres");
    }
}
