using Microsoft.EntityFrameworkCore;
using Model.VVG.model;
namespace REST.API.VVG.Database
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext()
        {
            //AppContext.SetSwitch
        }

        //public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
        //    : base(options)
        //{
        //}

        public DbSet<Article> Article { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<DocumentHeader> DocumentHeader { get; set; }
        public DbSet<DocumentItems> DocumentItems { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
