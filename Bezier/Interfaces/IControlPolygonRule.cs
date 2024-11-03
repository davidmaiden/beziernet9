using System.Drawing;

namespace Bezier.Interfaces;

interface IControlPolygonRule : IRule
{
    bool Evaluate(Point[] points);
}
