using Bezier.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Bezier
{
    class PolygonAnalyser : IPolygonAnalyser
    {
        private readonly List<IControlPolygonRule> _rules;

        public PolygonAnalyser(IRuleCollection<IControlPolygonRule> rules)
        {
            _rules = new List<IControlPolygonRule>(rules.Rules);
        }

        public bool IsControlPolygon(Point[] points)
        {
            return _rules.All(rule => rule.Evaluate(points));
        }
    }
}
