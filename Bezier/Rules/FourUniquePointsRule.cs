using Bezier.Interfaces;
using System.Drawing;
using System.Linq;

namespace Bezier.Rules;

class FourUniquePointsRule : IControlPolygonRule
{
    public bool Evaluate(Point[] points) => points?.Distinct().Count() == 4;
}
