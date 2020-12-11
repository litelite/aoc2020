using adventofcode.utils;
using System;
using System.Collections.Generic;

namespace adventofcode.dec11
{
    public class Day11
    {
        private readonly IFileReader _fileReader;

        public Day11(IFileReader fileReader = null)
        {
            _fileReader = fileReader ?? new FileReader();
        }

        public (int, int) GetAnswers()
        {
            var game = new Game();
            var board = ParseBoard();
            return (game.GetOccupiedSeatsAfterStabilisation(board), 0);
        }

        private Dictionary<Point, SeatStatus> ParseBoard()
        {
            Dictionary<Point, SeatStatus> board = new Dictionary<Point, SeatStatus>();
            var row = 0;

            foreach (var line in _fileReader.ReadLineByLine("assets/dec11.txt"))
            {
                for (var i = 0; i < line.Length; i++)
                {
                    var p = new Point {X = i, Y = row};
                    var v = ParseSeat(line[i]);
                    if(v != SeatStatus.Floor) board.Add(p, v);
                }

                row++;
            }

            return board;
        }

        private SeatStatus ParseSeat(char seat) => seat switch
        {
            'L' => SeatStatus.Empty,
            '#' => SeatStatus.Occupied,
            '.' => SeatStatus.Floor,
            _ => throw new ArgumentException($"INVALID SEAT {seat}")
        };
    }
}
