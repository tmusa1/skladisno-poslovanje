using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;
using WarehouseDataContext.Database;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentTypeController : ControllerBase
    {
        WarehouseDbContext _db = new();

        [HttpGet]
        public IEnumerable<DocumentType>? get()
        {
            List<DocumentType> documentTypes = new List<DocumentType>();
            if (_db.DocumentType != null)
                documentTypes = _db.DocumentType.ToList();
            return documentTypes;
        }

        [HttpGet("{id}")]
        public DocumentType? getById(int id)
        {
            DocumentType? documentType = _db.DocumentType.Find(id);
            return documentType;
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            DocumentType? documentType = _db.DocumentType.Find(id);
            if (documentType != null)
            {
                _db.DocumentType.Remove(documentType);
                _db.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }

        [HttpPost]
        public IEnumerable<DocumentType>? update([FromBody] DocumentType documentType)
        {
            List<DocumentType> responseBundle = new List<DocumentType>();

            //if (!validate(documentType))
            //    return responseBundle;

            EntityEntry<DocumentType>? storedResource;

            if (_db.DocumentType != null)
            {
                if (documentType.Id < 1)
                    storedResource = _db.DocumentType.Add(documentType);
                else
                    storedResource = _db.DocumentType.Update(documentType);

                _db.SaveChanges();
                responseBundle.Add(storedResource.Entity);
            }

            return responseBundle;
        }
    }
}
