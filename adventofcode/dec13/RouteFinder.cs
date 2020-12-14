using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec13
{
    class RouteFinder
    {
        public (Bus bus, int waitTime)FindRoute(int target, IEnumerable<Bus> buses)
        {
            var bus = buses
                .Where(x => !x.IsOutOfOrder)
                .OrderBy(x => x.FindNearestDepartFromTimestamp(target))
                .First();
            var waitTime = bus.FindNearestDepartFromTimestamp(target) - target;
            return (bus, waitTime);
        }

        public long FindTimestampOfMagicHour(Bus[] buses)
        {
            // J'ai regardé des idées ailleurs pour trouvé ça :(
            return buses
                .Select((b, i) => (bus: b, i))
                .Where(x => !x.bus.IsOutOfOrder)
                .Aggregate((timestamp: 0L, step: 1L), (acc, curr) => (
                    timestamp: Enumerable.Range(0, int.MaxValue)
                        .Select(n => acc.timestamp + (acc.step * n))
                        .First((n) => (n + curr.i) % curr.bus.ID == 0),
                    step: acc.step * curr.bus.ID))
                .timestamp;
        }
    }
}
