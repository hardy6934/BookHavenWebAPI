using AutoMapper;
using BookHavenWebAPI.CQS.Commands.AccountHandlers;
using BookHavenWebAPI.Database;
using BookHavenWebAPI.Database.Entities;
using MediatR;

namespace BookHavenWebAPI.CQS.Handlers.CommandHandlers.AccountCommandHandlers
{
    public class AddAccountCommandHandler: IRequestHandler<AddAccountCommand, int>
    {
        private readonly BookHavenContext context;
        private readonly IMapper mapper;
        public AddAccountCommandHandler(BookHavenContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<int> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            var entEntry = await context.Accounts.AddAsync(mapper.Map<Account>(request.accountDTO), cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return entEntry.Entity.Id; 
        }
    }
}
