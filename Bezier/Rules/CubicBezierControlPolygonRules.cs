using Bezier.Interfaces;
using System.Collections.Generic;

namespace Bezier.Rules;

class CubicBezierControlPolygonRules : IRuleCollection<IControlPolygonRule>
{
    private readonly ICollection<IControlPolygonRule> _rules;

    internal CubicBezierControlPolygonRules()
    {
        _rules = new List<IControlPolygonRule>
        {
            new IsNotNullRule(),
            new FourUniquePointsRule()
        };
    }

    public ICollection<IControlPolygonRule> Rules => _rules;
}
