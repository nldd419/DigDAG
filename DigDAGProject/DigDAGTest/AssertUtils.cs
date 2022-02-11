using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using DigDAGTest.Models;
using DigDAG;

namespace DigDAGTest
{
    internal static class AssertUtils
    {
        public const uint PARENT_ID_NONE = uint.MaxValue;
        public const int NO_INDEX = -1;

        public static DagInspector.InspectAction CreateCallOrderEqualsAction(List<TestNodeInfo> orderdInfoList)
        {
            Queue<TestNodeInfo> queue = new Queue<TestNodeInfo>(orderdInfoList);

            DagInspector.InspectAction action = (node, depth, index, parent) =>
            {
                TestNodeInfo correctInfo = queue.Dequeue();

                uint parentId = PARENT_ID_NONE;
                if (parent != null) parentId = ((TestNode)parent).Id;

                TestNode n = (TestNode)node;
                TestNodeInfo nodeInfo = new TestNodeInfo(n.Id, depth, index, parentId);

                Assert.Equal(correctInfo, nodeInfo);
            };

            return action;
        }
    }
}
