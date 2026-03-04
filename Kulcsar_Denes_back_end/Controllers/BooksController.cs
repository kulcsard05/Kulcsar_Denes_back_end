using Kulcsar_Denes_back_end.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kulcsar_Denes_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetBooks()
        {
            try
            {
                using (var cx=new LibrarydbContext())
                {
                    var books = cx.Books.ToList();
                    return Ok(books);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public IActionResult PostBook(string uid, Book book)
        {
            try
            {
                using(var cx=new LibrarydbContext())
                {
                    if (uid == Program.UserID)
                    {
                        cx.Books.Add(book);
                        cx.SaveChanges();
                        return StatusCode(201, "Könyv hozzáadása sikeresen megtörtént");
                    }
                    else
                    {
                        return StatusCode(401, "Nincs jogosultsága új könyv felvételéhez.");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(400,ex.Message);
            }
        }
    }
}
