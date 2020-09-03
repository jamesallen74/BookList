using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Series1_BookListRazor_WEB.Models;

namespace Series1_BookListRazor_WEB.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet(int Id)
        {
            Book = await _db.Book.FindAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDB = await _db.Book.FindAsync(Book.Id);
                BookFromDB.Name = Book.Name;
                BookFromDB.ISBN = Book.ISBN;
                BookFromDB.Author = Book.Author;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
