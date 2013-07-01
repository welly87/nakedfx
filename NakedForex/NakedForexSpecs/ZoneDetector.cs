using System;
using System.Collections.Generic;
using System.Linq;

namespace NakedForexSpecs
{
    public class ZoneDetector
    {
        private Movement _latestMovement;
        private double _latestValue;
        private List<SpZone> _zones;

        public ZoneDetector()
        {
            TurningPoints = new List<double>();
        }

        public void AddClosePrice(double close)
        {
            var delta = close - _latestValue;
            var currentMovement = Movement.None;

            currentMovement = delta > 0 ? Movement.Up : Movement.Down;

            if (currentMovement != _latestMovement && !HasPreviousValue)
            {
                TurningPoints.Add(_latestValue);
            }

            _latestMovement = currentMovement;
            _latestValue = close;
        }

        private bool HasPreviousValue
        {
            get { return Math.Abs(_latestValue - 0) < Double.Epsilon; }
        }

        public IList<double> TurningPoints { get; set; }

        public void CalculateZones()
        {
            var orderedTurningPoints = TurningPoints.OrderBy(x => x);

            _zones = new List<SpZone>();

            var latestZone = new SpZone(0);

            foreach (var orderedTurningPoint in orderedTurningPoints)
            {
                if (latestZone.Contains(orderedTurningPoint))
                {
                    latestZone.Add(orderedTurningPoint);
                }
                else
                {
                    latestZone = new SpZone(orderedTurningPoint);
                    _zones.Add(latestZone);
                }
            }

            Console.WriteLine(_zones.Count);

            var orderstrength = _zones.OrderByDescending(x => x.Price);

            foreach (var spZone in orderstrength)
            {
                Console.WriteLine(spZone);
            }
        }


    }
}