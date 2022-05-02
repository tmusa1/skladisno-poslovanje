using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;
using WarehouseDataContext.Database;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        WarehouseDbContext _db = new();

        [HttpGet]
        public IEnumerable<Company>? get()
        {
            List<Company> companies = new List<Company>();
            if (_db.Company != null)
                companies = _db.Company.ToList();
            return companies;
        }

        [HttpGet("{id}")]
        public Company? getById(int id)
        {
            Company? company = _db.Company.Find(id);
            return company;
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            Company? company = _db.Company.Find(id);
            if (company != null)
            {
                _db.Company.Remove(company);
                _db.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }

        [HttpPost]
        public IEnumerable<Company>? update([FromBody] Company company)
        {
            List<Company> responseBundle = new List<Company>();

            //if (!validate(company))
            //    return responseBundle;

            EntityEntry<Company>? storedResource;

            if (_db.Company != null)
            {
                if (company.Id < 1)
                    storedResource = _db.Company.Add(company);
                else
                    storedResource = _db.Company.Update(company);

                _db.SaveChanges();
                responseBundle.Add(storedResource.Entity);
            }

            return responseBundle;

        }
    }
}
