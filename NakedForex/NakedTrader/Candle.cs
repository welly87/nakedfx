namespace NakedTrader
{
    public class Candle
    {
        public double Open { get; set; }

        public double High { get; set; }

        public double Close { get; set; }

        public double Low { get; set; }

        public bool Engulf(Candle previousCandle)
        {
            // has higher high and lower low that previous candlestick
            return false;
        }

        public bool HasWideRange { get; set; }

        public bool IsBulish { get; set; }

        public bool CloseAlmostFull
        {
            // if the close is near midpoint return false
            get { return IsBulish ? CloseNearHigh : CloseNearLow; }
        }

        private bool CloseNearLow
        {
            get { throw new System.NotImplementedException(); }
        }

        private bool CloseNearHigh
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool IsKangooro
        {
            get
            {
                // 1. tail longer than body
                // 2. long tail
                // 3. small/tiny body
                // 4. [open n close] body => near bottom third == near the extereme end
                // 5. longer 
                return false;
            }
        }

        public bool IsBodyInside(Candle previousCandle)
        {
            throw new System.NotImplementedException();
        }
    }
}