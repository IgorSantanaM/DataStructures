using DataStructures.Graph;

var graph = new Graph(9, true);
graph.AddEdge(0, 1);
graph.AddEdge(1, 2);
graph.AddEdge(2, 7);
graph.AddEdge(2, 4);
graph.AddEdge(2, 3);
graph.AddEdge(1, 5);
graph.AddEdge(5, 6);
graph.AddEdge(3, 6);
graph.AddEdge(3, 4);
graph.AddEdge(6, 8);
var topologicalSort = graph.TopologicalSort();
Console.WriteLine();

