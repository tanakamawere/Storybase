using Storybase.Core.DTOs;

namespace Storybase.Core.Interfaces;

public interface ISalesRepository
{
    Task<SalesPageDto> GetSalesPageDto(string authId);
}
