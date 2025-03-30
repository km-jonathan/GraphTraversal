namespace Graph_Traversal;

public class RandomGraphBuilder : GraphBuilderBase
{
    private List<int> vertexValues = [];
    private List<int> connectedVertices = [];
    private List<int> unconnectedVertices = [];
    private HashSet<(int, int)> existingEdges = [];
    
    public override IGraphBuilder AddVertices(int count)
    {
        vertexValues = Enumerable.Range(1, count).ToList();
        
        foreach (var vertex in vertexValues)
        {
            Graph.AddVertex(vertex);
        }
        
        var randomStartIndex = Random.Next(vertexValues.Count);
        var randomStartVertex = vertexValues[randomStartIndex];
        
        connectedVertices = [randomStartVertex];
        unconnectedVertices = vertexValues.Where(o => o != randomStartVertex).ToList();
        
        return this;
    }
    
    public override IGraphBuilder EnsureConnectivity()
    {
        while (unconnectedVertices.Count > 0)
        {
            var source = connectedVertices[Random.Next(connectedVertices.Count)];
            var target = unconnectedVertices[Random.Next(unconnectedVertices.Count)];
            
            var weight = Random.Next(1, WeightRange);
            
            Graph.AddEdge(source, target, weight);
            existingEdges.Add((source, target));
            
            connectedVertices.Add(target);
            unconnectedVertices.Remove(target);
        }
        
        return this;
    }
    
    public override IGraphBuilder AddRemainingEdges(int totalEdges)
    {
        var edgesToAdd = totalEdges - (vertexValues.Count - 1);
        
        if (edgesToAdd <= 0) return this;
        
        while (edgesToAdd > 0)
        {
            var source = vertexValues[Random.Next(vertexValues.Count)];
            var target = vertexValues[Random.Next(vertexValues.Count)];
            
            // No self-loops or duplicate edges
            if (source == target || existingEdges.Contains((source, target)))
            {
                continue;
            }
            
            var weight = Random.Next(1, WeightRange);
            Graph.AddEdge(source, target, weight);
            existingEdges.Add((source, target));
            edgesToAdd--;
        }
        
        return this;
    }
}