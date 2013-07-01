using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NakedTrader
{
    public static class CandlesExtensions
    {
        public static bool IsTheLargestFrom(this Candle candle, CandleCollection collection)
        {
            return collection.IsLargest(candle);
        }
    }
}
