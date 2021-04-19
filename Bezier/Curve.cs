using Bezier.Interfaces;
using System.Drawing;

namespace Bezier
{
    public abstract class Curve : ICurve
    {
        public Point[] Points { get; init; }
    }
}
