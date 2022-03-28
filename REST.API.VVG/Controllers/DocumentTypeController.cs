using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;
using REST.API.VVG.Database;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentTypeController : ControllerBase
    {
        private readonly WarehouseDbContext _db;

        public DocumentTypeController(WarehouseDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<DocumentType>? Get()
        {
            List<DocumentType> docTypes = new List<DocumentType>();
            if (_db.DocumentType != null)
                docTypes = _db.DocumentType.ToList();
            // ************************************************ //
            docTypes = _db.DocumentType.OrderBy(p => p.Id).ToList();
            return docTypes;
        }

        [HttpGet("{id}")]
        public IEnumerable<DocumentType>? GetById(int? id)
        {
            List<DocumentType> docTypes = new();
            DocumentType? documentType = _db.DocumentType.Find(id);
            if (documentType != null)
            {
                docTypes.Add(documentType);
            }
            return docTypes;
        }

        [HttpPut("{id}")]
        public IEnumerable<DocumentType>? Update([FromBody] DocumentType documentType)
        {
            List<DocumentType> docTypes = new List<DocumentType>();
            EntityEntry<DocumentType>? storedResource;
            if (_db.DocumentType != null)
            {
                if (documentType.Id < 1)
                {
                    storedResource = _db.DocumentType.Add(documentType);
                }
                else
                {
                    storedResource = _db.DocumentType.Update(documentType);
                }

                _db.SaveChanges();
                docTypes.Add(storedResource.Entity);
            }
            return docTypes;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DocumentType? docType = _db.DocumentType.Find(id);
            if (docType != null)
            {
                _db.DocumentType.Remove(docType);
                _db.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }
    }
}
