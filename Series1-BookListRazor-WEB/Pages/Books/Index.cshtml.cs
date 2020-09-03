using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Series1_BookListRazor_WEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Series1_BookListRazor_WEB.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int ID)
        {
            var book = await _db.Book.FindAsync(ID);
            if(book== null)
            {
                return NotFound();
            }
            else
            {
                _db.Book.Remove(book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
        }
    }
}
