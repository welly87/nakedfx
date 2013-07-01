using System;
using System.Collections.Generic;

namespace NakedForexSpecs
{
    public class ZoneDetector
    {
        private Movement _latestMovement;
        private double _latestValue;

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
    }
}