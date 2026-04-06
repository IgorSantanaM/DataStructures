namespace DataStructures.Graph
{
    public class Graph
    {
        public int NumVertices { get; private set; }
        public bool Directed { get; private set; }
        public List<Node> VertexList { get; private set; }

        public Graph(int numVertices, bool directed = false)
        {
            NumVertices = numVertices;
            Directed = directed;
            VertexList = new List<Node>();

            for (int i = 0; i < NumVertices; i++)
                VertexList.Add(new Node(i));
        }

        public void AddEdge(int verticeA, int verticeB, int? weight = 1)
        {
            if (verticeA >= NumVertices || verticeB >= NumVertices || verticeA < 0 || verticeB < 0)
                return;

            if (weight != 1)
            {
                Console.WriteLine("Adjacency set cannot represent weighted graphs");
                return;
            }

            VertexList[verticeA].AddEdge(verticeB);

            if (!Directed)
                VertexList[verticeB].AddEdge(verticeA);
        }

        public List<int> GetAdjacentVertices(int vertice)
        {
            if (vertice < 0 || vertice > NumVertices)
                throw new ArgumentOutOfRangeException();

            return VertexList[vertice].GetAdjacentVertices();
        }

        public int GetIndegree(int vertice)
        {
            if (vertice < 0 || vertice > NumVertices)
                throw new ArgumentOutOfRangeException();

            int indegree = 0;
            for (int i = 0; i < NumVertices; i++)
                if (GetAdjacentVertices(i).Contains(vertice))
                    indegree++;

            return indegree;
        }

        public int GetEdgeWeight(int vertice)
            => 1;

        public void Display()
        {
            for (int i = 0; i < NumVertices; i++)
            {
                for (int v = 0; v < GetAdjacentVertices(i).Count; v++)
                    Console.WriteLine($"{i} --> {v}");
            }
        }

        public List<int> TopologicalSort()
        {
            var queue = new Queue<int>();
            var indegreeMap = new Dictionary<int, int>();

            for (int i = 0; i < NumVertices; i++)
            {
                indegreeMap[i] = GetIndegree(i);
                if (indegreeMap[i] == 0)
                    queue.Enqueue(i);
            }

            var resultList = new List<int>();

            while (queue.Any())
            {
                var vertex = queue.Dequeue();

                resultList.Add(vertex);

                foreach (var vertice in GetAdjacentVertices(vertex))
                {
                    indegreeMap[vertice]--;
                    if (indegreeMap[vertice] == 0)
                        queue.Enqueue(vertice);
                }
            }
            if (resultList.Count != NumVertices)
                throw new Exception("This graph has a cycle and cannot have a topological sort");

            return resultList;
        }

        public Stack<int> ShortestPath(int source, int destination)
        {
            //var distanceTableUndirectedGraph = BuildDistaceTableUndirectedGraph(source);
            var distanceTable = BuildDistanceTableDijikstra(source);

            if (!distanceTable.ContainsKey(destination))
                throw new InvalidOperationException();

            var path = new Stack<int>();

            int currentVertex = destination;
            while (currentVertex != source)
            {
                path.Push(currentVertex);

                currentVertex = distanceTable[currentVertex].previousVertex;
            }

            path.Push(source);

            return path;
        }

        private Dictionary<int, (int distance, int previousVertex)> BuildDistanceTableDijikstra(int source)
        {
            var distanceTable = new Dictionary<int, (int distance, int previousVertex)>();

            distanceTable[source] = (0, source);

            var minHeap = new GraphPriorityQueue();

            minHeap.Insert(source, 0);

            while (minHeap.Size > 0)
            {
                var current = minHeap.Remove();

                var currentVertex = current.Vertex;
                var currentDistance = current.Distance;

                if (currentDistance > distanceTable[currentVertex].distance)
                    continue;

                foreach (var vertice in GetAdjacentVertices(currentVertex))
                {
                    int distance = currentDistance + GetEdgeWeight(currentVertex); 

                    if (!distanceTable.ContainsKey(vertice) || distanceTable[vertice].distance > distance)
                    {
                        distanceTable[vertice] = (distance, currentVertex);
                        minHeap.Insert(vertice, distance);
                    }
                }
            }
            return distanceTable;
        }

        [Obsolete]

        private Dictionary<int, (int distance, int previousVertex)> BuildDistaceTableUndirectedGraph(int source)
        {
            var distanceTable = new Dictionary<int, (int distance, int previousVertex)>();

            distanceTable[source] = (0, source);

            var queue = new Queue<int>();
            queue.Enqueue(source);

            while (queue.Any())
            {
                var currentVertex = queue.Dequeue();

                var currentDistance = distanceTable[currentVertex].distance;

                foreach (var vertice in GetAdjacentVertices(currentVertex))
                {
                    if (!distanceTable.ContainsKey(vertice))
                    {
                        var newDistance = 1 + currentDistance;

                        distanceTable[vertice] = (newDistance, currentVertex);
                        if (GetAdjacentVertices(vertice).Count > 0)
                            queue.Enqueue(vertice);
                    }
                }
            }
            return distanceTable;
        }
    }
    public class Node
    {
        public int VertexId { get; set; }
        public HashSet<int> AdjacencySet { get; private set; }

        public Node(int vertexId)
        {
            VertexId = vertexId;
            AdjacencySet = new HashSet<int>();
        }

        public void AddEdge(int vertice)
        {
            if (VertexId == vertice)
                return;
            AdjacencySet.Add(vertice);
        }

        public List<int> GetAdjacentVertices()
        {
            var orderedList = AdjacencySet.ToList();
            orderedList.Sort();
            return orderedList;
        }
    }
}
