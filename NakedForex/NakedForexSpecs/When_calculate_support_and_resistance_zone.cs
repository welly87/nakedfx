using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using System.Linq;

namespace NakedForexSpecs
{
    [TestFixture]
    public class When_calculate_support_and_resistance_zone
    {
        [Test]
        public void Should_find_turning_point()
        {
            var detector = new ZoneDetector();
            detector.AddClosePrice(1);
            detector.AddClosePrice(2);
            detector.AddClosePrice(3);
            detector.AddClosePrice(2);
            detector.AddClosePrice(1);
            
            Assert.AreEqual(3, detector.TurningPoints.First());
        }

        [Test]
        public void Should_find_all_turning_point()
        {
            var detector = new ZoneDetector();
            detector.AddClosePrice(1);
            detector.AddClosePrice(2);
            detector.AddClosePrice(3);
            detector.AddClosePrice(2);
            detector.AddClosePrice(1);
            detector.AddClosePrice(1);
            detector.AddClosePrice(2);
            detector.AddClosePrice(3);
            detector.AddClosePrice(4);
            detector.AddClosePrice(5);                                                                       
            detector.AddClosePrice(1);

            Assert.That(detector.TurningPoints, Is.EqualTo(new List<double> { 3, 1, 5 }));
        }

        [Test]
        public void Should_find_turning_point_for_all_close()
        {
            //var closes = File.ReadLines("EURUSD_DailyClose.txt");
            var closes = File.ReadLines("EURUSD_WeeklyClose.txt");

            var detector = new ZoneDetector();

            foreach (var close in closes)
            {
                detector.AddClosePrice(Convert.ToDouble(close));
            }

            Console.WriteLine(detector.TurningPoints.Count);
            
            detector.CalculateZones();

            
        }
    }
}