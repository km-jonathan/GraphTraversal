namespace Graph_Traversal;

public class GraphMaster
{
    public Graph ConstructRandomGraph(int vertexCount, int edgeCount)
    {
        ValidateGraphParameters(vertexCount, edgeCount);
        
        IGraphBuilder builder = new RandomGraphBuilder();
        return builder
            .AddVertices(vertexCount)
            .EnsureConnectivity()
            .AddRemainingEdges(edgeCount)
            .Build();
    }
    
    private void ValidateGraphParameters(int n, int s)
    {
        if (n <= 0)
        {
            throw new ArgumentException("Number of vertices must be positive");
        }

        if (s < n - 1 || s > n * (n - 1))
        {
            throw new ArgumentException($"Sparseness must be between {n - 1} and {n * (n - 1)} for a graph with {n} vertices");
        }
    }
}