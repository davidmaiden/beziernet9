using System.Drawing;

namespace Bezier.Interfaces
{
    interface IPolygonAnalyser
    {
        bool IsControlPolygon(Point[] points);
    }
}
