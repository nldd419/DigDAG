// See https://aka.ms/new-console-template for more information

using DigDAG;
using Samples;

DagInspector.InspectAction action = (node, depth, index, parent) =>
{
    Console.WriteLine($"Id:{((Node)node).Id} Depth:{depth} Index:{index} Parent:{(parent != null ? ((Node)parent).Id : "null")}");
};

{
    Console.WriteLine("[Simple Tree]");

    /*
     * [0]
     *  |____________
     *  |            |
     * [1]          [2]
     *  |_____       |_______
     *  |     |      |       |
     * [3]   [4]    [5]     [6]
     */

    Node node0 = new Node(0);
    Node node1 = new Node(1);
    Node node2 = new Node(2);
    Node node3 = new Node(3);
    Node node4 = new Node(4);
    Node node5 = new Node(5);
    Node node6 = new Node(6);

    node0.AddChild(node1);
    node0.AddChild(node2);
    node1.AddChild(node3);
    node1.AddChild(node4);
    node2.AddChild(node5);
    node2.AddChild(node6);

    Console.WriteLine("Depth-First Search:");
    DagInspector.InspectAll(node0, action, depthFirstSearch: true);
    Console.WriteLine("");

    Console.WriteLine("Breadth-First Search:");
    DagInspector.InspectAll(node0, action, depthFirstSearch: false);
    Console.WriteLine("");

    Console.WriteLine("Where Id Is Odd:");
    DagInspector.InspectWhere(node0, action, (n, d, i, p) => ((Node)n).Id % 2 == 1, depthFirstSearch: true);
    Console.WriteLine("");

    Console.WriteLine("Prune Subtree1:");
    DagInspector.InspectWhere(node0, action, (n, d, i, p) => true, (n, d, i, p) => ((Node)n).Id == 1, depthFirstSearch: true);
    Console.WriteLine("");

    bool IsDAG = DagInspector.Verify(node0);
    Console.WriteLine($"Is DAG: {IsDAG}");
    Console.WriteLine("");

    Console.WriteLine("");
}

{
    Console.WriteLine("[Shared Child Graph]");

    /*
     * [0]
     *  |____
     *  |    |
     * [1]  [2]
     *  |__  |_[4]
     *  |  | |
     * [3] |_|_[5]    
     */

    Node node0 = new Node(0);
    Node node1 = new Node(1);
    Node node2 = new Node(2);
    Node node3 = new Node(3);
    Node node4 = new Node(4);
    Node node5 = new Node(5);

    node0.AddChild(node1);
    node0.AddChild(node2);
    node1.AddChild(node3);
    node1.AddChild(node5);
    node2.AddChild(node5);
    node2.AddChild(node4);

    Console.WriteLine("Depth-First Search:");
    DagInspector.InspectAll(node0, action, depthFirstSearch: true);
    Console.WriteLine("");

    Console.WriteLine("Breadth-First Search:");
    DagInspector.InspectAll(node0, action, depthFirstSearch: false);
    Console.WriteLine("");

    Console.WriteLine("Where Id Is Odd:");
    DagInspector.InspectWhere(node0, action, (n, d, i, p) => ((Node)n).Id % 2 == 1, depthFirstSearch: true);
    Console.WriteLine("");

    Console.WriteLine("Prune Subtree1:");
    DagInspector.InspectWhere(node0, action, (n, d, i, p) => true, (n, d, i, p) => ((Node)n).Id == 1, depthFirstSearch: true);
    Console.WriteLine("");

    bool IsDAG = DagInspector.Verify(node0);
    Console.WriteLine($"Is DAG: {IsDAG}");
    Console.WriteLine("");

    Console.WriteLine("");
}

{
    Console.WriteLine("[Cyclic Graph]");

    /*
     * [0]
     *  |
     * [1]<-.
     *  |   |
     * [2]__|  
     */

    Node node0 = new Node(0);
    Node node1 = new Node(1);
    Node node2 = new Node(2);

    node0.AddChild(node1);
    node1.AddChild(node2);
    node2.AddChild(node1);
    
    // Inspecting a cyclic graph causes an infinite loop.

    //Console.WriteLine("Depth-First Search:");
    //DagInspector.InspectAll(node0, action, depthFirstSearch: true);
    //Console.WriteLine("");

    bool IsDAG = DagInspector.Verify(node0);
    Console.WriteLine($"Is DAG: {IsDAG}");
    Console.WriteLine("");

    Console.WriteLine("");
}
