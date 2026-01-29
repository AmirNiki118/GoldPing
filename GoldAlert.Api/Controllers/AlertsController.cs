using GoldAlert.Application.Alerts.CreateAlert;
using GoldAlert.Application.Contracts.Persistence;
using GoldAlert.Application.Alerts.CreateAlert;
using GoldAlert.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/alerts")]
public class AlertsController : ControllerBase
{
    private readonly IPriceAlertRepository _alertRepo;

    public AlertsController(IPriceAlertRepository alertRepo)
    {
        _alertRepo = alertRepo;
    }

    [HttpPost]
    public async Task<IActionResult> Create(decimal targetPrice)
    {
        // موقت: UserId فیک
        var userId = Guid.NewGuid();

        var alert = new CreateAlertHandler(_alertRepo);
        var result = await alert.Handle(new CreateAlertCommand(userId, targetPrice));

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok();
    }
}
