using BookHavenWebAPI.Database.Entities;
using BookHavenWebAPI.DataBase.Entities;
using Microsoft.EntityFrameworkCore; 

namespace BookHavenWebAPI.Database
{
    public class BookHavenContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionBook> CollectionBooks { get; set; }
        public DbSet<Genre> Genre { get; set; }  
        public DbSet<RefreshToken> RefreshTokens { get; set; } 

        public BookHavenContext(DbContextOptions<BookHavenContext> options)
            : base(options)
        { 

        }
    }
}
