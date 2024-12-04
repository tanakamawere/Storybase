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
}
