namespace NakedTrader
{
    internal class KangarooTailDetector
    {
        private readonly ZoneDetector _zoneDetector;
        private Candle _currentCandle;
        private Candle _previousCandle;
        private readonly CandleCollection _latestCandles;

        public KangarooTailDetector(ZoneDetector zoneDetector)
        {
            _zoneDetector = zoneDetector;
            _latestCandles = new CandleCollection(10);
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

            AnalyzeKangarooTailFormation();
        }

        private void AnalyzeKangarooTailFormation()
        {
            if (!IsKangarooTailFormation()) return;

            // should decide is this a bullish kangaroo (sell signal) or bearish kangaroo (buy signal)

            var entry = CalculateEntry();

            var stopLoss = CalculateStopLoss();

            var target = CalculateTarget();

            // should trigger on the next candle
        }

        private double CalculateTarget()
        {
            throw new System.NotImplementedException();
        }

        private double CalculateStopLoss()
        {
            throw new System.NotImplementedException();
        }

        private double CalculateEntry()
        {
            throw new System.NotImplementedException();
        }

        protected double Points { get { return 0.0001; } }

        private bool IsKangarooTailFormation()
        {
            if (!_currentCandle.IsKangooro) return false;

            if (!_zoneDetector.InTheZone(_currentCandle)) return false;

            if (!_currentCandle.IsTheLargestFrom(_latestCandles)) return false;

            if (!_currentCandle.IsBodyInside(_previousCandle)) return false;

            if (!HasRoomToTheLeft) return false;

            // is in the strong uptrend return false; // there's giant candle 
            //if (HasRoomToTheLeft)
            //{
                
            //}

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