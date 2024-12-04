using Storybase.Core.Interfaces;
using Storybase.Core.Models;

namespace StorybaseApi.Repositories;

public class LiteraryWorkRepository : ILiteraryWorkRepository
{
    private readonly AppDbContext _context;

    public LiteraryWorkRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<LiteraryWork> GetByIdAsync(int id)
    {
        return await _context.LiteraryWorks
                             .Include(lw => lw.Genres)  // Eager load genres
                             .FirstOrDefaultAsync(lw => lw.Id == id);
    }

    public async Task<IEnumerable<LiteraryWork>> GetAllAsync()
    {
        return await _context.LiteraryWorks.ToListAsync();
    }

    public async Task<IEnumerable<LiteraryWork>> GetByGenreAsync(int genreId)
    {
        return await _context.LiteraryWorks
                             .Where(lw => lw.Genres.Any(g => g.Id == genreId))
                             .ToListAsync();
    }

    public async Task AddAsync(LiteraryWork entity)
    {
        await _context.LiteraryWorks.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(LiteraryWork entity)
    {
        _context.LiteraryWorks.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.LiteraryWorks.FindAsync(id);
        if (entity != null)
        {
            _context.LiteraryWorks.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<LiteraryWork>> SearchAsync(string query)
    {
        //Return all literary works that contain the query in their title, writer, genre or chapter
        return await _context.LiteraryWorks
                             .Where(lw => lw.Title.Contains(query) ||
                                          lw.Writer.Name.Contains(query) ||
                                          lw.Genres.Any(g => g.Name.Contains(query)) ||
                                          lw.Chapters.Any(c => c.Title.Contains(query) || c.Content.Contains(query)))
                             .ToListAsync();
    }

    public async Task<IEnumerable<LiteraryWork>> GetByTypeAsync(LiteraryWorkType type)
    {
        //Return particular type of literary work
        return await _context.LiteraryWorks
                             .Where(lw => lw.Type == type)
                             .ToListAsync();
    }

    public async Task<IEnumerable<LiteraryWork>> GetByAuthorAsync(int authorId)
    {
        return await _context.LiteraryWorks
                             .Where(lw => lw.WriterId == authorId)
                             .ToListAsync();
    }

    public async Task<IEnumerable<LiteraryWork>> GetByTitleAsync(string title)
    {
        return await _context.LiteraryWorks
                       .Where(lw => lw.Title == title)
                       .ToListAsync();
    }
}
