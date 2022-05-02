using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;
using WarehouseDataContext.Database;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        WarehouseDbContext _db = new();

        [HttpGet]
        public IEnumerable<Warehouse>? get()
        {
            List<Warehouse> warehouses = new List<Warehouse>();
            if (_db.Warehouse != null)
                warehouses = _db.Warehouse.ToList();
            return warehouses;
        }

        [HttpGet("{id}")]
        public Warehouse? getById(int id)
        {
            Warehouse? warehouse = _db.Warehouse.Find(id);
            return warehouse;
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            Warehouse? warehouse = _db.Warehouse.Find(id);
            if (warehouse != null)
            {
                _db.Warehouse.Remove(warehouse);
                _db.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }

        [HttpPost]
        public IEnumerable<Warehouse>? update([FromBody] Warehouse warehouse)
        {
            List<Warehouse> responseBundle = new List<Warehouse>();

            //if (!validate(warehouse))
            //    return responseBundle;

            EntityEntry<Warehouse>? storedResource;

            if (_db.Warehouse != null)
            {
                if (warehouse.Id < 1)
                    storedResource = _db.Warehouse.Add(warehouse);
                else
                    storedResource = _db.Warehouse.Update(warehouse);

                _db.SaveChanges();
                responseBundle.Add(storedResource.Entity);
            }

            return responseBundle;
        }
    }
}
