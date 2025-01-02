using Storybase.Core.Interfaces;
using Storybase.Core.Models.Payouts;

namespace StorybaseApi.Repositories;

public class UserPayoutMethodsRepository : GenericRepository<UserPayoutChoice>, IUserPayoutMethodsRepository
{
    private readonly AppDbContext context;
    private string authId;

    public UserPayoutMethodsRepository(AppDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<UserPayoutChoice>> GetPayoutMethodsAsync(string authId)
    {
        return await context.UserPayoutChoices.Where(x => x.User.Auth0UserId == authId).ToListAsync();
    }

    public async Task AddAsync(UserPayoutChoice entity)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Auth0UserId == authId);
        entity.User = user;

        await base.AddAsync(entity);
    }

    public async Task UpdateAsync(UserPayoutChoice entity)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Auth0UserId == authId);
        entity.User = user;
        await base.UpdateAsync(entity);
    }
}
