namespace NakedTrader
{
    internal class ZoneDetector
    {
        public bool InTheZone(Candle previous, Candle current)
        {
            return true;
        }

        public double GetNearestTargetFor(Candle currentCandle)
        {
            return currentCandle.IsBulish ? GetNearestResistanceZone(currentCandle.High) : GetNearestSupportZone(currentCandle.Low);
        }

        private double GetNearestSupportZone(double low)
        {
            throw new System.NotImplementedException();
        }

        private double GetNearestResistanceZone(double high)
        {
            throw new System.NotImplementedException();
        }

        public bool InTheZone(Candle currentCandle)
        {
            throw new System.NotImplementedException();
        }
    }
}