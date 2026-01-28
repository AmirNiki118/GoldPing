using GoldAlert.Domain.Common;
using GoldAlert.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldAlert.Domain.Alerts
{
    public class PriceAlert : BaseEntity
    {
        public Guid UserId { get; private set; }
        public decimal TargetPrice { get; private set; }
        public AlertStatus Status { get; private set; }

        private PriceAlert() { }

        public PriceAlert(Guid userId, decimal targetPrice)
        {
            if (targetPrice <= 0)
                throw new ArgumentException("Target price must be greater than zero");

            UserId = userId;
            TargetPrice = targetPrice;
            Status = AlertStatus.Pending;
        }

        public bool ShouldTrigger(decimal currentPrice)
        {
            return Status == AlertStatus.Pending &&
                   currentPrice >= TargetPrice;
        }

        public void Trigger()
        {
            if (Status != AlertStatus.Pending)
                throw new InvalidOperationException("Alert is not pending");

            Status = AlertStatus.Triggered;
        }

        public void Cancel()
        {
            if (Status == AlertStatus.Triggered)
                throw new InvalidOperationException("Triggered alert cannot be canceled");

            Status = AlertStatus.Canceled;
        }
    }
}
