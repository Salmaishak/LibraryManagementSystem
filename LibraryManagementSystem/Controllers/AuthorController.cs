using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ViewAuthor()
        {
            var authors = await _context.authors.ToListAsync();
            return View("Author",authors);
        }
        [HttpGet]
        public IActionResult AddAuthor()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
                _context.Add(author);
                _context.SaveChanges();
              
            var auth = _context.authors.ToList();
            return View("Author", auth);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAuthor(int ID)
        {
            var author = await _context.authors.FindAsync(ID);

            if (author != null)
            {
                _context.authors.Remove(author);
                await _context.SaveChangesAsync();
            }


            var authors = await _context.authors.ToListAsync();
            return View("Author", authors);
        }

        [HttpGet]
        public async Task<IActionResult> EditAuthorGet(int id)
        {
            var author = await _context.authors.FindAsync(id);

            if (author == null)
            {
                return NoContent();
            }

            return View("EditAuthor",author); 
        }

        [HttpGet]
        public IActionResult AuthorBooks()
        {
           

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditAuthor(Author author)
        {
             _context.authors.Update(author);
                await _context.SaveChangesAsync();
                return RedirectToAction("ViewAuthor"); 
           

              
        }



        public async Task<IActionResult> ViewAuthorWithBooks(int id)
        {
            var author = await _context.authors.Include(a => a.Books)
                                               .FirstOrDefaultAsync(a => a.ID == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);  
        }

        public async Task<IActionResult> SearchBooks(int authorId, string searchTerm)
        {
            var author = await _context.authors.Include(a => a.Books)
                                               .FirstOrDefaultAsync(a => a.ID == authorId);

            if (author == null)
            {
                return NotFound();
            }

            var books = string.IsNullOrEmpty(searchTerm)
                ? author.Books
                : author.Books.Where(b => b.Title.Contains(searchTerm)).ToList();

            return PartialView("BookList", books);
        }



    }
}
