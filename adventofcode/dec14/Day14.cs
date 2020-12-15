using adventofcode.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode.dec14
{
    public class Day14
    {
        private readonly IFileReader _fileReader;
        private readonly Regex _maskParser = new("^mask = ([X01]{36})$", RegexOptions.Compiled);
        private readonly Regex _instructionParser = new(@"^mem\[([0-9]+)\] = ([0-9]+)$", RegexOptions.Compiled);
        
        public Day14(IFileReader fileReader = null)
        {
            _fileReader = fileReader ?? new FileReader();
        }

        public (long, Lazy<long>) GetAnswers()
        {
            var program = ParseProgram().ToArray();
            var executor = new Executor();
            
            return (executor.GetSumOfProgramMemory(program), new Lazy<long>(() => executor.GetSumOfProgramMemoryV2(program)) );
        }

        private IEnumerable<IInstruction> ParseProgram()
        {
            return _fileReader.ReadLineByLine("assets/dec14.txt").Select((line) =>
            {
                Match match = _instructionParser.Match(line);
                if (match.Success)
                {
                    var address = int.Parse(match.Groups[1].Value);
                    var value = long.Parse(match.Groups[2].Value);
                    return new ApplyValueInstruction(address, value) as IInstruction;
                }

                match = _maskParser.Match(line);
                if (match.Success)
                {
                    return new ChangeMaskInstruction(new Mask(match.Groups[1].Value)) as IInstruction;
                }

                throw new Exception("INVALID PROGRAM");
            });
        }
    }
}
