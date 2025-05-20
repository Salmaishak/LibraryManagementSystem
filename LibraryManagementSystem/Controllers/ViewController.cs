using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult ViewAuthor()
        {

            return View();
        }

        public IActionResult ViewBook()
        {
            return View();

        }

           
    }
}
