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
