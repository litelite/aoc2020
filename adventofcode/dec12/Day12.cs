using adventofcode.utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec12
{
    public class Day12
    {
        private readonly IFileReader _fileReader;

        public Day12(IFileReader fileReader = null)
        {
            _fileReader = fileReader ?? new FileReader();
        }

        public (int, int) GetAnswers()
        {
            var boat = new Boat();
            var instructions = ParseInstructions();

            return (boat.GetDistanceFromStart(instructions), 0);
        }

        private IEnumerable<(Instruction, int)> ParseInstructions()
        {
            return _fileReader.ReadLineByLine("assets/dec12.txt")
                .Select((line) => (ParseInstruction(line.First()), int.Parse(line.Substring(1))));
        }

        private Instruction ParseInstruction(char c)
        {
            return c switch
            {
                'N' => Instruction.North,
                'S' => Instruction.South,
                'E' => Instruction.East,
                'W' => Instruction.West,
                'L' => Instruction.Left,
                'R' => Instruction.Right,
                'F' => Instruction.Forward,
                _ => throw new NotSupportedException()
            };
        }
    }
}
