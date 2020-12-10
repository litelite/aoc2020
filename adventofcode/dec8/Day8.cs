using adventofcode.utils;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace adventofcode.dec8
{
    public class Day8
    {
        private readonly IFileReader _fileReader;
        private readonly Regex _instructionParser = new Regex("([a-z]{3}) ([+-][0-9]+)", RegexOptions.Compiled);

        public Day8(IFileReader fileReader = null)
        {
            _fileReader = fileReader ?? new FileReader();
        }

        public (int, int) GetAnswers()
        {
            var program = ReadProgram();
            var runner = new Runner();
            return (runner.RunProgram(program), runner.RunWithFix(program));
        }

        private (Instruction, int)[] ReadProgram()
        {
            var program = new List<(Instruction, int)>();
            foreach (var line in _fileReader.ReadLineByLine("assets/dec8.txt"))
            {
                var match = _instructionParser.Match(line);
                if(!match.Success) throw new Exception("NO MATCH");
                var instructionText = match.Groups[1].Value;
                var value = int.Parse(match.Groups[2].Value);
                program.Add((ParseInstruction(instructionText), value));
            }

            return program.ToArray();
        }

        private Instruction ParseInstruction(string instructionText)
        {
            return instructionText switch
            {
                "nop" => Instruction.NOP,
                "acc" => Instruction.ACC,
                "jmp" => Instruction.JMP,
                _ => throw new ArgumentException("INVALID INSTRUCTION")
            };
        }
    }
}
