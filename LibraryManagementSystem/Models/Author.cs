using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManagementSystem.Models
{
    public class Author
    {
        [Required]
        int id;
        string name;
        string biography;
        DateTime birthdate;
        List<Book> books;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Biography { get => biography; set => biography = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
        public List<Book> Books { get => books; set => books = value; }
    }
}
