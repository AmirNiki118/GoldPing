using GoldAlert.Application.Contracts.Persistence;
using GoldAlert.Application.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldAlert.Application.Alerts.CheckAlerts
{
    public class CheckAlertsHandler(IPriceAlertRepository _alertRepo, IGoldPriceService _goldService, ISmsService _sms)
    {
        public async Task Handle()
        {
            var currentPrice = await _goldService.Get18KGoldPriceAsync();
            var alerts = await _alertRepo.GetPendingAsync();

            foreach (var alert in alerts)
            {
                if (alert.ShouldTrigger(currentPrice))
                {
                    alert.Trigger();
                    // شماره موبایل بعداً از User میاد
                    await _sms.SendAsync("09xxxxxxxxx", "قیمت طلا رسید 🔔");
                }
            }

            await _alertRepo.SaveChangesAsync();
        }
    }
}
