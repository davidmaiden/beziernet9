using System.Drawing;

namespace Bezier.Interfaces
{
    interface IInputRule : IRule
    {
        bool Evaluate(Point[] points, int intervals);
    }
}
