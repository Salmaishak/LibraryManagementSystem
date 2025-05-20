using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data;

public class ApplicationDbContext : IdentityDbContext
{
   public DbSet<Author> authors { get; set; }
   public DbSet<Book> books { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
       
    }

}
