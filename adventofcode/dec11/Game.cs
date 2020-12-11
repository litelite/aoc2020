using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec11
{
    class Game
    {
        public int GetOccupiedSeatsAfterStabilisation(Dictionary<Point, SeatStatus> board)
        {
            Dictionary<Point, SeatStatus> previous;
            Dictionary<Point, SeatStatus> current = board;
            bool changed;
            do
            {
                changed = false;
                previous = current;
                current = new Dictionary<Point, SeatStatus>(previous.Count);
                foreach (var (p, v) in previous)
                {
                    var adjacents = GetAdjacents(previous, p);
                    switch (v)
                    {
                        case SeatStatus.Empty when adjacents == 0:
                            current[p] = SeatStatus.Occupied;
                            changed = true;
                            break;
                        case SeatStatus.Occupied when adjacents >= 4:
                            current[p] = SeatStatus.Empty;
                            changed = true;
                            break;
                        default:
                            current[p] = v;
                            break;
                    }
                }
            } while (changed);

            return current.Count(x => x.Value == SeatStatus.Occupied);
        }

        private int GetAdjacents(Dictionary<Point, SeatStatus> board, Point target)
        {
            bool IsOccupied(Point x)
            {
                if (board.TryGetValue(x, out var v)) return v == SeatStatus.Occupied;
                return false;
            }

            return new[]
            {
                IsOccupied(target with {X = target.X - 1, Y = target.Y - 1}),
                IsOccupied(target with {Y = target.Y - 1}),
                IsOccupied(target with {X = target.X + 1, Y = target.Y - 1}),
                IsOccupied(target with {X = target.X - 1}),
                IsOccupied(target with {X = target.X + 1}),
                IsOccupied(target with {X = target.X - 1, Y = target.Y + 1}),
                IsOccupied(target with {Y = target.Y + 1}),
                IsOccupied(target with {X = target.X + 1, Y = target.Y + 1}),
            }.Count(x => x);
        }
    }
}
