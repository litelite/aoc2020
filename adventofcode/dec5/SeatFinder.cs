using adventofcode.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace adventofcode.dec5
{
    public class SeatFinder
    {
        public const int NbRows = 128;
        public const int NbColumns = 8;
        private readonly FileReader _fileReader = new FileReader();

        public int FindSeat()
        {
            var seats = new HashSet<int>();

            foreach (var line in _fileReader.ReadLineByLine("assets/dec5.txt"))
            {
                var row = FindRow(line.Take(7), 0, NbRows - 1);
                var column = FindColumn(line.Skip(7), 0, NbColumns - 1);
                var seatId = ComputeSeatId(row, column);
                seats.Add(seatId);
            }

            for (var i = 0; i < NbRows; i++)
            {
                for (var j = 0; j < NbColumns; j++)
                {
                    var seatId = ComputeSeatId(i, j);
                    if (!seats.Contains(seatId) 
                        && seats.Contains(seatId + 1) 
                        && seats.Contains(seatId - 1))
                        return seatId;
                }
            }

            throw new ArgumentException("NO ANSWER");
        }

        private int ComputeSeatId(int row, int column)
        {
            return (row * 8) + column;
        }

        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public int FindRow(IEnumerable<char> input, int min, int max)
        {
            if (min == max) return min;
            var command = input.FirstOrDefault();
            if (command == 'F') return FindRow(input.Skip(1), min, max - (int)Math.Ceiling((max - min) / 2f));
            if (command == 'B') return FindRow(input.Skip(1), min + (int)Math.Ceiling((max - min) / 2f), max);
            throw new ArgumentException("NO ANSWER");
        }

        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public int FindColumn(IEnumerable<char> input, int min, int max)
        {
            if (min == max) return min;
            var command = input.FirstOrDefault();
            if (command == 'L') return FindColumn(input.Skip(1), min, max - (int)Math.Ceiling((max - min) / 2f));
            if (command == 'R') return FindColumn(input.Skip(1), min + (int)Math.Ceiling((max - min) / 2f), max);
            throw new ArgumentException("NO ANSWER");
        }
    }
}
