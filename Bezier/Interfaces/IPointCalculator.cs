using System.Drawing;

namespace Bezier.Interfaces
{
    interface IPointCalculator
    {
        Point Calculate(Point[] points, float t);
    }
}
