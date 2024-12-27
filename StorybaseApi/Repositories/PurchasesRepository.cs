using Microsoft.EntityFrameworkCore;
using Storybase.Core.DTOs;
using Storybase.Core.Interfaces;
using Storybase.Core.Models;

namespace StorybaseApi.Repositories
{
    public class PurchasesRepository : GenericRepository<Purchase>, IPurchaseRepository
    {
        private readonly AppDbContext context;
        public PurchasesRepository(AppDbContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<PurchaseStatusDto> GetIfPurchaseByAuthUserIdAndLiteraryWorkIdAsync(PurchaseLitWorkDto purchaseLitWorkDto)
        {
            var purchase = await context.Purchases
                .Where(p => p.User.Auth0UserId == purchaseLitWorkDto.AuthUserId && p.LiteraryWorkId == purchaseLitWorkDto.LiteraryWorkId)
                .FirstOrDefaultAsync();

            PurchaseStatusDto purchaseStatusDto = new();

            if (purchase != null)
            {
                purchaseStatusDto.PurchaseId = purchase.Id;
                purchaseStatusDto.IsPurchased = true;
                purchaseStatusDto.PurchaseDate = purchase.PurchaseDate;
                return purchaseStatusDto;
            }
            else
            {
                purchaseStatusDto.IsPurchased = false;
                return purchaseStatusDto;
            }
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesByUser()
        {
            return await context.Purchases
                .Include(p => p.User)
                .Include(p => p.LiteraryWork)
                .ToListAsync();
        }

        public async Task AddPurchaseDtoAsync(PurchasesDto entity)
        {
            //Map the entity to the Purchase model
            var purchase = new Purchase
            {
                User = await context.Users.FirstOrDefaultAsync(u => u.Auth0UserId == entity.AuthUserId),
                LiteraryWorkId = entity.LiteraryWorkId,
                LiteraryWork = await context.LiteraryWorks.FirstOrDefaultAsync(lw => lw.Id == entity.LiteraryWorkId)
            };

            await context.AddAsync(purchase);
            await context.SaveChangesAsync();
        }
    }
}
