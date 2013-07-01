
namespace NakedTrader
{
    class Program
    {
        static void Main(string[] args)
        {
            var zoneDetector = new ZoneDetector();
            
            var detector = new KangarooTailDetector(zoneDetector);
            detector.Start();

            var firstCandle = new Candle();
            detector.AddNewCandle(firstCandle);

            var secondCandle = new Candle();
            detector.AddNewCandle(secondCandle);

            
        }
    }
}
