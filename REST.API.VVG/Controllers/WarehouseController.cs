using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;
using REST.API.VVG.Database;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseDbContext _db;

        public WarehouseController(WarehouseDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Warehouse>? Get()
        {
            List<Warehouse> warehouses = new List<Warehouse>();
            if (_db.Warehouse != null)
                warehouses = _db.Warehouse.ToList();
            // ************************************************ //
            warehouses = _db.Warehouse.OrderBy(p => p.Id).ToList();
            return warehouses;
        }

        [HttpGet("{id}")]
        public IEnumerable<Warehouse>? GetById(int? id)
        {
            List<Warehouse> warehouses = new();
            Warehouse? warehouse = _db.Warehouse.Find(id);
            if (warehouse != null)
            {
                warehouses.Add(warehouse);
            }
            return warehouses;
        }

        [HttpPut("{id}")]
        public IEnumerable<Warehouse>? Update([FromBody] Warehouse warehouse)
        {
            List<Warehouse> warehouses = new List<Warehouse>();
            EntityEntry<Warehouse>? storedResource;
            if (_db.Warehouse != null)
            {
                if (warehouse.Id < 1)
                {
                    storedResource = _db.Warehouse.Add(warehouse);
                }
                else
                {
                    storedResource = _db.Warehouse.Update(warehouse);
                }

                _db.SaveChanges();
                warehouses.Add(storedResource.Entity);
            }
            return warehouses;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Warehouse? warehouse = _db.Warehouse.Find(id);
            if (warehouse != null)
            {
                _db.Warehouse.Remove(warehouse);
                _db.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }

    }
}
