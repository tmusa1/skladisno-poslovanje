using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;
using WarehouseDataContext.Database;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        WarehouseDbContext _db = new();

        [HttpGet]
        public IEnumerable<Inventory>? get()
        {
            List<Inventory> inventories = new List<Inventory>();
            if (_db.Inventory != null)
                inventories = _db.Inventory.ToList();
            return inventories;
        }

        [HttpGet("{id}")]
        public Inventory? getById(int id)
        {
            Inventory? inventory = _db.Inventory.Find(id);
            return inventory;
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            Inventory? inventory = _db.Inventory.Find(id);
            if (inventory != null)
            {
                _db.Inventory.Remove(inventory);
                _db.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }

        [HttpPost]
        public IEnumerable<Inventory>? update([FromBody] Inventory inventory)
        {
            List<Inventory> responseBundle = new List<Inventory>();

            //if (!validate(inventory))
            //    return responseBundle;

            EntityEntry<Inventory>? storedResource;

            if (_db.Inventory != null)
            {
                if (inventory.Id < 1)
                    storedResource = _db.Inventory.Add(inventory);
                else
                    storedResource = _db.Inventory.Update(inventory);

                _db.SaveChanges();
                responseBundle.Add(storedResource.Entity);
            }

            return responseBundle;
        }
    }
}
