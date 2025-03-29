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
    
    // Test Path
    [TestMethod]
    public void GetShortestPath_ReturnValidShortestPath()
    {
        var path = GraphHelper.GetShortestPath(_graph, 4, 7);
        
        CollectionAssert.AreEqual(new List<int> { 4, 1, 2, 7 }, path);
    }
    
    [TestMethod]
    public void GetShortestPath_PathNotFound_ReturnEmptyList()
    {
        var path = GraphHelper.GetShortestPath(_graph, 4, 6);
        
        CollectionAssert.AreEqual(new List<int>(), path);
    }

    [TestMethod]
    public void GetShortestPath_EmptyGraph_ReturnEmptyList()
    {
        var graph = new Graph();
        var path = GraphHelper.GetShortestPath(graph, 1, 2);
        CollectionAssert.AreEqual(new List<int>(), path);
    }
    
    [TestMethod]
    public void GetPathDistance_ReturnValidPathDistance()
    {
        var path = GraphHelper.GetShortestPath(_graph, 4, 7);
        var distance = GraphHelper.GetPathDistance(_graph, path);
        
        Assert.AreEqual(3, distance);
    }
    
    // Test Eccentricity
    [TestMethod]
    public void GetEccentricity_ReturnValidEccentricity()
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
    public void GetEccentricity_NonExistentVertex_ThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => GraphHelper.GetEccentricity(_graph, 8));
    }

    [TestMethod]
    public void GetEccentricity_EmptyGraph_ThrowsNullException()
    {
        Assert.ThrowsException<ArgumentException>(() => GraphHelper.GetEccentricity(new Graph(), 1));
    }

    [TestMethod]
    public void GetEccentricity_NullGraph_ThrowsNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(() => GraphHelper.GetEccentricity(null, 1));
    }
    
    // Test Radius
    [TestMethod]
    public void GetRadius_ReturnValidRadius()
    {
        var radius = GraphHelper.GetRadius(_graph);
        
        Assert.AreEqual(5, radius);
    }
    
    // Test Diameter
    [TestMethod]
    public void GetDiameter_ReturnValidDiameter()
    {
        var diameter = GraphHelper.GetDiameter(_graph);
        
        Assert.AreEqual(17, diameter);
    }

}