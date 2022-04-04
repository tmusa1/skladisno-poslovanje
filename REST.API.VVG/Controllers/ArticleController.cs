using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;
using REST.API.VVG.Database;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly WarehouseDbContext _db;

        public ArticleController(WarehouseDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Article>? Get()
        {
            List<Article> articles = new List<Article>();
            if (_db.Article != null)
                articles = _db.Article.ToList();
            // ************************************************ //
            articles = _db.Article.OrderBy(p => p.Id).ToList();
            return articles;
        }

        [HttpGet("{id}")]
        public IEnumerable<Article>? GetById(int? id)
        {
            List<Article> articles = new();
            Article? article = _db.Article.Find(id);
            if (article != null)
            {
                articles.Add(article);
            }
            return articles;
        }

        [HttpPut("{id}")]
        public IEnumerable<Article>? Update([FromBody] Article article)
        {
            List<Article> articles = new List<Article>();
            EntityEntry<Article>? storedResource;
            if (_db.Article != null)
            {
                if (article.Id < 1)
                {
                    storedResource = _db.Article.Add(article);
                }
                else
                {
                    storedResource = _db.Article.Update(article);
                }

                _db.SaveChanges();
                articles.Add(storedResource.Entity);
            }
            return articles;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Article? article = _db.Article.Find(id);
            if (article != null)
            {
                _db.Article.Remove(article);
                _db.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }
    }
}
