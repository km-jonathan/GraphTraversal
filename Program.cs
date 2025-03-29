namespace Graph_Traversal;

class Program
{
    static async Task Main(string[] args)
    {
        int graphSize;
        int graphSparseness;

        try
        {
            if (args.Length >= 2)
            {
                if (!int.TryParse(args[0], out graphSize))
                {
                    Console.WriteLine("Error: Size (N) must be an integer.");
                    return;
                }
                
                if (!int.TryParse(args[1], out graphSparseness))
                {
                    Console.WriteLine("Error: Sparseness (S) must be a number.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Please enter size (N) for the graph:");
                var sizeInput = Console.ReadLine();
                if (!int.TryParse(sizeInput, out graphSize))
                {
                    Console.WriteLine("Error: Size (N) must be an integer.");
                    return;
                }
                
                Console.WriteLine("Please enter sparseness (S) for the graph:");
                var sparsenessInput = Console.ReadLine();
                if (!int.TryParse(sparsenessInput, out graphSparseness))
                {
                    Console.WriteLine("Error: Sparseness (S) must be a number.");
                    return;
                }
            }

            if (graphSize < 1)
            {
                Console.WriteLine("Error: Graph Size (N) must be greater than 0.");
            }

            if (graphSparseness < graphSize - 1 || graphSparseness > graphSize * (graphSize - 1))
            {
                Console.WriteLine($"Error: Sparseness (S) must be between {graphSize - 1} and {graphSize * (graphSize - 1)} for a graph with {graphSize} vertices.");
            }
            
            // TODO: print out the randomly generated graph
            var graph = Graph.GenerateRandomGraph(graphSize, graphSparseness);
            Console.WriteLine($"Graph: {graph}");
            
            // TODO: print out the distance properties of the graph (radius, diameter)
            Console.WriteLine($"Radius: {GraphHelper.GetRadius(graph)}");
            Console.WriteLine($"Diameter: {GraphHelper.GetDiameter(graph)}");

            // TODO: randomly select 2 nodes and print the shortest path distance between them
            var start = graph.GetRandomVertex();
            var end = graph.GetRandomVertex(start);
            Console.WriteLine($"Randomly selected two vertices: [{start}], [{end}]");
            
            var shortestPath = GraphHelper.GetShortestPath(graph, start, end);
            Console.WriteLine(shortestPath.Count != 0
                ? $"Shortest path from [{start}] to [{end}]: {string.Join(",", shortestPath)}"
                : $"No path found between [{start}] and [{end}]");

            // TODO: compute eccentricity of a random node
            var randomNode = graph.GetRandomVertex();
            Console.WriteLine($"Random node selected for eccentricity calculation: [{randomNode}]");
            var eccentricity = GraphHelper.GetEccentricity(graph, randomNode);
            Console.WriteLine($"Eccentricity of vertex [{randomNode}]: {eccentricity}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}