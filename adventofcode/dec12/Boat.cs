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

        public int MoveByWaypoint(IEnumerable<(Instruction instruction, int amount)> instructions)
        {
            int x = 0;
            int y = 0;
            int wx = 10;
            int wy = -1;

            foreach (var (instruction, amount) in instructions)
            {
                switch (instruction)
                {
                    case Instruction.North:
                        wy -= amount;
                        break;
                    case Instruction.South:
                        wy += amount;
                        break;
                    case Instruction.East:
                        wx += amount;
                        break;
                    case Instruction.West:
                        wx -= amount;
                        break;
                    case Instruction.Left:
                        (wx, wy) = Rotate(wx, wy, 0, 0, 360 - amount);
                        break;
                    case Instruction.Right:
                        (wx, wy) = Rotate(wx, wy, 0, 0, amount);
                        break;
                    case Instruction.Forward:
                        var (vx, vy) = VectorTo(x, y, wx, wy);
                        vx *= amount;
                        vy *= amount;
                        x -= vx;
                        y -= vy;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }

        private (int x, int y) Rotate(int x, int y, int cx, int cy, int angle)
        {
            var s = Math.Sin(DegToRad(angle));
            var c = Math.Cos(DegToRad(angle));

            // translate point back to origin:
            x -= cx;
            y -= cy;

            // rotate point
            var xNew = x * c - y * s;
            var yNew = x * s + y * c;

            // translate point back:
            return ((int)Math.Round(xNew + cx), (int)Math.Round(yNew + cy));
        }

        private double DegToRad(int deg) => (Math.PI / 180) * deg;

        private (int x, int y) VectorTo(int x, int y, int wx, int wy) => ((x - wx) - x, (y - wy) - y);

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
