﻿using Bezier.Interfaces;
using Bezier.Rules;
using System.Drawing;

namespace Bezier;

public static class CurveFactory
{
    public static ICurve CreateCubicBezierCurve(Point p0, Point p1, Point p2, Point p3, int intervals)
    {
        return new CubicBezierCurve([p0, p1, p2, p3],
                                    intervals,
                                    CreateCubicBezierPointCalculator(),
                                    CreatePolygonAnalyser(),
                                    CreateCubicBezierInputAnalyser());
    }

    internal static IPolygonAnalyser CreatePolygonAnalyser()
    {
        return new PolygonAnalyser(CreateCubicBezierControlPolygonRules());
    }

    internal static IInputAnalyser CreateCubicBezierInputAnalyser()
    {
        return new InputAnalyser(CreateCubicBezierInputValidationRules());
    }

    internal static IRuleCollection<IControlPolygonRule> CreateCubicBezierControlPolygonRules()
    {
        return new CubicBezierControlPolygonRules();
    }

    internal static IRuleCollection<IInputRule> CreateCubicBezierInputValidationRules()
    {
        return new CubicBezierInputValidationRules();
    }

    internal static IPointCalculator CreateCubicBezierPointCalculator()
    {
        return new CubicBezierPointCalculator();
    }
}
