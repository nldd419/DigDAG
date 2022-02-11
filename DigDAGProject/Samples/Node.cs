using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DigDAG;

namespace Samples
{
    internal class Node : IDagNode
    {
        public Node(uint id)
        {
            Id = id;
        }

        public uint Id { get; private set; }

        private readonly List<Node> nextNodes = new List<Node>();

        public IEnumerable<IDagNode> Nexts => nextNodes;

        public void AddChild(Node node)
        {
            nextNodes.Add(node);
        }
    }
}
