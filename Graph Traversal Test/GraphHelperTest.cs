using Graph_Traversal;

namespace Graph_Traversal_Test;

[TestClass]
public class GraphHelperTest
{
    private Graph _graph;
    
    [TestInitialize]
    public void Initialize()
    {
        _graph = new Graph
        {
            Vertices = new Dictionary<int, List<Edge>>
            {
                {
                    1, new List<Edge>
                    {
                        new Edge { Destination = 2, Weight = 1 }, 
                        new Edge { Destination = 3, Weight = 4 }
                    } 
                },
                {
                    2, new List<Edge>
                    {
                        new Edge { Destination = 3, Weight = 6 }, 
                        new Edge { Destination = 7, Weight = 1 }
                    } 
                },
                {
                    3, new List<Edge>()
                },
                {
                    4, new List<Edge>
                    {
                        new Edge { Destination = 1, Weight = 1 }, 
                        new Edge { Destination = 5, Weight = 2 }, 
                        new Edge { Destination = 7, Weight = 8 }
                    } 
                },
                {
                    5, new List<Edge>
                    {
                        new Edge { Destination = 2, Weight = 3 }
                    } 
                },
                {
                    6, new List<Edge>
                    {
                        new Edge { Destination = 5, Weight = 5 }
                    } 
                },
                {
                    7, new List<Edge>
                    {
                        new Edge { Destination = 4, Weight = 7 }
                    } 
                }
            }
        };
    }
    
    [TestMethod]
    public void ReturnShortestPath()
    {
        var path = GraphHelper.GetShortestPath(_graph, 4, 7);
        
        CollectionAssert.AreEqual(new List<int> { 4, 1, 2, 7 }, path);
    }
    
    [TestMethod]
    public void ReturnShortestPathNotFound()
    {
        var path = GraphHelper.GetShortestPath(_graph, 4, 6);
        
        CollectionAssert.AreEqual(new List<int>(), path);
    }
    
    [TestMethod]
    public void ReturnPathDistance()
    {
        var path = GraphHelper.GetShortestPath(_graph, 4, 7);
        var distance = GraphHelper.GetPathDistance(_graph, path);
        
        Assert.AreEqual(3, distance);
    }
    
    [TestMethod]
    public void ReturnEccentricity()
    {
        var eccentricity_1 = GraphHelper.GetEccentricity(_graph, 1);
        var eccentricity_2 = GraphHelper.GetEccentricity(_graph, 2);
        var eccentricity_3 = GraphHelper.GetEccentricity(_graph, 3);
        var eccentricity_4 = GraphHelper.GetEccentricity(_graph, 4);
        var eccentricity_5 = GraphHelper.GetEccentricity(_graph, 5);
        var eccentricity_6 = GraphHelper.GetEccentricity(_graph, 6);
        var eccentricity_7 = GraphHelper.GetEccentricity(_graph, 7);
        
        Assert.AreEqual(11, eccentricity_1);
        Assert.AreEqual(10, eccentricity_2);
        Assert.AreEqual(0, eccentricity_3);
        Assert.AreEqual(5, eccentricity_4);
        Assert.AreEqual(12, eccentricity_5);
        Assert.AreEqual(17, eccentricity_6);
        Assert.AreEqual(12, eccentricity_7);
    }
    
    [TestMethod]
    public void ReturnRadius()
    {
        var radius = GraphHelper.GetRadius(_graph);
        
        Assert.AreEqual(5, radius);
    }
    
    [TestMethod]
    public void ReturnDiameter()
    {
        var diameter = GraphHelper.GetDiameter(_graph);
        
        Assert.AreEqual(17, diameter);
    }

}