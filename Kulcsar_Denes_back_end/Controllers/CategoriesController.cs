using Kulcsar_Denes_back_end.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kulcsar_Denes_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetCategories()
        {
            try
            {
                using (var cx=new LibrarydbContext())
                {
                    var response=cx.Categories.Select(x=>new {x.CategoryId,x.CategoryName,books=x.Books.ToList()}).ToList();
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
