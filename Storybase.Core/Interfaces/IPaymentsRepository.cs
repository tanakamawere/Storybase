using Storybase.Core.Models;

namespace Storybase.Core.Interfaces;

public interface IPaymentsRepository : IRepository<Payments>
{
    Task<Payments> GetPaymentByPollLink(string pollLink);
}
