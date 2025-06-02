using AutoMapper;
using BookHavenWebAPI.Core.DataTransferObjects;
using BookHavenWebAPI.Database;
using BookHavenWebAPI.Database.Entities; 
using Microsoft.EntityFrameworkCore;
using Moq;
using BookHavenWebAPI.CQS.Handlers.QueryHandlers.BookQueryHandlers;
using BookHavenWebAPI.CQS.Queries.BookQueires;
using FluentAssertions;

namespace BookHavenWebAPI.Tests.QueryHandlers.BookQueryHandlers
{
    public class GetAllBooksQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsMappedBookDtos_WhenBooksExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BookHavenContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new BookHavenContext(options);
            context.Books.AddRange(
                new Book { Id = 1, Name = "Book A", Description = "Description 1", Author = "Author 1" , GenreId = 1},
                new Book { Id = 2, Name = "Book B", Description = "Description 2", Author = "Author 2", GenreId = 2 }
            );
            await context.SaveChangesAsync();

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<BookDTO>(It.IsAny<Book>()))
                .Returns<Book>(b => new BookDTO { Id = b.Id, Name = b.Name , Description = b.Description, Author = b.Author, GenreId = b.GenreId });

            var handler = new GetAllBooksQueryHandler(context, mockMapper.Object);

            // Act
            var result = await handler.Handle(new GetAllBooksQuery(), CancellationToken.None);


            // Assert
            result.Should().HaveCount(2);
            result[0].Id.Should().Be(1); 
            result[0].Name.Should().Be("Book A");
            result[0].Description.Should().Be("Description 1");
            result[0].Author.Should().Be("Author 1");
            result[0].GenreId.Should().Be(1);

            result[1].Id.Should().Be(2); 
            result[1].Name.Should().Be("Book B");
            result[1].Description.Should().Be("Description 2");
            result[1].Author.Should().Be("Author 2");
            result[1].GenreId.Should().Be(2);
             
        }
    }
}
