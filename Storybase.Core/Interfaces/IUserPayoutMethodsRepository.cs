using Storybase.Core.Models.Payouts;

namespace Storybase.Core.Interfaces;

public interface IUserPayoutMethodsRepository : IRepository<UserPayoutChoice>
{
    //Get all payout methods for a user
    Task<IEnumerable<UserPayoutChoice>> GetPayoutMethodsAsync(string authId);
}
