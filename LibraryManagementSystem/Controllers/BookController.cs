using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {

            _context.Add(book);
            _context.SaveChanges();
            return View("Book",book);

        }
            

        public async Task<IActionResult> ViewBook()
        {
            var books = await _context.books.ToListAsync();
            return View("Book",books);

        }




    }
}
