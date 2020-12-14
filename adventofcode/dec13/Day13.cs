using adventofcode.utils;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec13
{
    public class Day13
    {
        private readonly IFileReader _fileReader;
        private readonly RouteFinder _routeFinder = new RouteFinder();

        public Day13(IFileReader fileReader = null)
        {
            _fileReader = fileReader ?? new FileReader();
        }

        public (int, long) GetAnswers()
        {
            var (target, buses) = ParseInput();

            return (Part1(target, buses), _routeFinder.FindTimestampOfMagicHour(buses));
        }

        private int Part1(int target, IEnumerable<Bus> buses)
        {
            var (bus, waitTime) = _routeFinder.FindRoute(target, buses);
            return bus.ID * waitTime;
        }

        private (int target, Bus[] buses) ParseInput()
        {
            var lines = _fileReader.ReadLineByLine("assets/dec13.txt").ToArray();
            var target = int.Parse(lines[0]);
            var buses = lines[1].Split(',')
                .Select(x => x == "x" ? Bus.OutOfOrder() : new Bus(int.Parse(x)))
                .ToArray();
            return (target, buses);
        }
    }
}
