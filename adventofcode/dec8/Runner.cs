using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec8
{
    class Runner
    {
        public int RunProgram(IReadOnlyList<(Instruction, int)> program)
        {
            TryRunProgram(program, out var result, out _);
            return result;
        }

        public int RunWithFix(IReadOnlyList<(Instruction, int)> program)
        {
            var completed = TryRunProgram(program, out var result, out var traceList);
            var trace = new Queue<int>(traceList);

            while (trace.Any() && !completed)
            {
                var copy = program.ToArray();
                int toFlip;
                do
                {
                    toFlip = trace.Dequeue();
                } while (copy[toFlip].Item1 == Instruction.ACC);

                var (instruction, value) = copy[toFlip];
                copy[toFlip] = (instruction == Instruction.JMP ? Instruction.NOP : Instruction.JMP, value);
                completed = TryRunProgram(copy, out result, out _);
            }
            
            if(!trace.Any()) throw new Exception("NO ANSWER");

            return result;
        }

        private bool TryRunProgram(IReadOnlyList<(Instruction, int)> program, out int result, out IEnumerable<int> trace)
        {
            var accumulator = 0;
            var programCounter = 0;
            var executedInstructions = new HashSet<int>();
            var traceList = new List<int>();

            while (!executedInstructions.Contains(programCounter) && programCounter < program.Count)
            {
                var (instruction, value) = program[programCounter];
                executedInstructions.Add(programCounter);
                traceList.Add(programCounter);
                switch (instruction)
                {
                    case Instruction.NOP:
                        programCounter++;
                        break;
                    case Instruction.ACC:
                        accumulator += value;
                        programCounter++;
                        break;
                    case Instruction.JMP:
                        programCounter += value;
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }

            result = accumulator;
            trace = traceList;
            
            return programCounter == program.Count;
        }
    }
}
