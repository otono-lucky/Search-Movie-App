using MediatR;
using Movie_App.Models;

namespace Movie_App.Search.Query
{
    public class GetLatestSearchesQuery : IRequest<List<LatestSearch>>
    {
        public int QueryId { get; set; }
    }
}
