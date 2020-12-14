using System;

namespace adventofcode.dec13
{
    class Bus
    {
        public int ID => _interval;

        private readonly int _interval;

        public Bus(int interval)
        {
            _interval = interval;
        }

        public static Bus OutOfOrder()
        {
            return new Bus(int.MaxValue);
        }

        public bool IsOutOfOrder => _interval == int.MaxValue;

        public int FindNearestDepartFromTimestamp(long timestamp)
        {
            return (int) Math.Ceiling(timestamp / (double)_interval) * _interval;
        }
    }
}
