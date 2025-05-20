using LibraryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class ViewController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ViewController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ViewAuthor()
        {
            var authors = await _context.authors.ToListAsync();
            return View(authors);
        }

        public IActionResult ViewBook()
        {
            return View();

        }

           
    }
}
