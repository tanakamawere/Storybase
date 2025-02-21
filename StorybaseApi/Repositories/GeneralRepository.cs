using Storybase.Core.DTOs;
using Storybase.Core.Interfaces;

namespace StorybaseApi.Repositories;

public class GeneralRepository : IGeneralRepository
{
    private readonly AppDbContext context;

    public GeneralRepository(AppDbContext context)
    {
        this.context = context;
    }
    
    public async Task<SearchDto> SearchApiAsync(string query)
    {
        var literaryWorks = await context.LiteraryWorks
            .Include(s => s.Writer)
            .Include(s => s.Genres)
            .Where(lw => lw.Title.Contains(query) || lw.Summary.Contains(query))
            .Take(20)
            .ToListAsync();

        var writers = await context.Writers
            .Include(s => s.User)
            .Where(w => w.UserName.Contains(query) || w.Bio.Contains(query))
            .Take(10)
            .ToListAsync();

        var genres = await context.Genres
            .Where(g => g.Name.Contains(query))
            .Take(10)
            .ToListAsync();

        return new SearchDto
        {
            LiteraryWorks = literaryWorks,
            Writers = writers,
            Genres = genres
        };
    }
}
