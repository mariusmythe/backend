using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly FullstackDbContext _context;
        public ArticleController(FullstackDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetArticles")]
        public async Task<ActionResult<List<Article>>>Get()
        {
            return Ok(await _context.myfirstdb.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<DbArticle>>Get(int id)
        {
            var dbArtickle = await _context.myfirstdb.FindAsync(id);
            if (dbArtickle == null)
            {
                return BadRequest("Fant ikke artikkel");
            }

            return dbArtickle;
        }

        [HttpPost("PubliserArtikkel")]
        public async Task<ActionResult<List<Article>>> AddArticle([FromBody]Article nyArtikkel)
        {
            
            DbArticle innArtikkel = new DbArticle();
            
            innArtikkel.Title = nyArtikkel.Title;
            innArtikkel.Author = nyArtikkel.Author;
            innArtikkel.Content = nyArtikkel.Content;
            innArtikkel.Published = DateTime.Now;
            innArtikkel.ImageURL = "someething";
            Console.WriteLine(innArtikkel);
            _context.myfirstdb.Add(innArtikkel);
            _context.SaveChanges();
 
            return Ok(await _context.myfirstdb.ToListAsync());
        }

        [HttpPost("RedigerArtikkel")]
        public async Task<ActionResult<List<Article>>> AddArticle([FromBody] DbArticle nyArtikkel)
        {
            var tmpObject = await _context.myfirstdb.FindAsync(nyArtikkel.Id);

            tmpObject.Author = nyArtikkel.Author;
            tmpObject.Content = nyArtikkel.Content;
            tmpObject.Title = nyArtikkel.Title;
            tmpObject.Published = DateTime.Now;
            
            _context.SaveChanges();
            return Ok(await _context.myfirstdb.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Article>>> Delete(int Id)
        {

            var dbArtickle = await _context.myfirstdb.FindAsync(Id);
            Console.WriteLine(dbArtickle);
            if (dbArtickle == null)
            {
                return BadRequest("Fant ikke artikkel");
            }
            _context.myfirstdb.Remove(dbArtickle);
            await _context.SaveChangesAsync();

            return Ok(await _context.myfirstdb.ToListAsync());
        }

        
    }
}
