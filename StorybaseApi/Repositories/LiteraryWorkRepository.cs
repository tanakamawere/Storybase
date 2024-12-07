using Storybase.Core.DTOs;
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
                            .Include(n => n.Writer.User) // Eager load writer
                             .Include(lw => lw.Genres)// Eager load genres
                                .Include(lw => lw.Chapters)// Eager load chapters
                             .FirstOrDefaultAsync(lw => lw.Id == id);
    }

    public async Task<IEnumerable<LiteraryWork>> GetAllAsync()
    {
        return await _context.LiteraryWorks
            .Include(n => n.Writer.User)
            .Include(n => n.Chapters)
            .Include(n => n.Genres).ToListAsync();
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
                                          lw.Writer.User.Name.Contains(query) ||
                                          lw.Genres.Any(g => g.Name.Contains(query)) ||
                                          lw.Chapters.Any(c => c.Title.Contains(query) || c.Content.Contains(query)))
                             .ToListAsync();
    }

    public async Task<IEnumerable<LiteraryWork>> GetByTypeAsync(LiteraryWorkType type)
    {
        //Return particular type of literary work
        return await _context.LiteraryWorks
                             .Where(lw => lw.Type == type)
                             .Include(n => n.Genres)
                             .ToListAsync();
    }

    public async Task<IEnumerable<LiteraryWork>> GetByAuthorAsync(int authorId)
    {
        return await _context.LiteraryWorks
                             .Where(lw => lw.WriterId == authorId)
                             .Include(n => n.Genres)
                             .ToListAsync();
    }

    public async Task<IEnumerable<LiteraryWork>> GetByTitleAsync(string title)
    {
        return await _context.LiteraryWorks
                       .Where(lw => lw.Title == title)
                       .Include(n => n.Genres)
                       .ToListAsync();
    }

    public async Task SoftDelete(int id)
    {
        var entity = await _context.LiteraryWorks.FindAsync(id);
        if (entity != null)
        {
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }

    public async Task Unarchive(int id)
    {
        var entity = await _context.LiteraryWorks.FindAsync(id);
        if (entity != null)
        {
            entity.IsDeleted = false;
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddDtoAsync(LiteraryWorkDto entity)
    {
        LiteraryWork literaryWork = new()
        {
            Title = entity.Title,
            Summary = entity.Summary,
            CoverImageUrl = entity.CoverImageUrl,
            Type = entity.Type,
            IsFree = entity.IsFree,
            FreePreviewPercentage = entity.FreePreviewPercentage,
            Writer = await _context.Writers.Where(x => x.User.Auth0UserId == entity.Auth0Id).FirstAsync(),
            Chapters = entity.Chapters,
            ProgressiveWriting = entity.ProgressiveWriting,
            Completed = entity.Completed,
            IsDeleted = entity.IsDeleted
        };

        // Attach existing genres to the context
        literaryWork.Genres = [];
        foreach (var genreDto in entity.Genres)
        {
            var genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.Id == genreDto.Id);

            if (genre != null)
            {
                _context.Attach(genre); // Attach the existing genre
                literaryWork.Genres.Add(genre);
            }
        }

        await _context.LiteraryWorks.AddAsync(literaryWork);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDtoAsync(LiteraryWorkDto entity)
    {
        LiteraryWork literaryWork = await _context.LiteraryWorks.FindAsync(entity.Id);
        if (literaryWork != null)
        {
            literaryWork.Title = entity.Title;
            literaryWork.Summary = entity.Summary;
            literaryWork.CoverImageUrl = entity.CoverImageUrl;
            literaryWork.Type = entity.Type;
            literaryWork.IsFree = entity.IsFree;
            literaryWork.FreePreviewPercentage = entity.FreePreviewPercentage;
            literaryWork.Writer = await _context.Writers.Where(x => x.User.Auth0UserId == entity.Auth0Id).FirstAsync();

            // Attach existing genres to the context
            literaryWork.Genres = [];
            foreach (var genreDto in entity.Genres)
            {
                var genre = await _context.Genres
                    .FirstOrDefaultAsync(g => g.Id == genreDto.Id);

                if (genre != null)
                {
                    _context.Attach(genre); // Attach the existing genre
                    literaryWork.Genres.Add(genre);
                }
            }

            literaryWork.Chapters = entity.Chapters;
            literaryWork.ProgressiveWriting = entity.ProgressiveWriting;
            literaryWork.Completed = entity.Completed;
            literaryWork.IsDeleted = entity.IsDeleted;
            await _context.SaveChangesAsync();
        }
    }
}
