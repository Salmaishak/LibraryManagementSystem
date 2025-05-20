using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        [Required]
        int id;
        string title;
        string description;
        DateTime publishDate;
        int authorID;
        Author author;

        public int ID { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public DateTime PublishDate { get => publishDate; set => publishDate = value; }
        public int AuthorID { get => authorID; set => authorID = value; }
        public Author Author { get => author; set => author = value; }
    }
}
