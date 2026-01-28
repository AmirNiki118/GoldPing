using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldAlert.Infrastructure.Persistence.Repositories
{
    public class PriceAlertRepository : IPriceAlertRepository
    {
        private readonly GoldPingDbContext _context;

        public PriceAlertRepository(GoldPingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PriceAlert alert)
            => await _context.PriceAlerts.AddAsync(alert);

        public async Task<List<PriceAlert>> GetPendingAsync()
            => await _context.PriceAlerts
                .Where(x => x.Status == AlertStatus.Pending)
                .ToListAsync();

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
