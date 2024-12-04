using Storybase.Core.Models;

namespace Storybase.Core.Interfaces;

public interface IWriterRepository : IRepository<Writer>
{
    //Get writer's literary works
    Task<IEnumerable<LiteraryWork>> GetLiteraryWorksAsync(int writerId);
}
