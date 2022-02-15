using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigDAG
{
    public static class DagInspector
    {
        /// <summary>
        /// Condition for filtering nodes to inspect.
        /// </summary>
        /// <param name="node">A node to inspect.</param>
        /// <param name="depth">A depth from the start node in the tree.</param>
        /// <param name="index">An index in the parent list. If the node has no parent, this returns -1.</param>
        /// <param name="parent">A parent of the node currently inspecting.</param>
        /// <returns>Return true if you want to inspect the node.</returns>
        public delegate bool ConditionFunc(IDagNode node, ulong depth, int index, IDagNode? parent);
        /// <summary>
        /// <para>
        /// Condition for pruning a subtree.<br/>
        /// The inspector won't inspect under the pruned subtree.<br/>
        /// </para>
        /// </summary>
        /// <param name="node">A node to inspect.</param>
        /// <param name="depth">A depth from the start node in the tree.</param>
        /// <param name="index">An index in the parent list. If the node has no parent, this returns -1.</param>
        /// <param name="parent">A parent of the node currently inspecting.</param>
        /// <returns>Return true if you want to prune the subtree.</returns>
        public delegate bool PruneConditionFunc(IDagNode node, ulong depth, int index, IDagNode? parent);
        /// <summary>
        /// A user-defined action of an inspection.
        /// </summary>
        /// <param name="node">A node to inspect.</param>
        /// <param name="depth">A depth from the start node in the tree.</param>
        /// <param name="index">An index in the parent list. If the node has no parent, this returns -1.</param>
        /// <param name="parent">A parent of the node currently inspecting.</param>
        public delegate void InspectAction(IDagNode node, ulong depth, int index, IDagNode? parent);

        /// <summary>
        /// Traverse all the nodes in the tree.
        /// </summary>
        /// <param name="firstNode">A start point you want to look into.</param>
        /// <param name="inspector">An action applys to a node.</param>
        /// <param name="depthFirstSearch">True if you use a depth-first search method for tree traversing, otherwise a breadth-first search method is used.</param>
        public static void InspectAll(IDagNode firstNode, InspectAction inspector, bool depthFirstSearch = true)
        {
            InspectWhere(firstNode, inspector, (n, d, i, p) => true, (n, d, i, p) => false, depthFirstSearch);
        }

        /// <summary>
        /// Traverse nodes which meets a condition in the tree.
        /// </summary>
        /// <param name="firstNode">A start point you want to look into.</param>
        /// <param name="inspector">An action applys to a node.</param>
        /// <param name="condition">A condition of a node you want to look into.</param>
        /// <param name="pruneCondition">A pruning condition of the top node of a subtree.</param>
        /// <param name="depthFirstSearch">True if you use a depth-first search method for tree traversing, otherwise a breadth-first search method is used.</param>
        public static void InspectWhere(IDagNode firstNode, InspectAction inspector, ConditionFunc condition, PruneConditionFunc pruneCondition, bool depthFirstSearch = true)
        {
            Inspect(firstNode, inspector, condition, pruneCondition, depthFirstSearch);
        }

        /// <summary>
        /// Traverse nodes which meets a condition in the tree.
        /// </summary>
        /// <param name="firstNode">A start point you want to look into.</param>
        /// <param name="inspector">An action applys to a node.</param>
        /// <param name="condition">A condition of a node you want to look into.</param>
        /// <param name="depthFirstSearch">True if you use a depth-first search method for tree traversing, otherwise a breadth-first search method is used.</param>
        public static void InspectWhere(IDagNode firstNode, InspectAction inspector, ConditionFunc condition, bool depthFirstSearch = true)
        {
            Inspect(firstNode, inspector, condition, (n, d, i, p) => false, depthFirstSearch);
        }

        /// <summary>
        /// The actual implementation of inspecting a DAG tree.
        /// </summary>
        /// <param name="firstNode">A start point you want to look into.</param>
        /// <param name="inspector">An action applys to a node.</param>
        /// <param name="condition">A condition of a node you want to look into.</param>
        /// <param name="pruneCondition">A pruning condition of a subtree.</param>
        /// <param name="depthFirstSearch">True if you use a depth-first search method for tree traversing, otherwise a breadth-first search method is used.</param>
        private static void Inspect(IDagNode firstNode, InspectAction inspector, ConditionFunc condition, PruneConditionFunc pruneCondition, bool depthFirstSearch)
        {
            InspectionParams iParams = new InspectionParams(firstNode);

            if (pruneCondition(iParams.Current.Node, iParams.Depth, iParams.Current.IndexAsChild, iParams.Current.Parent)) return;

            //For breadth-first search
            HashSet<IDagNode> prunedNodes = new HashSet<IDagNode>();
            ulong currentDepth = iParams.Depth + 1;
            ulong prevMaxDepth = iParams.Depth.Max;

            bool finish = false;

            do
            {
                // Inspect it.
                if (condition(iParams.Current.Node, iParams.Depth, iParams.Current.IndexAsChild, iParams.Current.Parent)) inspector(iParams.Current.Node, iParams.Depth, iParams.Current.IndexAsChild, iParams.Current.Parent);

                if (depthFirstSearch)
                {
                    // Depth-first search.

                    // If the node has a first child, go inspect it unless it's not a pruning target.
                    bool goFindSibling = true;
                    if (iParams.Current.Node.Nexts.Any())
                    {
                        iParams.Push(new NodeInfo(iParams.Current.Node.Nexts.First(), iParams.Current.Node, 0));
                        goFindSibling = false;
                    }

                    // Deciding whether to prune a subtree or not. 
                    if (!goFindSibling && pruneCondition(iParams.Current.Node, iParams.Depth, iParams.Current.IndexAsChild, iParams.Current.Parent))
                    {
                        goFindSibling = true;
                        prunedNodes.Add(iParams.Current.Node);
                    }

                    if (goFindSibling)
                    {
                        // Try to find the nearest sibling.
                        bool found = TryToFindNearestSibling(iParams, pruneCondition, prunedNodes);
                        if (!found) finish = true;
                    }
                }
                else
                {
                    // Breadth-first search.

                    // Loop until a next node is found or there is no more deep node.
                    while (true)
                    {
                        bool goFindSibling = true;
                        if (iParams.Current.Parent == null)
                        {
                            // For the root node.
                            if (TryToGoInDeep(iParams, currentDepth, prunedNodes))
                            {
                                goFindSibling = false;
                            }
                        }

                        // Deciding whether to prune a subtree or not. 
                        if (!goFindSibling && pruneCondition(iParams.Current.Node, iParams.Depth, iParams.Current.IndexAsChild, iParams.Current.Parent))
                        {
                            goFindSibling = true;
                            prunedNodes.Add(iParams.Current.Node);
                        }

                        if (goFindSibling)
                        {
                            bool found;
                            // Loop until a next node is found or it reaches the last node.
                            while (true)
                            {
                                // Try to find the nearest sibling.
                                found = TryToFindNearestSibling(iParams, pruneCondition, prunedNodes);

                                if (found)
                                {
                                    // Go in deep until the current depth.
                                    while (iParams.Depth < currentDepth)
                                    {
                                        if (iParams.Current.Node.Nexts.Any())
                                        {
                                            iParams.Push(new NodeInfo(iParams.Current.Node.Nexts.First(), iParams.Current.Node, 0));

                                            if (prunedNodes.Contains(iParams.Current.Node))
                                            {
                                                found = false;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            found = false;
                                            break;
                                        }
                                    }

                                    if (found) break;
                                }
                                else { break; }
                            }

                            if (found) break;

                            // If the next node hasn't been found, check if the max depth has changed from the previous state.
                            if (iParams.Depth.Max == prevMaxDepth)
                            {
                                finish = true;
                                break;
                            }
                            else
                            {
                                prevMaxDepth = iParams.Depth.Max;
                                // Search +1 depth next time.
                                currentDepth++;
                                //Reset the current node to the root node.
                                iParams.ResetStuck(firstNode);
                            }
                        }
                        else
                        {
                            // A node has been found, and we were not going to search siblings.
                            break;
                        }
                    }
                }

            }while (!finish);
        }

        /// <summary>
        /// <para>
        /// Try to find the nearest sibling.<br/>
        /// Note that the properties in the first parameter (iParams) and the third one (prunedNodes) would be modified.<br/>
        /// </para>
        /// </summary>
        /// <returns>True if it found the nearest sibling.</returns>
        private static bool TryToFindNearestSibling(InspectionParams iParams, PruneConditionFunc pruneCondition, HashSet<IDagNode> prunedNodes)
        {
            /*
             * This method tries to find the nearest sibling.
             * The nearest sibling in this context means that finding a node in the order below.
             * 1. A next index in the list which the parent has.
             * 2. If you couldn't find it, move up to the parent and try 1. again. 
             * 
             * If a start position is at [0], then the order is shown in the figure below. 
             * 
             *           [x]
             *         ___|___
             *        |       |
             *      [x]      [3]
             *      _|_      _|_
             *     |   |    |   |
             *    [x] [2]  [x] [x]
             *    _|_
             *   |   |
             *  [0] [1]
             * 
             */

            // Try to find the nearest sibling.
            bool found = false;
            while (true)
            {
                while (true)
                {
                    if (iParams.Current.Parent == null) break;

                    int nextIndex = iParams.Current.IndexAsChild + 1;
                    if (nextIndex < iParams.Current.Parent.Nexts.Count())
                    {
                        // The nearest sibling is found.
                        found = true;
                        IDagNode nextNode = iParams.Current.Parent.Nexts.ElementAt(nextIndex);
                        IDagNode parent = iParams.Current.Parent;
                        iParams.Pop();
                        iParams.Push(new NodeInfo(nextNode, parent, nextIndex));
                        break;
                    }
                    else
                    {
                        // Move one level to the upper node.
                        iParams.Pop();
                    }
                }

                if (!found)
                {
                    break;
                }
                else
                {
                    if (pruneCondition(iParams.Current.Node, iParams.Depth, iParams.Current.IndexAsChild, iParams.Current.Parent))
                    {
                        // If the node is a pruning target, try again.
                        prunedNodes.Add(iParams.Current.Node);
                        found = false;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return found;
        }

        /// <summary>
        /// <para>
        /// Try to go in deep until specified depth.<br/>
        /// Note that the properties in the first parameter (iParams) would be modified.<br/>
        /// </para>
        /// </summary>
        /// <returns>True if it has succeeded to go in deep.</returns>
        private static bool TryToGoInDeep(InspectionParams iParams, ulong currentDepth, HashSet<IDagNode> prunedNodes)
        {
            bool found = true;

            // Go in deep until the current depth.
            while (iParams.Depth < currentDepth)
            {
                if (iParams.Current.Node.Nexts.Any())
                {
                    iParams.Push(new NodeInfo(iParams.Current.Node.Nexts.First(), iParams.Current.Node, 0));

                    if (prunedNodes.Contains(iParams.Current.Node))
                    {
                        found = false;
                        break;
                    }
                }
                else
                {
                    found = false;
                    break;
                }
            }

            return found;
        }

        /// <summary>
        /// A class holding parameters used by inspection logics. (e.g. depth, state, etc.)
        /// </summary>
        private class InspectionParams
        {
            public InspectionParams(IDagNode startNode)
            {
                this.nodeStack.Push(new NodeInfo(startNode));
                this.Depth = new DepthStruct(0);
            }

            public NodeInfo Current { get => nodeStack.Peek(); }
            private Stack<NodeInfo> nodeStack = new Stack<NodeInfo>();

            public DepthStruct Depth;

            /// <summary>
            /// Push a node info which is the next inspecting target to the stack.
            /// </summary>
            public void Push(NodeInfo nodeInfo)
            {
                Depth++;
                nodeStack.Push(nodeInfo);
            }

            /// <summary>
            /// Pop a previous node info.
            /// </summary>
            public NodeInfo Pop()
            {
                Depth--;
                return nodeStack.Pop();
            }

            /// <summary>
            /// Reset a stuck with a new node. This method doesn't affect a <see cref="DepthStruct.Max"/>.
            /// </summary>
            /// <param name="startNodeInfo"></param>
            public void ResetStuck(IDagNode startNode)
            {
                nodeStack.Clear();
                nodeStack.Push(new NodeInfo(startNode));
                Depth.ResetToZero();
            }

            /// <summary>
            /// Depth structure handling special operations.
            /// </summary>
            internal struct DepthStruct
            {
                public DepthStruct(ulong depth)
                {
                    this.depth = depth;
                    this.Max = depth;
                }

                private DepthStruct(ulong depth, ulong maxDepth)
                {
                    this.depth = depth;
                    this.Max = maxDepth;
                }

                public ulong Value
                {
                    get { return depth; }
                }
                private ulong depth;
                public ulong Max { get; private set; }

                public static DepthStruct operator ++(DepthStruct me)
                {
                    if (me.depth == ulong.MaxValue) throw new OverflowException(Constants.EXCEPTION_OVERFLOW);

                    ulong newDepth = me.depth + 1;
                    ulong newMax = me.Max > newDepth ? me.Max : newDepth;

                    return new DepthStruct(newDepth, newMax);
                }

                public static DepthStruct operator --(DepthStruct me)
                {
                    if (me.depth == 0) throw new OverflowException(Constants.EXCEPTION_OVERFLOW);

                    ulong newDepth = me.depth - 1;
                    ulong newMax = me.Max;

                    return new DepthStruct(newDepth, newMax);
                }

                public static implicit operator ulong(DepthStruct me)
                {
                    return me.depth;
                }

                /// <summary>
                /// This method doesn't affect the <see cref="Max"/>.
                /// </summary>
                public void ResetToZero()
                {
                    depth = 0;
                }
            }
        }

        /// <summary>
        /// Infomation about a node which is being inspected.
        /// </summary>
        internal sealed class NodeInfo : IEquatable<NodeInfo>
        {
            public NodeInfo(IDagNode node)
            {
                this.Node = node;
                this.Parent = null;
            }

            public NodeInfo(IDagNode node, IDagNode parent, int indexAsChild)
            {
                this.Node = node;
                this.Parent = parent;
                // The index can't be automatically determined, because the parent possibly has multiple edges direct to a same child and the index depends on the context.
                this.indexAsChild = indexAsChild;
            }

            public IDagNode Node;
            public IDagNode? Parent { get; set; }
            public int IndexAsChild
            {
                get
                {
                    if (Parent == null) return -1;
                    return indexAsChild;
                }
                set
                {
                    indexAsChild = value;
                }
            }
            private int indexAsChild = -1;

            public bool Equals(NodeInfo? other)
            {
                if (other == null) return false;

                return other.Node == this.Node && other.Parent == this.Parent && other.IndexAsChild == this.IndexAsChild;
            }

            public override bool Equals(object? obj)
            {
                if (!(obj is NodeInfo other)) return false;

                return this.Equals(other);
            }

            public override int GetHashCode()
            {
                if(this.Parent != null)
                {
                    return this.Node.GetHashCode() ^ this.IndexAsChild.GetHashCode() ^ this.Parent.GetHashCode();
                }
                else
                {
                    return this.Node.GetHashCode() ^ this.IndexAsChild.GetHashCode();
                }
            }
        }
    
        /// <summary>
        /// Verify a tree is valid that indicates it has no cycles.
        /// </summary>
        /// <returns>True if it has no cycles.</returns>
        public static bool Verify(IDagNode firstNode)
        {
            HashSet<NodeInfo> checkedNodes = new HashSet<NodeInfo>();
            Stack<DepthStackInfo> depthStack = new Stack<DepthStackInfo>();
            
            bool prune = false;
            PruneConditionFunc pruneCondition = (node, depth, index, parent) =>
            {
                // Return true if it has already found any cycles.
                if (prune) return true;

                // Remove the nodes which is in depth more than the current node.
                // This works only if we inspect the tree by depth-first search.
                while (depthStack.Count > 0 && depthStack.Peek().Depth >= depth)
                {
                    DepthStackInfo depthStackInfo = depthStack.Pop();
                    checkedNodes.Remove(depthStackInfo.NodeInfo);
                }

                NodeInfo nodeInfo;
                if(parent != null)
                {
                    nodeInfo = new NodeInfo(node, parent, index);
                }
                else
                {
                    nodeInfo = new NodeInfo(node);
                }

                // Prune subsequent nodes if this node has already been checked.
                // That means the tree has cycles.
                if (checkedNodes.Contains(nodeInfo))
                {
                    prune = true;
                    checkedNodes.Clear();
                    depthStack.Clear();
                }
                else
                {
                    checkedNodes.Add(nodeInfo);
                    depthStack.Push(new DepthStackInfo(depth, nodeInfo));
                }

                return prune;
            };

            InspectWhere(firstNode, (n, d, i, p) => { }, (n, d, i, p) => true, pruneCondition, depthFirstSearch: true);

            return !prune;
        }

        /// <summary>
        /// A node information at a specific depth at the moment.
        /// </summary>
        private record DepthStackInfo(ulong Depth, NodeInfo NodeInfo);
    }
}
