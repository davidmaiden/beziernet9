using Bezier;
using Bezier.Interfaces;
using System.Drawing;
using Xunit;
using Xunit.Abstractions;

namespace BezierTests;

public class BezierCurveTests
{
    private readonly ITestOutputHelper _output;
    public BezierCurveTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Create_Cubic_Bezier_Curve()
    {
        // arrange
        var p0 = new Point(100, 100);
        var p1 = new Point(50, 120);
        var p2 = new Point(50, 280);
        var p3 = new Point(300, 300);
        var intervals = 10;

        // act
        ICurve sut = CurveFactory.CreateCubicBezierCurve(p0, p1, p2, p3, intervals);

        //assert
        // there should be 1 more point than intervals defined.
        Assert.Equal(intervals + 1, sut.Points.Length);

        // write out the points to the test runner output
        for (var ndx = 0; ndx < sut.Points.Length; ndx++)
        {
            _output.WriteLine($"X = {sut.Points[ndx].X}, Y = {sut.Points[ndx].Y}");
        }
    }
}
