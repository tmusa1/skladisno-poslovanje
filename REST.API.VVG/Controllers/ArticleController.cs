using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;

using Microsoft.AspNetCore.Mvc.Rendering;
using WarehouseDataContext.Database;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        WarehouseDbContext _db = new();

        [HttpGet]
        public IEnumerable<Article>? get()
        {
            List<Article> articles = new List<Article>();
            if (_db.Article != null)
                articles = _db.Article.ToList();
            return articles;
        }

        [HttpGet("{id}")]
        public Article? getById(int id)
        {
            Article? article = _db.Article.Find(id);
            return article;
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            Article? article = _db.Article.Find(id);
            if (article != null)
            {
                _db.Article.Remove(article);
                _db.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }

        [HttpPost]
        public IEnumerable<Article>? update([FromBody] Article article)
        {
            List<Article> responseBundle = new List<Article>();

            //if (!validate(article))
            //    return responseBundle;

            EntityEntry<Article>? storedResource;

            if (_db.Article != null)
            {
                if (article.Id < 1)
                    storedResource = _db.Article.Add(article);
                else
                    storedResource = _db.Article.Update(article);

                _db.SaveChanges();
                responseBundle.Add(storedResource.Entity);
            }

            return responseBundle;
        }
    }
}
