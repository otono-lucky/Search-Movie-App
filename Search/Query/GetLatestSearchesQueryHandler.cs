using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie_App.Context;
using Movie_App.Models;

namespace Movie_App.Search.Query
{
    public class GetLatestSearchesQueryHandler : IRequestHandler<GetLatestSearchesQuery, List<LatestSearch>>
    {
        private readonly ApplicationDbContext _context;

        public GetLatestSearchesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LatestSearch>> Handle(GetLatestSearchesQuery request, CancellationToken cancellationToken)
        {
            return await _context.LatestSearches
                .OrderByDescending(ls => ls.Id)
                .Take(5)
                .ToListAsync();
        }
    }
}
