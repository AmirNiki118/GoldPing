using GoldAlert.Application.Common;
using GoldAlert.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldAlert.Application.Alerts.CreateAlert
{
    public class CreateAlertHandler
    {
        private readonly IPriceAlertRepository _alertRepo;

        public CreateAlertHandler(IPriceAlertRepository alertRepo)
        {
            _alertRepo = alertRepo;
        }

        public async Task<Result> Handle(CreateAlertCommand command)
        {
            var alert = new PriceAlert(command.UserId, command.TargetPrice);

            await _alertRepo.AddAsync(alert);
            await _alertRepo.SaveChangesAsync();

            return Result.Success();
        }
    }
}
