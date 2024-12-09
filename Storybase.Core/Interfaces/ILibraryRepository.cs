using Storybase.Core.DTOs;

namespace Storybase.Core.Interfaces;

public interface ILibraryRepository
{
    Task<LibraryDto> LibraryDto(string authUserId);
}
