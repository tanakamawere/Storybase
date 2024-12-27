using Storybase.Core.DTOs;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;

namespace StorybaseApi.Repositories;

public class WriterRepository : GenericRepository<Writer>, IWriterRepository
{
    private readonly AppDbContext _context;
    public WriterRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LiteraryWork>> GetLiteraryWorksAsync(int writerId)
    {
        var writer = await _context.Writers.Include(x => x.LiteraryWorks).FirstOrDefaultAsync(x => x.Id == writerId);
        return writer.LiteraryWorks;
    }

    public async Task<IEnumerable<LiteraryWork>> GetLiteraryWorksByAuthIdAsync(string auth0Id)
    {
        var literary = await _context.LiteraryWorks.Where(x => x.Writer.User.Auth0UserId == auth0Id)
            .Include(n => n.Genres)
            .ToListAsync();
        return literary;
    }

    public async Task<WriterProfileDto> GetWriterProfileById(int id)
    {
        //Get writer profile by id
        return new WriterProfileDto
        {
            Writer = await _context.Writers.FindAsync(id),
            LiteraryWorks = await _context.LiteraryWorks
                             .Where(lw => lw.WriterId == id)
                             .Include(n => n.Genres)
                             .ToListAsync()
        };
    }

    public async Task<WriterProfileDto> GetWriterProfileByUserName(string userName)
    {
        Writer writer = await _context.Writers.FirstOrDefaultAsync(x => x.UserName.ToLower() == userName.ToLower());

        return new WriterProfileDto
        {
            Writer = writer,
            LiteraryWorks = await _context.LiteraryWorks
                             .Where(lw => lw.WriterId == writer.Id)
                             .Include(n => n.Genres)
                             .ToListAsync()
        };
    }

    public async Task<bool> HasWriterProfileAsync(string userId)
    {
        //Check if the user already has a writer profile
        return await _context.Writers.AnyAsync(x => x.User.Auth0UserId == userId);
    }

    public async Task<bool> IsUserNameTakenAsync(string userName)
    {
        //Check if username is taken
        return await _context.Writers.AnyAsync(x => x.UserName == userName);
    }
}
