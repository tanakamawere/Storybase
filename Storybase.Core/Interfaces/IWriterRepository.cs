using Storybase.Core.Models;

namespace Storybase.Core.Interfaces;

public interface IWriterRepository : IRepository<Writer>
{
    //Get writer's literary works
    Task<IEnumerable<LiteraryWork>> GetLiteraryWorksAsync(int writerId);
    Task<IEnumerable<LiteraryWork>> GetLiteraryWorksByAuthIdAsync(string auth0Id);
    //Check if username is taken
    Task<bool> IsUserNameTakenAsync(string userName);
    //Check if the user already has a writer profile
    Task<bool> HasWriterProfileAsync(string userId);
}
