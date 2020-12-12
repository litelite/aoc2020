using adventofcode.utils;
using System;
using System.Linq;

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
            var game = new GameOfLife();
            var board = ParseBoard();
            return (game.GetOccupiedSeatsAfterStabilisation(board), game.GetOccupiedSeatsAfterStabilisation2(board));
        }

        private SeatStatus[,] ParseBoard()
        {
            var board = _fileReader.ReadLineByLine("assets/dec11.txt")
                .Select(line => line.Select(ParseSeat).ToList()).ToList();

            return Utils.To2DArray(board);
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
