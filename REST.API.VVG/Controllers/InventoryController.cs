using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;
using REST.API.VVG.Database;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly WarehouseDbContext _db;

        public InventoryController(WarehouseDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Inventory>? Get()
        {
            List<Inventory> inventories = new List<Inventory>();
            if (_db.Inventory != null)
                inventories = _db.Inventory.ToList();
            // ************************************************ //
            inventories = _db.Inventory.OrderBy(p => p.Id).ToList();
            return inventories;
        }

        [HttpGet("{id}")]
        public IEnumerable<Inventory>? GetById(int? id)
        {
            List<Inventory> inventories = new();
            Inventory? inventory = _db.Inventory.Find(id);
            if (inventory != null)
            {
                inventories.Add(inventory);
            }
            return inventories;
        }

        [HttpPut("{id}")]
        public IEnumerable<Inventory>? Update([FromBody] Inventory inventory)
        {
            List<Inventory> inventories = new List<Inventory>();
            EntityEntry<Inventory>? storedResource;
            if (_db.Inventory != null)
            {
                if (inventory.Id < 1)
                {
                    storedResource = _db.Inventory.Add(inventory);
                }
                else
                {
                    storedResource = _db.Inventory.Update(inventory);
                }

                _db.SaveChanges();
                inventories.Add(storedResource.Entity);
            }
            return inventories;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Inventory? inventory = _db.Inventory.Find(id);
            if (inventory != null)
            {
                _db.Inventory.Remove(inventory);
                _db.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }
    }
}
