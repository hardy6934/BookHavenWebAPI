using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Commands.RefreshTokenCommands
{
    public class AddRefreshTokenCommand: IRequest<int>
    {
        public RefreshTokenDTO refreshTokenDTO { get; set; }
    }
}
