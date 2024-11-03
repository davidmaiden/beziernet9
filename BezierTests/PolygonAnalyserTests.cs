using Bezier;
using Bezier.Interfaces;
using Bezier.Rules;
using System.Drawing;
using Xunit;
using Xunit.Abstractions;

namespace BezierTests;

public class PolygonAnalyserTests
{
    private readonly ITestOutputHelper _output;
    public PolygonAnalyserTests(ITestOutputHelper output)
    {
        _output = output;
    }

    /// <summary>
    /// This is the one of two initial tests
    /// </summary>
    [Fact]
    public void Null_Is_Not_A_Valid_Control_Polygon()
    {
        // arrange
        IRuleCollection<IControlPolygonRule> rules = new CubicBezierControlPolygonRules();
        IPolygonAnalyser sut = new PolygonAnalyser(rules);

        // act
        var result = sut.IsControlPolygon(null);

        //assert
        Assert.False(result);
    }

    /// <summary>
    /// This is the second of two initial tests
    /// </summary>
    [Fact]
    public void Four_Points_Is_Valid_Control_Polygon()
    {
        // arrange
        var input = new Point[] { new Point(100, 100), new Point(200, 200), new Point(300, 300), new Point(400, 400) };
        IRuleCollection<IControlPolygonRule> rules = new CubicBezierControlPolygonRules();
        IPolygonAnalyser sut = new PolygonAnalyser(rules);

        // act
        var result = sut.IsControlPolygon(input);

        //assert
        Assert.True(result);
    }

    /// <summary>
    /// Check that three is not a valid polygon 
    /// </summary>
    [Fact]
    public void Three_Points_Is_Not_A_Valid_Control_Polygon()
    {
        // arrange
        var input = new Point[] { new Point(100, 100), new Point(200, 200), new Point(300, 300) };
        IRuleCollection<IControlPolygonRule> rules = new CubicBezierControlPolygonRules();
        IPolygonAnalyser sut = new PolygonAnalyser(rules);

        // act
        var result = sut.IsControlPolygon(input);

        //assert
        Assert.False(result);
    }

    /// <summary>
    /// Check that three is not a valid polygon 
    /// </summary>
    [Fact]
    public void More_Than_Four_Points_Is_Not_A_Valid_Control_Polygon()
    {
        // arrange
        var input = new Point[] { new Point(100, 100), new Point(200, 200), new Point(300, 300), new Point(400, 400), new Point(500, 500) };
        IRuleCollection<IControlPolygonRule> rules = new CubicBezierControlPolygonRules();
        IPolygonAnalyser sut = new PolygonAnalyser(rules);

        // act
        var result = sut.IsControlPolygon(input);

        //assert
        Assert.False(result);
    }

    /// <summary>
    /// If any points are duplicated then its not a valid control polygon
    /// </summary>
    [Fact]
    public void Duplicated_Points_Is_Not_A_Valid_Control_Polygon()
    {
        // arrange
        var input = new Point[] { new Point(100, 100), new Point(200, 200), new Point(200, 200), new Point(300, 300) };
        IRuleCollection<IControlPolygonRule> rules = new CubicBezierControlPolygonRules();
        IPolygonAnalyser sut = new PolygonAnalyser(rules);
        // act
        var result = sut.IsControlPolygon(input);

        //assert
        Assert.False(result);
    }
}
