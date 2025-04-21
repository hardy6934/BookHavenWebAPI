using BookHavenWebAPI.Database.Entities;
using Microsoft.EntityFrameworkCore; 

namespace BookHavenWebAPI.Database
{
    public class BookHavenContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Roles { get; set; }
        public DbSet<Genre> Chats { get; set; } 
        public DbSet<RefreshToken> RefreshTokens { get; set; } 

        public BookHavenContext(DbContextOptions<BookHavenContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
