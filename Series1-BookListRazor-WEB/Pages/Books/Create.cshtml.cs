using Microsoft.AspNetCore.Mvc.RazorPages;
using Series1_BookListRazor_WEB.Models;

namespace Series1_BookListRazor_WEB.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Book Book { get; set; }

        public void OnGet()
        {
        }
    }
}
