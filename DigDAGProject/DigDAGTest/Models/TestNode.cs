using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DigDAG;

namespace DigDAGTest.Models
{
    internal class TestNode : IDagNode
    {
        public TestNode(uint id)
        {
            Id = id;
        }

        public uint Id { get; private set; }

        private List<TestNode> nextNodes = new List<TestNode>(); 

        public IEnumerable<IDagNode> Nexts => nextNodes;

        public void AddChild(TestNode node)
        {
            nextNodes.Add(node);
        }
    }
}
