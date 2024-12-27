using Storybase.Core.Interfaces;
using Storybase.Core.Models;

namespace StorybaseApi.Repositories;

public class ChapterRepository : IRepository<Chapter>
{
    private readonly AppDbContext context;

    public ChapterRepository(AppDbContext _context)
    {
        context = _context;
    }

    public async Task AddAsync(Chapter entity)
    {
        await context.Chapters.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await context.Chapters.FindAsync(id);
        if (entity != null)
        {
            context.Chapters.Remove(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Chapter>> GetAllAsync()
    {
        return await context.Chapters.ToListAsync();
    }

    public async Task<Chapter> GetByIdAsync(int id)
    {
        return await context.Chapters.Include(m => m.LiteraryWork).ThenInclude(m => m.Writer)
            .FirstAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Chapter>> SearchAsync(string query)
    {
        return await context.Chapters
            .Where(c => c.Title.Contains(query))
            .ToListAsync();
    }

    public async Task UpdateAsync(Chapter entity)
    {
        context.Chapters.Update(entity);
        await context.SaveChangesAsync();
    }
}
