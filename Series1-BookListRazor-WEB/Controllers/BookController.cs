using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Series1_BookListRazor_WEB.Models;

namespace Series1_BookListRazor_WEB.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var bookFromDb = await _db.Book.FirstOrDefaultAsync(u => u.Id == Id);
            if(bookFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            else
            {
                _db.Book.Remove(bookFromDb);
                await _db.SaveChangesAsync();
                return Json(new { success = true, message = "Delete Successful" });
            }
        }
    }
}
