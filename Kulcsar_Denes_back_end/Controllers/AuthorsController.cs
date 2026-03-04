using Kulcsar_Denes_back_end.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kulcsar_Denes_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        [HttpGet("{authorName}")]

        public IActionResult GetAuthor(string authorName)
        {
            try
            {
                using (var cx = new LibrarydbContext())
                {
                    var response=cx.Authors.Where(x=>x.AuthorName==authorName).Select(x => x.Books.ToList()).ToList();
                    return Ok(response);
                }
            }
            catch (Exception ex) 
            { 
                return StatusCode(404, ex.Message);
            }
        }

        [Route("Count")]
        [HttpGet]

        public IActionResult GetCount()
        {
            try
            {
                using (var cx = new LibrarydbContext())
                {
                    var response=cx.Authors.Count();
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
