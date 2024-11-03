using Bezier.Interfaces;
using System.Drawing;

namespace Bezier.Rules;

class MinimumIntervalsRule : IInputRule
{
    public bool Evaluate(Point[] points, int intervals) => intervals >= points?.Length;
}
