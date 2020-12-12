using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec11
{
    class GameOfLife
    {
        public int GetOccupiedSeatsAfterStabilisation(SeatStatus[,] board) =>
            RunLife(board, 4, GetImmediateAdjacents);

        public int GetOccupiedSeatsAfterStabilisation2(SeatStatus[,] board) =>
            RunLife(board, 5, GetLineOfSightAdjacents);

        private int RunLife(SeatStatus[,] board, int leaveThreshold, Func<SeatStatus[,], int, int, int> getAdjacents)
        {
            var current = board;
            bool changed;

            do
            {
                changed = false;
                var previous = current;
                current = new SeatStatus[previous.GetLength(0), previous.GetLength(1)];

                for (var x = 0; x < previous.GetLength(0); x++)
                {
                    for (var y = 0; y < previous.GetLength(1); y++)
                    {
                        var adjacents = getAdjacents(previous, x, y);
                        switch (previous[x, y])
                        {
                            case SeatStatus.Empty when adjacents == 0:
                                current[x, y] = SeatStatus.Occupied;
                                changed = true;
                                break;
                            case SeatStatus.Occupied when adjacents >= leaveThreshold:
                                current[x, y] = SeatStatus.Empty;
                                changed = true;
                                break;
                            default:
                                current[x, y] = previous[x, y];
                                break;
                        }
                    }
                }
            } while (changed);

            return AsEnumerable(current).Count(x => x == SeatStatus.Occupied);
        }

        private int GetImmediateAdjacents(SeatStatus[,] board, int targetX, int targetY)
        {
            bool IsOccupied(int x, int y)
            {
                if (x >= 0 && x < board.GetLength(0) && y >= 0 && y < board.GetLength(1))
                    return board[x, y] == SeatStatus.Occupied;
                return false;
            }

            return new[]
            {
                IsOccupied(targetX - 1, targetY - 1),
                IsOccupied(targetX, targetY - 1),
                IsOccupied(targetX + 1, targetY - 1),
                IsOccupied(targetX - 1, targetY),
                IsOccupied(targetX + 1, targetY),
                IsOccupied(targetX - 1, targetY + 1),
                IsOccupied(targetX, targetY + 1),
                IsOccupied(targetX + 1, targetY + 1),
            }.Count(x => x);
        }

        private int GetLineOfSightAdjacents(SeatStatus[,] board, int targetX, int targetY)
        {
            var nbColumns = board.GetLength(0);
            var nbRows = board.GetLength(1);
            bool HasOccupiedInLine(int dx, int dy)
            {
                var x = targetX + dx;
                var y = targetY + dy;
                while(x >= 0 && x < nbColumns && y >= 0 && y < nbRows)
                {
                    if (board[x, y] == SeatStatus.Occupied)
                        return true;

                    if (board[x, y] == SeatStatus.Empty)
                        return false;

                    x += dx;
                    y += dy;
                }

                return false;
            }

            return new[]
            {
                HasOccupiedInLine(-1, -1),
                HasOccupiedInLine(0, -1),
                HasOccupiedInLine(1, -1),
                HasOccupiedInLine(-1, 0),
                HasOccupiedInLine(1, 0),
                HasOccupiedInLine(-1, 1),
                HasOccupiedInLine(0, 1),
                HasOccupiedInLine(1, 1),
            }.Count(x => x);
        }

        private IEnumerable<SeatStatus> AsEnumerable(SeatStatus[,] input)
        {
            var enumerator = input.GetEnumerator();
            while (enumerator.MoveNext()) yield return (SeatStatus)enumerator.Current;
        }
    }
}
