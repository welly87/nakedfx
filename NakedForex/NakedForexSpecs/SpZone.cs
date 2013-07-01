using System;

namespace NakedForexSpecs
{
    public class SpZone
    {
        private readonly double _price;
        private int _touch;

        public int Touch
        {
            get { return _touch; }
        }

        public SpZone(double price)
        {
            _price = price;
        }

        public bool Contains(double orderedTurningPoint)
        {
            return Math.Abs((int)(_price * 1000) - (int)(orderedTurningPoint * 1000)) < 10;
        }

        public void Add(double orderedTurningPoint)
        {
            _touch++;
        }

        public double Price { get { return _price; } }

        public override string ToString()
        {
            return _price + " " + _touch;
        }
    }
}