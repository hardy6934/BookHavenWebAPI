using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Commands.RefreshTokenCommands
{
    public class RemoveRangeRefreshTokensCommand: IRequest<int>
    {
        public List<RefreshTokenDTO> refreshTokenDTOs { get; set; }
    }
}
