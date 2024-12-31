using Storybase.Core.Interfaces;
using Storybase.Core.Models;

namespace StorybaseApi.Repositories;

public class PaymentsRepository : GenericRepository<Payments>, IPaymentsRepository
{
    private readonly AppDbContext context;
    public PaymentsRepository(AppDbContext _context) : base(_context)
    {
        context = _context;
    }
    public async Task<Payments> GetPaymentByPollLink(string pollLink)
    {
        return await context.Payments
            .Where(p => p.PollUrl == pollLink)
            .FirstOrDefaultAsync();
    }
}
