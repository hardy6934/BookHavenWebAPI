using AutoMapper;
using BookHavenWebAPI.CQS.Commands.BookCommands;
using BookHavenWebAPI.Database.Entities;
using BookHavenWebAPI.Database;
using MediatR;

namespace BookHavenWebAPI.CQS.Handlers.CommandHandlers.BookCommandHandlers
{
    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public RemoveBookCommandHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            context.Books.Remove(mapper.Map<Book>(request.dto));
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
