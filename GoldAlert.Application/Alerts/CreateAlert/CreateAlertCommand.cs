using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldAlert.Application.Alerts.CreateAlert
{
    public record CreateAlertCommand(Guid UserId, decimal TargetPrice);
}
