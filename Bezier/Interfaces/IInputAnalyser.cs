using System.Drawing;

namespace Bezier.Interfaces;

interface IInputAnalyser
{
    bool IsValidInput(Point[] points, int intervals);
}
