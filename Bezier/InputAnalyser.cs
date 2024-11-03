using Bezier.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Bezier;

class InputAnalyser : IInputAnalyser
{
    private readonly List<IInputRule> _rules;

    public InputAnalyser(IRuleCollection<IInputRule> rules)
    {
        _rules = new List<IInputRule>(rules.Rules);
    }

    public bool IsValidInput(Point[] points, int intervals)
    {
        return _rules.All(rule => rule.Evaluate(points, intervals));
    }
}
