using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec14
{
    class Executor
    {
        public long GetSumOfProgramMemory(IEnumerable<IInstruction> program)
        {
            var mask = new Mask("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            var memory = new Dictionary<long, long>();

            foreach (var instruction in program)
            {
                switch (instruction)
                {
                    case ApplyValueInstruction apply:
                        memory[apply.Address] = mask.Apply(apply.Value);
                        break;
                    case ChangeMaskInstruction changeMask:
                        mask = changeMask.Mask;
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }

            return memory.Values.Sum(x => x);
        }

        public long GetSumOfProgramMemoryV2(IEnumerable<IInstruction> program)
        {
            var mask = new Mask("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            var memory = new Dictionary<long, long>();

            foreach (var instruction in program)
            {
                switch (instruction)
                {
                    case ApplyValueInstruction apply:
                        foreach (var possibleAddress in mask.GetPossibleAddresses(apply.Address))
                        {
                            memory[possibleAddress] = apply.Value;
                        }
                        break;
                    case ChangeMaskInstruction changeMask:
                        mask = changeMask.Mask;
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }

            return memory.Values.Sum(x => x);
        }
    }
}
