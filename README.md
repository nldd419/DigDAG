# DigDAG
C# library for Directed acyclic graph (DAG)  

![Build and Test Status](https://github.com/nldd419/DigDAG/actions/workflows/dotnet.yml/badge.svg)

## Usage
First, you have to implement `IDagNode` which represents a node of a graph.
```
internal class Node : IDagNode
{
    // Only the requirement of the interface is 'Nexts' property.
    public IEnumerable<IDagNode> Nexts => nextNodes;

    // Your implementation of a node.
    public Node(uint id)
    {
        Id = id;
    }

    public uint Id { get; private set; }

    private readonly List<Node> nextNodes = new List<Node>();

    public void AddChild(Node node)
    {
        nextNodes.Add(node);
    }
}
```
Then, you creates a graph and inspect it.
```
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

// [Simple Tree]
// Depth-First Search:
// Id:0 Depth:0 Index:-1 Parent:null
// Id:1 Depth:1 Index:0 Parent:0
// Id:3 Depth:2 Index:0 Parent:1
// Id:4 Depth:2 Index:1 Parent:1
// Id:2 Depth:1 Index:1 Parent:0
// Id:5 Depth:2 Index:0 Parent:2
// Id:6 Depth:2 Index:1 Parent:2
// 
// Breadth-First Search:
// Id:0 Depth:0 Index:-1 Parent:null
// Id:1 Depth:1 Index:0 Parent:0
// Id:2 Depth:1 Index:1 Parent:0
// Id:3 Depth:2 Index:0 Parent:1
// Id:4 Depth:2 Index:1 Parent:1
// Id:5 Depth:2 Index:0 Parent:2
// Id:6 Depth:2 Index:1 Parent:2
// 
// Where Id Is Odd:
// Id:1 Depth:1 Index:0 Parent:0
// Id:3 Depth:2 Index:0 Parent:1
// Id:5 Depth:2 Index:0 Parent:2
// 
// Prune Subtree1:
// Id:0 Depth:0 Index:-1 Parent:null
// Id:2 Depth:1 Index:1 Parent:0
// Id:5 Depth:2 Index:0 Parent:2
// Id:6 Depth:2 Index:1 Parent:2
// 
// Is DAG: True
```

You can see more samples by running the sample project.

### Notice
1. This libary can handle only Directed asyclic graph (DAG).  
   Inspecting a cyclic graph causes an infinite loop, so you should verify that it's DAG by checking the return value of `Verify` method.
2. A node which is shared by multiple parents called multiple times.  
   For example, consider a graph like this.
   ```
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
   ```
   
   The `node5` is shared by the `node1` and the `node2`. Thus, `InspectXXX` methods treat both the `node1` and `node2` as if they have two children for each. As a result, you get following output by the code below.
   
   ```
   Console.WriteLine("Depth-First Search:");
   DagInspector.InspectAll(node0, action, depthFirstSearch: true);
   Console.WriteLine("");
   
   Console.WriteLine("Breadth-First Search:");
   DagInspector.InspectAll(node0, action, depthFirstSearch: false);
   Console.WriteLine("");

   // Depth-First Search:
   // Id:0 Depth:0 Index:-1 Parent:null
   // Id:1 Depth:1 Index:0 Parent:0
   // Id:3 Depth:2 Index:0 Parent:1
   // Id:5 Depth:2 Index:1 Parent:1
   // Id:2 Depth:1 Index:1 Parent:0
   // Id:5 Depth:2 Index:0 Parent:2
   // Id:4 Depth:2 Index:1 Parent:2
   // 
   // Breadth-First Search:
   // Id:0 Depth:0 Index:-1 Parent:null
   // Id:1 Depth:1 Index:0 Parent:0
   // Id:2 Depth:1 Index:1 Parent:0
   // Id:3 Depth:2 Index:0 Parent:1
   // Id:5 Depth:2 Index:1 Parent:1
   // Id:5 Depth:2 Index:0 Parent:2
   // Id:4 Depth:2 Index:1 Parent:2
   ```

## Contributions

### Git settings
I prefer the settings below.
- core.autocrlf=true
- core.safecrlf=true

### Rquirements
- .NET 6 (Visual Studio 2022)

### Naming Conventions
- Class => PascalCase
- Public fields or methods => PascalCase
- Private fields or parameters => camelCase  
  If the name of parameter conflicts with the one of private field, you can use 'this.xxx' to avoid the error.
- Constants => CONSTANT_CASE

I'm new to GitHub, so I may take some time to merge your Pull request.

## TODO
- Add automatic ascii tree creation.

## Others
Since currently the library version is 0.0.1, there is no built binary and you have to compile it by yourself.

Correcting my broken or unnatural english is all welcome.