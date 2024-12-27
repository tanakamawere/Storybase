using Storybase.Core.DTOs;
using Storybase.Core.Models;

namespace Storybase.Core.Interfaces;

public interface IPurchaseRepository : IRepository<Purchase>
{
    public Task<IEnumerable<Purchase>> GetPurchasesByUser();
    public Task<PurchaseStatusDto> GetIfPurchaseByAuthUserIdAndLiteraryWorkIdAsync(PurchaseLitWorkDto purchaseLitWorkDto);
    public Task AddPurchaseDtoAsync(PurchasesDto entity);
}
