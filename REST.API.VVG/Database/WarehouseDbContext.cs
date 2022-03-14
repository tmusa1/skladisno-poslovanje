using Microsoft.EntityFrameworkCore;

namespace REST.API.VVG.Database
{
    public class WarehouseDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public WarehouseDbContext()
        {
            //AppContext.SetSwitch
        }
    }
}
