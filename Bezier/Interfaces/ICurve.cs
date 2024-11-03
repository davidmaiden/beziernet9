using System.Drawing;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BezierTests")]
namespace Bezier.Interfaces;

public interface ICurve
{
    Point[] Points { get; }
}
