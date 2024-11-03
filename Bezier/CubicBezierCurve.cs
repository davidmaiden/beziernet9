using Bezier.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Bezier;

public class CubicBezierCurve : Curve
{
    private readonly List<Point> _points;
    private readonly IPointCalculator _pointCalculator;
    private readonly IPolygonAnalyser _polygonAnalyser;
    private readonly IInputAnalyser _inputAnalyser;

    internal CubicBezierCurve(Point[] points,
                              int intervals,
                              IPointCalculator pointCalculator,
                              IPolygonAnalyser polygonAnalyser,
                              IInputAnalyser inputAnalyser)
    {
        _pointCalculator = pointCalculator;
        _polygonAnalyser = polygonAnalyser;
        _inputAnalyser = inputAnalyser;
        _points = new List<Point>();

        if (!_inputAnalyser.IsValidInput(points, intervals))
            throw new ArgumentException("Invalid input");

        if (!_polygonAnalyser.IsControlPolygon(points))
            throw new ArgumentException("Points entered do not form a control polygon", nameof(points));

        for (var ndx = 0; ndx < intervals + 1; ndx++)
        {
            var t = (float)ndx / (float)intervals;
            var curvePoint = _pointCalculator.Calculate(points, t);
            _points.Add(curvePoint);
            Points = _points.ToArray();
        }
    }
}
