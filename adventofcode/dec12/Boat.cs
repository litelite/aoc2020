using System;
using System.Collections.Generic;

namespace adventofcode.dec12
{
    public class Boat
    {
        public int GetDistanceFromStart(IEnumerable<(Instruction instruction, int amount)> instructions)
        {
            int x = 0;
            int y = 0;
            int vx = 1;
            int vy = 0;

            foreach (var (instruction, amount) in instructions)
            {
                switch (instruction)
                {
                    case Instruction.North:
                        y -= amount;
                        break;
                    case Instruction.South:
                        y += amount;
                        break;
                    case Instruction.East:
                        x += amount;
                        break;
                    case Instruction.West:
                        x -= amount;
                        break;
                    case Instruction.Left:
                        (vx, vy) = DegToVec(VecToDeg(vx, vy) - amount);
                        break;
                    case Instruction.Right:
                        (vx, vy) = DegToVec(VecToDeg(vx, vy) + amount);
                        break;
                    case Instruction.Forward:
                        x += vx * amount;
                        y += vy * amount;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }

        private int VecToDeg(int vx, int vy)
        {
            if (vx == 1) return 0;
            if (vx == -1) return 180;
            if (vy == 1) return 90;
            if (vy == -1) return 270;

            throw new NotSupportedException();
        }

        private (int vx, int vy) DegToVec(int deg)
        {
            return (deg % 360) switch
            {
                0 => (1, 0),
                90 => (0, 1),
                180 => (-1, 0),
                270 => (0, -1),
                -90 => (0, -1),
                -180 => (-1, 0),
                -270 => (0, 1),
                _ => throw new NotSupportedException(),
            };
        }
    }
}
