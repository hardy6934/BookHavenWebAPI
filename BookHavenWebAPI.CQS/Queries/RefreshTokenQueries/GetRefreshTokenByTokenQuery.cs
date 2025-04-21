

using BookHavenWebAPI.Core.DataTransferObjects;
using MediatR;

namespace BookHavenWebAPI.CQS.Queries.RefreshTokenQueries
{
    public class GetRefreshTokenByTokenQuery: IRequest<RefreshTokenDTO>
    {
        public Guid Token { get; set; }
    }
}
