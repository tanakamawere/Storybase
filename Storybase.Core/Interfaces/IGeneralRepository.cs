using Storybase.Core.DTOs;

namespace Storybase.Core.Interfaces;

public interface IGeneralRepository
{
    Task<SearchDto> SearchApiAsync(string query);
}
