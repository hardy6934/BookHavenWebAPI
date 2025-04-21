using AutoMapper;
using BookHaven.CQS.Commands;
using BookHaven.Database;
using BookHaven.Database.Entities;
using MediatR; 

namespace BookHaven.CQS.Handlers.CommandHandlers
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
            var entEntry = await context.Accounts.AddAsync(mapper.Map<Account>(request.accountDTO));
            await context.SaveChangesAsync(cancellationToken);

            return entEntry.Entity.Id; 
        }
    }
}
