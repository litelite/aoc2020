using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec7
{
    public class Node
    {

        private readonly List<(Node, int)> _childs = new List<(Node, int)>();

        public Node(string nodeName)
        {
            Name = nodeName;
        }

        public string Name { get; }

        public void AddChild(Node child, int count) => _childs.Add((child, count));

        public bool CanHold(string nodeName)
        {
            if (Name == nodeName) return false;

            return _childs.Any(child => child.Item1.CanHoldInternal(nodeName));
        }

        private bool CanHoldInternal(string nodeName)
        {
            return Name == nodeName || _childs.Any(child => child.Item1.CanHoldInternal(nodeName));
        }

        public int Capacity()
        {
            return _childs.Sum(x => x.Item2 + (x.Item2 * x.Item1.Capacity()));
        }
    }
}
