using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie_App.Context;
using Movie_App.Models;

namespace Movie_App.Search.Command
{
    public class SaveLatestSearchCommandHandler : IRequestHandler<SaveLatestSearchCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public SaveLatestSearchCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(SaveLatestSearchCommand request, CancellationToken cancellationToken)
        {
            // Remove old searches if the count exceeds 5
            var latestSearches = await _context.LatestSearches.OrderByDescending(ls => ls.Id)
                .Skip(5)
                .ToListAsync();

            if (latestSearches.Any())
            {
                _context.LatestSearches.RemoveRange(latestSearches);
            }

            // Save the new search
            var latestSearch = new LatestSearch { Query = request.Query };
            _context.LatestSearches.Add(latestSearch);
            await _context.SaveChangesAsync();

            return latestSearch.Id;
        }
    }
}
