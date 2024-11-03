using BenchmarkDotNet.Attributes;
using Bezier;
using Bezier.Interfaces;
using System.Drawing;

namespace Benchmarks;

[MemoryDiagnoser]
public class Analyser
{
    public Point P0 { get; set; }
    public Point P1 { get; set; }
    public Point P2 { get; set; }
    public Point P3 { get; set; }
    int Intervals { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        P0 = new Point(100, 100);
        P1 = new Point(50, 120);
        P2 = new Point(50, 280);
        P3 = new Point(300, 300);
        Intervals = 10;
    }

    [Benchmark]
    public void DoBezier()
    {
        ICurve sut = CurveFactory.CreateCubicBezierCurve(P0, P1, P2, P3, Intervals);
    }
}
