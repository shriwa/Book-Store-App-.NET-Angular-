using book_store_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace book_store_api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
