using Bezier.Interfaces;
using System.Drawing;

namespace Bezier;

class CubicBezierPointCalculator : IPointCalculator
{
    public Point Calculate(Point[] points, float t)
    {
        var x = (Math.Pow((1 - t), 3) * points[0].X)
              + (3 * t * Math.Pow((1 - t), 2) * points[1].X)
              + (3 * Math.Pow(t, 2) * (1 - t) * points[2].X)
              + (Math.Pow(t, 3) * points[3].X);

        var y = (Math.Pow((1 - t), 3) * points[0].Y)
              + (3 * t * Math.Pow((1 - t), 2) * points[1].Y)
              + (3 * Math.Pow(t, 2) * (1 - t) * points[2].Y)
              + (Math.Pow(t, 3) * points[3].Y);

        return new Point((int)x, (int)y);
    }
}
