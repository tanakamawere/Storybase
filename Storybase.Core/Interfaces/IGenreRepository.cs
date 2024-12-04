using Storybase.Core.Models;

namespace Storybase.Core.Interfaces;

public interface IGenreRepository
{
    Task<Genre> GetByIdAsync(int id);
    Task<IEnumerable<Genre>> GetAllAsync();
}


