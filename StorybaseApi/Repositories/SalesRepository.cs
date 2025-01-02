using Storybase.Core.DTOs;
using Storybase.Core.Interfaces;

namespace StorybaseApi.Repositories;

public class SalesRepository : ISalesRepository
{
    private readonly AppDbContext context;
    public SalesRepository(AppDbContext _context)
    {
        context = _context;
    }
    public async Task<SalesPageDto> GetSalesPageDto(string authId)
    {
        try
        {
            SalesPageDto salesPageDto = new()
            {
                //Get purchases done with the writer's auth id
                Purchases = await context.Purchases.Where(a => a.LiteraryWork.Writer.User.Auth0UserId == authId).ToListAsync(),
                //Get the history of payouts
                PayoutRequests = await context.PayoutRequests.Where(a => a.User.Auth0UserId == authId).ToListAsync()
            };

            salesPageDto.AvailableBalance = salesPageDto.Purchases.Sum(item => item.Amount);

            return salesPageDto;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
