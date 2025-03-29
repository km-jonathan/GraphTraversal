using System.Text;
namespace Graph_Traversal;

// Task 1 - Extend the graph definition to include a weight between graph edges
// Task 1.1 - Define an Edge class with weights
public class Edge
{
    public int Destination { get; set; }
    public int Weight { get; set; }
    
    public override string ToString()
    {
        return $"({Destination} {Weight})";
    }
}

// Task 1.2 - Define the extended Graph class
public class Graph
{
    private const int WEIGHTRANGE = 10;
    private static Random _random = new ();
    
    public Dictionary<int, List<Edge>> Vertices = new();
    
    public void AddVertex(int vertex)
    {
        // assumption: dont allow duplicate vertices
        if (!Vertices.ContainsKey(vertex))
        {
            Vertices[vertex] = [];
        }
    }
    
    public void AddEdge(int source, int destination, int weight)
    {
        if (!Vertices.ContainsKey(source))
        {
            AddVertex(source);
        }
        
        if (!Vertices.ContainsKey(destination))
        {
            AddVertex(destination);
        }
        
        Vertices[source].Add(new Edge{ Destination = destination, Weight = weight });
    }
    
    // Task 2 - Randomly generate a simple directed graph
    public static Graph GenerateRandomGraph(int n, int s)
    {
        if (n <= 0)
        {
            throw new ArgumentException("Number of vertices must be positive");
        }

        if (s < n - 1 || s > n * (n - 1))
        {
            throw new ArgumentException($"Sparseness must be between {n - 1} and {n * (n - 1)} for a graph with {n} vertices");
        }

        var graph = new Graph();
        
        var vertexValues = Enumerable.Range(1, n).ToList();
        
        foreach (var vertex in vertexValues)
        {
            graph.AddVertex(vertex);
        }
        
        var randomStartIndex = _random.Next(vertexValues.Count);
        var randomStartVertex = vertexValues[randomStartIndex];
        
        var connectedVertices = new List<int> { randomStartVertex };
        var unconnectedVertices = vertexValues.Where(o => o != randomStartVertex).ToList();
        
        // Task 2.1 - Ensure that your graph is connected
        while (unconnectedVertices.Count > 0)
        {
            // assumption: node values can be any random value in vertexValues
            var source = connectedVertices[_random.Next(connectedVertices.Count)];
            var target = unconnectedVertices[_random.Next(unconnectedVertices.Count)];
            
            // assumption: weight can be any random number between 1 and 9
            var weight = _random.Next(1, WEIGHTRANGE); 
            
            graph.AddEdge(source, target, weight);
            
            connectedVertices.Add(target);
            unconnectedVertices.Remove(target);
        }
        
        // Add remaining edges randomly up to S
        var otherEdges = s - (n - 1);
        var existingEdges = new HashSet<(int, int)>();
        
        // record existing edges
        foreach (var source in vertexValues)
        {
            foreach (var edge in graph.Vertices[source])
            {
                existingEdges.Add((source, edge.Destination));
            }
        }
        
        while (otherEdges > 0)
        {
            var source = vertexValues[_random.Next(vertexValues.Count)];
            var target = vertexValues[_random.Next(vertexValues.Count)];
            
            // simple directed graph should not have self-loops (source == target)
            // avoid existing edges
            if (source == target || existingEdges.Contains((source, target)))
                continue;
            
            var weight = _random.Next(1, WEIGHTRANGE);
            graph.AddEdge(source, target, weight);
            existingEdges.Add((source, target));
            otherEdges--;
        }
        
        return graph;
    }
    
    public int GetRandomVertex(int excludeValue = 0)
    {
        var keys = Vertices.Keys.ToList();

        if (excludeValue > 0)
        {
            keys = keys.Where(o => o != excludeValue).ToList();
        }
        
        if (keys.Count == 0)
        {
            return 0;
        }
        
        return keys[_random.Next(keys.Count)];
    } 
    
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("{");
            
        foreach (var vertex in Vertices.OrderBy(v => v.Key))
        {
            sb.Append($"  {vertex.Key} [");
            sb.Append(string.Join(", ", vertex.Value.Select(e => e.ToString())));
            sb.AppendLine("]");
        }
            
        sb.AppendLine("}");
        return sb.ToString();
    }
}
