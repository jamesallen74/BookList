using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Series1_BookListRazor_WEB.Models;
using System;
using System.Threading.Tasks;

namespace Series1_BookListRazor_WEB.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                _db.Book.AddAsync(Book);
                
                // author uses SaveChangesAsync but this fails, transaction failes, something with lifetime
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
            else 
            {
                return Page();
            }
        }
    }
}
