namespace Graph_Traversal;

public interface IGraphBuilder
{
    IGraphBuilder AddVertices(int count);
    IGraphBuilder EnsureConnectivity();
    IGraphBuilder AddRemainingEdges(int totalEdges);
    Graph Build();
}