namespace NakedTrader
{
    internal class BigShadowDetector
    {
        private readonly ZoneDetector _zoneDetector;
        private Candle _previousCandle;
        private Candle _currentCandle;
        private readonly CandleCollection _latestCandles;

        public BigShadowDetector(ZoneDetector zoneDetector)
        {
            _zoneDetector = zoneDetector;
            _latestCandles = new CandleCollection(5); // store last 5 candle // better > 10 candlestick
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void AddNewCandle(Candle candle)
        {
            if (_previousCandle == null)
            {
                _previousCandle = candle;
                _currentCandle = candle;
                return;
            }

            _previousCandle = _currentCandle;
            _currentCandle = candle;

            AnalyzeBigShadowFormation();
        }

        private void AnalyzeBigShadowFormation()
        {
            if (!IsBigShadowFormation()) return;

            // should decide is this a bearish big shadow or bullish big shadow

            var stopLoss = CalculateStopLoss();

            var entry = CalculateEntry();

            var target = CalculateTarget();
        }

        private double CalculateTarget()
        {
            var zone = _zoneDetector.GetNearestTargetFor(_currentCandle);
            if (_currentCandle.IsBulish)
                return zone - 100 * Points;

            return zone + 100 * Points;
        }

        private double CalculateEntry()
        {
            if (_currentCandle.IsBulish)
                return _currentCandle.High + 100 * Points;

            return _currentCandle.Low - 100 * Points;
        }

        private double CalculateStopLoss()
        {
            if (_currentCandle.IsBulish)
                return _currentCandle.Low - 100 * Points;
            
            return _currentCandle.High + 100 * Points;
        }

        protected double Points { get { return 0.0001; } }

        // need to have a percentage calculation for this big shadow

        // need to calculate probability and 

        private bool IsBigShadowFormation()
        {
            if (!_currentCandle.Engulf(_previousCandle)) return false;
            
            if (!_zoneDetector.InTheZone(_previousCandle, _currentCandle)) return false;

            if (!_currentCandle.IsTheLargestFrom(_latestCandles)) return false; // better > 10 candlestick

            if (!_currentCandle.HasWideRange) return false;

            if (!_currentCandle.CloseAlmostFull) return false;

            if (!HasRoomToTheLeft) return false;
            
            // in extreme high is more preferable. => this one make sure that we have to rank the setup

            // if InExteremeLow => is not traded > 7 candlestick to the left

            // 
            return true;
        }

        protected bool HasRoomToTheLeft
        {
            get 
            { 
                // get all previous candlestick 

                // see if there's no price action or candle on the left side of the _previousCandle

                // see if there's some space to the left

                // set the range about 1 month, weeks or so 
                return false;
            }
        }
    }
}