
using AutoMapper;
using BookHavenWebAPI.CQS.Commands.BookCommands;
using BookHavenWebAPI.Database.Entities;
using BookHavenWebAPI.Database;
using MediatR;

namespace BookHavenWebAPI.CQS.Handlers.CommandHandlers.BookCommandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public UpdateBookCommandHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            context.Books.Update(mapper.Map<Book>(request.dto));
            return await context.SaveChangesAsync(cancellationToken); 
        }
    }
}
