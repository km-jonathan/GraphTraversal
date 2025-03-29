namespace Graph_Traversal;

public abstract class GraphBuilderBase : IGraphBuilder
{
    public Graph graph = new Graph();
    public static readonly Random Random = new();
    public const int WeightRange = 10;
    
    public abstract IGraphBuilder AddVertices(int count);
    public abstract IGraphBuilder EnsureConnectivity();
    public abstract IGraphBuilder AddRemainingEdges(int totalEdges);
    
    public virtual Graph Build()
    {
        return graph;
    }
}