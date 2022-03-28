using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;
using REST.API.VVG.Database;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly WarehouseDbContext _db;

        public CompanyController(WarehouseDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Company>? Get()
        {
            List<Company> companies = new List<Company>();
            if (_db.Company != null)
                companies = _db.Company.ToList();
            // ************************************************ //
            companies = _db.Company.OrderBy(p => p.Id).ToList();
            return companies;
        }

        [HttpGet("{id}")]
        public IEnumerable<Company>? GetById(int? id)
        {
            List<Company> companies = new ();
            Company? company = _db.Company.Find(id);
            if (company != null)
            {
                companies.Add(company);
            }
            return companies;
        }

        [HttpPut("{id}")]
        public IEnumerable<Company>? Update([FromBody]Company company)
        {
            List<Company> companies = new List<Company>();
            EntityEntry<Company>? storedResource;
            if(_db.Company != null)
            {
                if(company.Id < 1)
                {
                    storedResource = _db.Company.Add(company);
                }else
                {
                    storedResource = _db.Company.Update(company);
                }

                _db.SaveChanges();
                companies.Add(storedResource.Entity);
            }
            return companies;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Company? company = _db.Company.Find(id);
            if(company != null)
            {
                _db.Company.Remove(company);
                _db.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }
    }
}
