namespace GoldAlert.Tests
{
    public class PriceAlert
    {
        [Fact]
        public void Alert_should_trigger_when_price_reaches_target()
        {
            var alert = new PriceAlert(Guid.NewGuid(), 5_000_000);

            var shouldTrigger = alert.ShouldTrigger(5_200_000);

            Assert.True(shouldTrigger);
        }
    }
}