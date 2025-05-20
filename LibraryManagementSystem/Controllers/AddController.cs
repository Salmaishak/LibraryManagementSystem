using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class AddController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddController(ApplicationDbContext context)
        {
            _context = context;
        }


        public  IActionResult AddAuthor( Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
                 _context.SaveChanges(); 
            
            }
            return View(author);  
        }

     
      

    }
}
