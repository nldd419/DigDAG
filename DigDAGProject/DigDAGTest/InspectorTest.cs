using Xunit;
using System.Collections.Generic;
using System.Linq;

using DigDAGTest.Models;
using DigDAG;

namespace DigDAGTest
{
    public class InspectorTest
    {
        public class CallOrderTest
        {
            public class TreeTest
            {
                public TreeTest()
                {
                    root = TestNodeFactory.CreateTree();
                }

                private TestNode root;

                [Fact]
                public void CallDepthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    { 
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(3, 2, 0, 1),
                        new TestNodeInfo(7, 3, 0, 3),
                        new TestNodeInfo(8, 3, 1, 3),
                        new TestNodeInfo(4, 2, 1, 1),
                        new TestNodeInfo(9, 3, 0, 4),
                        new TestNodeInfo(10, 3, 1, 4),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(5, 2, 0, 2),
                        new TestNodeInfo(11, 3, 0, 5),
                        new TestNodeInfo(12, 3, 1, 5),
                        new TestNodeInfo(6, 2, 1, 2),
                        new TestNodeInfo(13, 3, 0, 6),
                        new TestNodeInfo(14, 3, 1, 6),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: true);
                }

                [Fact]
                public void CallBreadthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(3, 2, 0, 1),
                        new TestNodeInfo(4, 2, 1, 1),
                        new TestNodeInfo(5, 2, 0, 2),
                        new TestNodeInfo(6, 2, 1, 2),
                        new TestNodeInfo(7, 3, 0, 3),
                        new TestNodeInfo(8, 3, 1, 3),
                        new TestNodeInfo(9, 3, 0, 4),
                        new TestNodeInfo(10, 3, 1, 4),
                        new TestNodeInfo(11, 3, 0, 5),
                        new TestNodeInfo(12, 3, 1, 5),
                        new TestNodeInfo(13, 3, 0, 6),
                        new TestNodeInfo(14, 3, 1, 6),
                    };
                    
                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: false);
                }
            }

            public class LeftDeepTreeTest
            {
                public LeftDeepTreeTest()
                {
                    root = TestNodeFactory.CreateLeftDeepTree();
                }

                private TestNode root;

                [Fact]
                public void CallDepthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(3, 2, 0, 1),
                        new TestNodeInfo(7, 3, 0, 3),
                        new TestNodeInfo(15, 4, 0, 7),
                        new TestNodeInfo(8, 3, 1, 3),
                        new TestNodeInfo(4, 2, 1, 1),
                        new TestNodeInfo(9, 3, 0, 4),
                        new TestNodeInfo(16, 4, 0, 9),
                        new TestNodeInfo(10, 3, 1, 4),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(5, 2, 0, 2),
                        new TestNodeInfo(11, 3, 0, 5),
                        new TestNodeInfo(17, 4, 0, 11),
                        new TestNodeInfo(12, 3, 1, 5),
                        new TestNodeInfo(6, 2, 1, 2),
                        new TestNodeInfo(13, 3, 0, 6),
                        new TestNodeInfo(18, 4, 0, 13),
                        new TestNodeInfo(14, 3, 1, 6),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: true);
                }

                [Fact]
                public void CallBreadthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(3, 2, 0, 1),
                        new TestNodeInfo(4, 2, 1, 1),
                        new TestNodeInfo(5, 2, 0, 2),
                        new TestNodeInfo(6, 2, 1, 2),
                        new TestNodeInfo(7, 3, 0, 3),
                        new TestNodeInfo(8, 3, 1, 3),
                        new TestNodeInfo(9, 3, 0, 4),
                        new TestNodeInfo(10, 3, 1, 4),
                        new TestNodeInfo(11, 3, 0, 5),
                        new TestNodeInfo(12, 3, 1, 5),
                        new TestNodeInfo(13, 3, 0, 6),
                        new TestNodeInfo(14, 3, 1, 6),
                        new TestNodeInfo(15, 4, 0, 7),
                        new TestNodeInfo(16, 4, 0, 9),
                        new TestNodeInfo(17, 4, 0, 11),
                        new TestNodeInfo(18, 4, 0, 13),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: false);
                }
            }

            public class RightDeepTreeTest
            {
                public RightDeepTreeTest()
                {
                    root = TestNodeFactory.CreateRightDeepTree();
                }

                private TestNode root;

                [Fact]
                public void CallDepthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(3, 2, 0, 1),
                        new TestNodeInfo(7, 3, 0, 3),
                        new TestNodeInfo(8, 3, 1, 3),
                        new TestNodeInfo(15, 4, 0, 8),
                        new TestNodeInfo(4, 2, 1, 1),
                        new TestNodeInfo(9, 3, 0, 4),
                        new TestNodeInfo(10, 3, 1, 4),
                        new TestNodeInfo(16, 4, 0, 10),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(5, 2, 0, 2),
                        new TestNodeInfo(11, 3, 0, 5),
                        new TestNodeInfo(12, 3, 1, 5),
                        new TestNodeInfo(17, 4, 0, 12),
                        new TestNodeInfo(6, 2, 1, 2),
                        new TestNodeInfo(13, 3, 0, 6),
                        new TestNodeInfo(14, 3, 1, 6),
                        new TestNodeInfo(18, 4, 0, 14),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: true);
                }

                [Fact]
                public void CallBreadthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(3, 2, 0, 1),
                        new TestNodeInfo(4, 2, 1, 1),
                        new TestNodeInfo(5, 2, 0, 2),
                        new TestNodeInfo(6, 2, 1, 2),
                        new TestNodeInfo(7, 3, 0, 3),
                        new TestNodeInfo(8, 3, 1, 3),
                        new TestNodeInfo(9, 3, 0, 4),
                        new TestNodeInfo(10, 3, 1, 4),
                        new TestNodeInfo(11, 3, 0, 5),
                        new TestNodeInfo(12, 3, 1, 5),
                        new TestNodeInfo(13, 3, 0, 6),
                        new TestNodeInfo(14, 3, 1, 6),
                        new TestNodeInfo(15, 4, 0, 8),
                        new TestNodeInfo(16, 4, 0, 10),
                        new TestNodeInfo(17, 4, 0, 12),
                        new TestNodeInfo(18, 4, 0, 14),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: false);
                }
            }

            public class BothSidesDeepTreeTest
            {
                public BothSidesDeepTreeTest()
                {
                    root = TestNodeFactory.CreateBothSidesDeepTree();
                }

                private TestNode root;

                [Fact]
                public void CallDepthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(3, 2, 0, 1),
                        new TestNodeInfo(7, 3, 0, 3),
                        new TestNodeInfo(15, 4, 0, 7),
                        new TestNodeInfo(21, 5, 0, 15),
                        new TestNodeInfo(25, 6, 0, 21),
                        new TestNodeInfo(8, 3, 1, 3),
                        new TestNodeInfo(16, 4, 0, 8),
                        new TestNodeInfo(22, 5, 0, 16),
                        new TestNodeInfo(4, 2, 1, 1),
                        new TestNodeInfo(9, 3, 0, 4),
                        new TestNodeInfo(17, 4, 0, 9),
                        new TestNodeInfo(10, 3, 1, 4),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(5, 2, 0, 2),
                        new TestNodeInfo(11, 3, 0, 5),
                        new TestNodeInfo(12, 3, 1, 5),
                        new TestNodeInfo(18, 4, 0, 12),
                        new TestNodeInfo(6, 2, 1, 2),
                        new TestNodeInfo(13, 3, 0, 6),
                        new TestNodeInfo(19, 4, 0, 13),
                        new TestNodeInfo(23, 5, 0, 19),
                        new TestNodeInfo(14, 3, 1, 6),
                        new TestNodeInfo(20, 4, 0, 14),
                        new TestNodeInfo(24, 5, 0, 20),
                        new TestNodeInfo(26, 6, 0, 24),
                    };
                    
                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: true);
                }

                [Fact]
                public void CallBreadthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(3, 2, 0, 1),
                        new TestNodeInfo(4, 2, 1, 1),
                        new TestNodeInfo(5, 2, 0, 2),
                        new TestNodeInfo(6, 2, 1, 2),
                        new TestNodeInfo(7, 3, 0, 3),
                        new TestNodeInfo(8, 3, 1, 3),
                        new TestNodeInfo(9, 3, 0, 4),
                        new TestNodeInfo(10, 3, 1, 4),
                        new TestNodeInfo(11, 3, 0, 5),
                        new TestNodeInfo(12, 3, 1, 5),
                        new TestNodeInfo(13, 3, 0, 6),
                        new TestNodeInfo(14, 3, 1, 6),
                        new TestNodeInfo(15, 4, 0, 7),
                        new TestNodeInfo(16, 4, 0, 8),
                        new TestNodeInfo(17, 4, 0, 9),
                        new TestNodeInfo(18, 4, 0, 12),
                        new TestNodeInfo(19, 4, 0, 13),
                        new TestNodeInfo(20, 4, 0, 14),
                        new TestNodeInfo(21, 5, 0, 15),
                        new TestNodeInfo(22, 5, 0, 16),
                        new TestNodeInfo(23, 5, 0, 19),
                        new TestNodeInfo(24, 5, 0, 20),
                        new TestNodeInfo(25, 6, 0, 21),
                        new TestNodeInfo(26, 6, 0, 24),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: false);
                }
            }

            public class CenterDeepTreeTest
            {
                public CenterDeepTreeTest()
                {
                    root = TestNodeFactory.CreateCenterDeepTree();
                }

                private TestNode root;

                [Fact]
                public void CallDepthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(3, 2, 0, 1),
                        new TestNodeInfo(7, 3, 0, 3),
                        new TestNodeInfo(8, 3, 1, 3),
                        new TestNodeInfo(15, 4, 0, 8),
                        new TestNodeInfo(4, 2, 1, 1),
                        new TestNodeInfo(9, 3, 0, 4),
                        new TestNodeInfo(16, 4, 0, 9),
                        new TestNodeInfo(21, 5, 0, 16),
                        new TestNodeInfo(10, 3, 1, 4),
                        new TestNodeInfo(17, 4, 0, 10),
                        new TestNodeInfo(22, 5, 0, 17),
                        new TestNodeInfo(25, 6, 0, 22),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(5, 2, 0, 2),
                        new TestNodeInfo(11, 3, 0, 5),
                        new TestNodeInfo(18, 4, 0, 11),
                        new TestNodeInfo(23, 5, 0, 18),
                        new TestNodeInfo(26, 6, 0, 23),
                        new TestNodeInfo(12, 3, 1, 5),
                        new TestNodeInfo(19, 4, 0, 12),
                        new TestNodeInfo(24, 5, 0, 19),
                        new TestNodeInfo(6, 2, 1, 2),
                        new TestNodeInfo(13, 3, 0, 6),
                        new TestNodeInfo(20, 4, 0, 13),
                        new TestNodeInfo(14, 3, 1, 6),
                    };
                    
                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: true);
                }

                [Fact]
                public void CallBreadthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(3, 2, 0, 1),
                        new TestNodeInfo(4, 2, 1, 1),
                        new TestNodeInfo(5, 2, 0, 2),
                        new TestNodeInfo(6, 2, 1, 2),
                        new TestNodeInfo(7, 3, 0, 3),
                        new TestNodeInfo(8, 3, 1, 3),
                        new TestNodeInfo(9, 3, 0, 4),
                        new TestNodeInfo(10, 3, 1, 4),
                        new TestNodeInfo(11, 3, 0, 5),
                        new TestNodeInfo(12, 3, 1, 5),
                        new TestNodeInfo(13, 3, 0, 6),
                        new TestNodeInfo(14, 3, 1, 6),
                        new TestNodeInfo(15, 4, 0, 8),
                        new TestNodeInfo(16, 4, 0, 9),
                        new TestNodeInfo(17, 4, 0, 10),
                        new TestNodeInfo(18, 4, 0, 11),
                        new TestNodeInfo(19, 4, 0, 12),
                        new TestNodeInfo(20, 4, 0, 13),
                        new TestNodeInfo(21, 5, 0, 16),
                        new TestNodeInfo(22, 5, 0, 17),
                        new TestNodeInfo(23, 5, 0, 18),
                        new TestNodeInfo(24, 5, 0, 19),
                        new TestNodeInfo(25, 6, 0, 22),
                        new TestNodeInfo(26, 6, 0, 23),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: false);
                }
            }

            public class DAGWithSharedChildTest
            {
                public DAGWithSharedChildTest()
                {
                    root = TestNodeFactory.CreateDAGWithSharedChild();
                }

                private TestNode root;

                [Fact]
                public void CallDepthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(3, 2, 0, 1),
                        new TestNodeInfo(7, 3, 0, 3),
                        new TestNodeInfo(15, 4, 0, 7),
                        new TestNodeInfo(21, 5, 0, 15),
                        new TestNodeInfo(23, 5, 1, 15),
                        new TestNodeInfo(8, 3, 1, 3),
                        new TestNodeInfo(16, 4, 0, 8),
                        new TestNodeInfo(23, 5, 0, 16),
                        new TestNodeInfo(22, 5, 1, 16),
                        new TestNodeInfo(4, 2, 1, 1),
                        new TestNodeInfo(9, 3, 0, 4),
                        new TestNodeInfo(17, 4, 0, 9),
                        new TestNodeInfo(23, 5, 0, 17),
                        new TestNodeInfo(10, 3, 1, 4),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(5, 2, 0, 2),
                        new TestNodeInfo(11, 3, 0, 5),
                        new TestNodeInfo(12, 3, 1, 5),
                        new TestNodeInfo(18, 4, 0, 12),
                        new TestNodeInfo(25, 5, 0, 18),
                        new TestNodeInfo(6, 2, 1, 2),
                        new TestNodeInfo(13, 3, 0, 6),
                        new TestNodeInfo(19, 4, 0, 13),
                        new TestNodeInfo(24, 5, 0, 19),
                        new TestNodeInfo(25, 5, 1, 19),
                        new TestNodeInfo(14, 3, 1, 6),
                        new TestNodeInfo(20, 4, 0, 14),
                        new TestNodeInfo(25, 5, 0, 20),
                        new TestNodeInfo(26, 5, 1, 20),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: true);
                }

                [Fact]
                public void CallBreadthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(3, 2, 0, 1),
                        new TestNodeInfo(4, 2, 1, 1),
                        new TestNodeInfo(5, 2, 0, 2),
                        new TestNodeInfo(6, 2, 1, 2),
                        new TestNodeInfo(7, 3, 0, 3),
                        new TestNodeInfo(8, 3, 1, 3),
                        new TestNodeInfo(9, 3, 0, 4),
                        new TestNodeInfo(10, 3, 1, 4),
                        new TestNodeInfo(11, 3, 0, 5),
                        new TestNodeInfo(12, 3, 1, 5),
                        new TestNodeInfo(13, 3, 0, 6),
                        new TestNodeInfo(14, 3, 1, 6),
                        new TestNodeInfo(15, 4, 0, 7),
                        new TestNodeInfo(16, 4, 0, 8),
                        new TestNodeInfo(17, 4, 0, 9),
                        new TestNodeInfo(18, 4, 0, 12),
                        new TestNodeInfo(19, 4, 0, 13),
                        new TestNodeInfo(20, 4, 0, 14),
                        new TestNodeInfo(21, 5, 0, 15),
                        new TestNodeInfo(23, 5, 1, 15),
                        new TestNodeInfo(23, 5, 0, 16),
                        new TestNodeInfo(22, 5, 1, 16),
                        new TestNodeInfo(23, 5, 0, 17),
                        new TestNodeInfo(25, 5, 0, 18),
                        new TestNodeInfo(24, 5, 0, 19),
                        new TestNodeInfo(25, 5, 1, 19),
                        new TestNodeInfo(25, 5, 0, 20),
                        new TestNodeInfo(26, 5, 1, 20),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: false);
                }
            }

            public class DAGWithManyParnetSharingChild
            {
                public DAGWithManyParnetSharingChild()
                {
                    root = TestNodeFactory.CreateDAGWithManyParnetSharingChild();
                }

                private TestNode root;

                [Fact]
                public void CallDepthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(10, 2, 0, 1),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(10, 2, 0, 2),
                        new TestNodeInfo(3, 1, 2, 0),
                        new TestNodeInfo(10, 2, 0, 3),
                        new TestNodeInfo(4, 1, 3, 0),
                        new TestNodeInfo(10, 2, 0, 4),
                        new TestNodeInfo(5, 1, 4, 0),
                        new TestNodeInfo(10, 2, 0, 5),
                        new TestNodeInfo(6, 1, 5, 0),
                        new TestNodeInfo(10, 2, 0, 6),
                        new TestNodeInfo(7, 1, 6, 0),
                        new TestNodeInfo(10, 2, 0, 7),
                        new TestNodeInfo(8, 1, 7, 0),
                        new TestNodeInfo(10, 2, 0, 8),
                        new TestNodeInfo(9, 1, 8, 0),
                        new TestNodeInfo(10, 2, 0, 9),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: true);
                }

                [Fact]
                public void CallBreadthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(3, 1, 2, 0),
                        new TestNodeInfo(4, 1, 3, 0),
                        new TestNodeInfo(5, 1, 4, 0),
                        new TestNodeInfo(6, 1, 5, 0),
                        new TestNodeInfo(7, 1, 6, 0),
                        new TestNodeInfo(8, 1, 7, 0),
                        new TestNodeInfo(9, 1, 8, 0),
                        new TestNodeInfo(10, 2, 0, 1),
                        new TestNodeInfo(10, 2, 0, 2),
                        new TestNodeInfo(10, 2, 0, 3),
                        new TestNodeInfo(10, 2, 0, 4),
                        new TestNodeInfo(10, 2, 0, 5),
                        new TestNodeInfo(10, 2, 0, 6),
                        new TestNodeInfo(10, 2, 0, 7),
                        new TestNodeInfo(10, 2, 0, 8),
                        new TestNodeInfo(10, 2, 0, 9),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: false);
                }
            }

            public class DAGWithDuplicateSharingChildTwiceTest
            {
                public DAGWithDuplicateSharingChildTwiceTest()
                {
                    root = TestNodeFactory.CreateDAGWithDuplicateSharingChildTwice();
                }

                private TestNode root;

                [Fact]
                public void CallDepthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(2, 2, 0, 1),
                        new TestNodeInfo(2, 2, 1, 1),
                        new TestNodeInfo(1, 1, 1, 0),
                        new TestNodeInfo(2, 2, 0, 1),
                        new TestNodeInfo(2, 2, 1, 1),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: true);
                }

                [Fact]
                public void CallBreadthFirstSearchInCorrectOrder()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(1, 1, 1, 0),
                        new TestNodeInfo(2, 2, 0, 1),
                        new TestNodeInfo(2, 2, 1, 1),
                        new TestNodeInfo(2, 2, 0, 1),
                        new TestNodeInfo(2, 2, 1, 1),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root, action, depthFirstSearch: false);
                }
            }
        }

        public class ConditionTest
        {
            public class DAGWithSharedChildTest
            {
                public DAGWithSharedChildTest()
                {
                    root = TestNodeFactory.CreateDAGWithSharedChild();
                }

                private TestNode root;

                [Fact]
                public void CallOnlyOddId()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(1, 1, 0, 0),
                        new TestNodeInfo(3, 2, 0, 1),
                        new TestNodeInfo(7, 3, 0, 3),
                        new TestNodeInfo(15, 4, 0, 7),
                        new TestNodeInfo(21, 5, 0, 15),
                        new TestNodeInfo(23, 5, 1, 15),
                        new TestNodeInfo(23, 5, 0, 16),
                        new TestNodeInfo(9, 3, 0, 4),
                        new TestNodeInfo(17, 4, 0, 9),
                        new TestNodeInfo(23, 5, 0, 17),
                        new TestNodeInfo(5, 2, 0, 2),
                        new TestNodeInfo(11, 3, 0, 5),
                        new TestNodeInfo(25, 5, 0, 18),
                        new TestNodeInfo(13, 3, 0, 6),
                        new TestNodeInfo(19, 4, 0, 13),
                        new TestNodeInfo(25, 5, 1, 19),
                        new TestNodeInfo(25, 5, 0, 20),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectWhere(root, action, (n, d, i, p) =>
                    {
                        TestNode node = (TestNode)n;
                        return node.Id % 2 == 1;
                    },
                    depthFirstSearch: true);
                }

                [Fact]
                public void CallOnlyEvenId()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(8, 3, 1, 3),
                        new TestNodeInfo(16, 4, 0, 8),
                        new TestNodeInfo(22, 5, 1, 16),
                        new TestNodeInfo(4, 2, 1, 1),
                        new TestNodeInfo(10, 3, 1, 4),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(12, 3, 1, 5),
                        new TestNodeInfo(18, 4, 0, 12),
                        new TestNodeInfo(6, 2, 1, 2),
                        new TestNodeInfo(24, 5, 0, 19),
                        new TestNodeInfo(14, 3, 1, 6),
                        new TestNodeInfo(20, 4, 0, 14),
                        new TestNodeInfo(26, 5, 1, 20),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectWhere(root, action, (n, d, i, p) =>
                    {
                        TestNode node = (TestNode)n;
                        return node.Id % 2 == 0;
                    },
                    depthFirstSearch: true);
                }
            }
        }

        public class PruneTest
        {
            public class DAGWithSharedChildTest
            {
                public DAGWithSharedChildTest()
                {
                    root = TestNodeFactory.CreateDAGWithSharedChild();
                }

                private TestNode root;

                [Fact]
                public void PruneUnderId1Subtree()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(0, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(2, 1, 1, 0),
                        new TestNodeInfo(5, 2, 0, 2),
                        new TestNodeInfo(11, 3, 0, 5),
                        new TestNodeInfo(12, 3, 1, 5),
                        new TestNodeInfo(18, 4, 0, 12),
                        new TestNodeInfo(25, 5, 0, 18),
                        new TestNodeInfo(6, 2, 1, 2),
                        new TestNodeInfo(13, 3, 0, 6),
                        new TestNodeInfo(19, 4, 0, 13),
                        new TestNodeInfo(24, 5, 0, 19),
                        new TestNodeInfo(25, 5, 1, 19),
                        new TestNodeInfo(14, 3, 1, 6),
                        new TestNodeInfo(20, 4, 0, 14),
                        new TestNodeInfo(25, 5, 0, 20),
                        new TestNodeInfo(26, 5, 1, 20),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectWhere(root, action, (n, d, i, p) => true,
                        (n, d, i, p) =>
                        {
                            return ((TestNode)n).Id == 1;
                        },
                        depthFirstSearch: true);
                }

                [Fact]
                public void CallOnlyId2Subtree()
                {
                    List<TestNodeInfo> callOrder = new List<TestNodeInfo>
                    {
                        new TestNodeInfo(2, 0, AssertUtils.NO_INDEX, AssertUtils.PARENT_ID_NONE),
                        new TestNodeInfo(5, 1, 0, 2),
                        new TestNodeInfo(11, 2, 0, 5),
                        new TestNodeInfo(12, 2, 1, 5),
                        new TestNodeInfo(18, 3, 0, 12),
                        new TestNodeInfo(25, 4, 0, 18),
                        new TestNodeInfo(6, 1, 1, 2),
                        new TestNodeInfo(13, 2, 0, 6),
                        new TestNodeInfo(19, 3, 0, 13),
                        new TestNodeInfo(24, 4, 0, 19),
                        new TestNodeInfo(25, 4, 1, 19),
                        new TestNodeInfo(14, 2, 1, 6),
                        new TestNodeInfo(20, 3, 0, 14),
                        new TestNodeInfo(25, 4, 0, 20),
                        new TestNodeInfo(26, 4, 1, 20),
                    };

                    DagInspector.InspectAction action = AssertUtils.CreateCallOrderEqualsAction(callOrder);

                    DagInspector.InspectAll(root.Nexts.ElementAt(1), action, depthFirstSearch: true);
                }
            }
        }
    
        public class VerfiyTest
        {
            public class TreeTest
            {
                public TreeTest()
                {
                    root = TestNodeFactory.CreateTree();
                }

                private TestNode root;

                [Fact]
                public void MustBeValid()
                {
                    Assert.True(DagInspector.Verify(root));
                }
            }

            public class DAGWithSharedChildTest
            {
                public DAGWithSharedChildTest()
                {
                    root = TestNodeFactory.CreateDAGWithSharedChild();
                }

                private TestNode root;

                [Fact]
                public void MustBeValid()
                {
                    Assert.True(DagInspector.Verify(root));
                }
            }
            public class DAGWithManyParnetSharingChild
            {
                public DAGWithManyParnetSharingChild()
                {
                    root = TestNodeFactory.CreateDAGWithManyParnetSharingChild();
                }

                private TestNode root;

                [Fact]
                public void MustBeValid()
                {
                    Assert.True(DagInspector.Verify(root));
                }
            }

            public class DAGWithDuplicateSharingChildTwiceTest
            {
                public DAGWithDuplicateSharingChildTwiceTest()
                {
                    root = TestNodeFactory.CreateDAGWithDuplicateSharingChildTwice();
                }

                private TestNode root;

                [Fact]
                public void MustBeValid()
                {
                    Assert.True(DagInspector.Verify(root));
                }
            }

            public class GraphWithFarCycleTest
            {
                public GraphWithFarCycleTest()
                {
                    root = TestNodeFactory.CreateGraphWithFarCycle();
                }

                private TestNode root;

                [Fact]
                public void MustBeInvalid()
                {
                    Assert.False(DagInspector.Verify(root));
                }
            }

            public class GraphWithSelfCycleTest
            {
                public GraphWithSelfCycleTest()
                {
                    root = TestNodeFactory.CreateGraphWithSelfCycle();
                }

                private TestNode root;

                [Fact]
                public void MustBeInvalid()
                {
                    Assert.False(DagInspector.Verify(root));
                }
            }

            public class GraphWithParentAndChildCycleTest
            {
                public GraphWithParentAndChildCycleTest()
                {
                    root = TestNodeFactory.CreateGraphWithParentAndChildCycle();
                }

                private TestNode root;

                [Fact]
                public void MustBeInvalid()
                {
                    Assert.False(DagInspector.Verify(root));
                }
            }
        }
    }
}