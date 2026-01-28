using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldAlert.Application.Contracts.Persistence
{
    public interface IPriceAlertRepository
    {
        Task AddAsync(PriceAlert alert);
        Task<List<PriceAlert>> GetPendingAsync();
        Task SaveChangesAsync();
    }
}
