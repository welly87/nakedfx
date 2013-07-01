namespace NakedTrader
{
    public class PendingOrder
    {
        public double Entry { get; set; }

        public double Target { get; set; }

        public double StopLoss { get; set; }

        // expiracy setting, after one bar or something like that
    }
}