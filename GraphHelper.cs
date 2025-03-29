namespace Graph_Traversal;

public static class GraphHelper
{
    // Task 3 - Dijkstra's algorithm that traverses the graph and outputs the shortest path between any 2 randomly selected vertices
    public static List<int> GetShortestPath(Graph graph, int start, int end)
    {
        if (!graph.Vertices.ContainsKey(start) || !graph.Vertices.ContainsKey(end))
            return new List<int>(); // return empty list if no path exists
        
        var distances = new Dictionary<int, int>();
        var previous = new Dictionary<int, int?>();
        var unvisited = new HashSet<int>();
        
        foreach (var vertex in graph.Vertices.Keys)
        {
            distances[vertex] = int.MaxValue;
            previous[vertex] = null;
            unvisited.Add(vertex);
        }
        
        distances[start] = 0;
        
        while (unvisited.Count > 0)
        {
            // get vertex with the shortest distance
            int? current = null;
            var minDistance = int.MaxValue;
            
            foreach (var vertex in unvisited)
            {
                if (distances[vertex] < minDistance)
                {
                    minDistance = distances[vertex];
                    current = vertex;
                }
            }

            if (current == null || current == end || minDistance == int.MaxValue)
            {
                break; 
            }
            
            unvisited.Remove(current.Value);
            
            // update distances to neighbors
            foreach (var edge in graph.Vertices[current.Value])
            {
                if (!unvisited.Contains(edge.Destination))
                    continue;
                
                var newDistance = distances[current.Value] + edge.Weight;
                if (newDistance < distances[edge.Destination])
                {
                    distances[edge.Destination] = newDistance;
                    previous[edge.Destination] = current;
                }
            }
        }
        
        if (distances[end] == int.MaxValue)
        {
            return new List<int>();
        }
        
        var path = new List<int>();
        
        int? currentVertex = end;
        
        while (currentVertex != null)
        {
            path.Insert(0, currentVertex.Value);
            currentVertex = previous[currentVertex.Value];
        }
        
        return path;
    }
    
    // Task 4 - Calculate distance properties of a graph
    // Task 4.1 - Eccentricity
    public static int GetEccentricity(Graph graph, int vertex)
    {
        if (!graph.Vertices.ContainsKey(vertex))
            throw new ArgumentException($"Vertex {vertex} not found in the graph");
            
        var maxDistance = 0;
        
        foreach (var otherVertex in graph.Vertices.Keys)
        {
            if (vertex == otherVertex)
            {
                continue;
            }
            
            var shortestPath = GetShortestPath(graph, vertex, otherVertex);

            if (shortestPath.Count == 0)
            {
                continue;
            }
            
            var pathDistance = GetPathDistance(graph, shortestPath);
            maxDistance = Math.Max(maxDistance, pathDistance);
        }
            
        return maxDistance;
    }

    // Task 4.2 - Radius
    public static int GetRadius(Graph graph)
    {
        int minEccentricity = int.MaxValue;
            
        foreach (var vertex in graph.Vertices.Keys)
        {
            var eccentricity = GetEccentricity(graph, vertex);

            if (eccentricity <= 0)
            {
                continue;
            }
            
            minEccentricity = Math.Min(minEccentricity, eccentricity);
        }
            
        return minEccentricity == int.MaxValue ? 0 : minEccentricity;
    }

    // Task 4.3 - Diameter
    public static int GetDiameter(Graph graph)
    {
        int maxEccentricity = -1;
            
        foreach (var vertex in graph.Vertices.Keys)
        {
            var eccentricity = GetEccentricity(graph, vertex);
            
            if (eccentricity <= 0)
            {
                continue;
            }
            
            maxEccentricity = Math.Max(maxEccentricity, eccentricity);
        }
            
        return maxEccentricity;
    }

    private static int GetPathDistance(Graph graph, List<int> path)
    {
        if (path.Count <= 0)
        {
            return 0;
        }

        int totalDistance = 0;
        
        for (int i = 0; i < path.Count - 1; i++)
        {
            var edge = graph.Vertices[path[i]].FirstOrDefault(e => e.Destination == path[i + 1]);

            if (edge == null)
            {
                throw new ArgumentException($"No edge found between vertices {path[i]} and {path[i + 1]}");
            }
            
            totalDistance += edge.Weight;
        }

        return totalDistance;
    }
}