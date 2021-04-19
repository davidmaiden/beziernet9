using Bezier.Interfaces;
using System.Drawing;

namespace Bezier.Rules
{
    class IsNotNullRule : IControlPolygonRule
    {
        public bool Evaluate(Point[] points) => points is not null;
    }
}
