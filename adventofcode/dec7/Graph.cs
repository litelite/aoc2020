using System.Collections.Generic;
using System.Linq;

namespace adventofcode.dec7
{
    public class Graph
    {
        private readonly List<Node> _nodes = new List<Node>();

        public void Insert(string nodeName, IEnumerable<(string, int)> childs)
        {
            var node =  _nodes.FirstOrDefault(x => x.Name == nodeName);
            if (node == null)
            {
                node = new Node(nodeName);
                _nodes.Add(node);
            }

            foreach (var (childName, count) in childs)
            {
                var child = _nodes.FirstOrDefault(x => x.Name == childName);
                if (child == null)
                {
                    child = new Node(childName);
                    _nodes.Add(child);
                }
                node.AddChild(child, count);
            }
        }

        public int GetNumberOfBagThatCanContain(string name) => _nodes.Count(x => x.CanHold(name));

        public int GetCapacityOf(string name) => _nodes.First(x => x.Name == name).Capacity();
    }
}
