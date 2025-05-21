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

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {

            _context.Add(book);
            _context.SaveChanges();
            var books = await _context.books.ToListAsync();
            return View("Book", books);

        }
            

        public async Task<IActionResult> ViewBook()
        {
            var books = await _context.books.ToListAsync();
            return View("Book",books);

        }

        [HttpGet]
        public async Task<IActionResult> EditBookGet(int id)
        {
            var book = await _context.books.FindAsync(id);

            if (book == null)
            {
                return NoContent();
            }

            return View("EditBook", book);
        }



        [HttpPost]
        public async Task<IActionResult> EditBook(Book book)
        {
            _context.books.Update(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("ViewBook");



        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(int ID)
        {
            var book = await _context.books.FindAsync(ID);

            if (book != null)
            {
                _context.books.Remove(book);
                await _context.SaveChangesAsync();
            }


            var books = await _context.books.ToListAsync();
            return View("Book", books);
        }




    }
}
