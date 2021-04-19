using System;
using System.Collections.Generic;
using System.Drawing;
using CommandLine;
using Bezier;
using System.Linq;

namespace BezierConsole
{
    class Program
    {
        [Verb("createcubic", HelpText = "To create a cubic bezier curve")]
        class CubicOptions
        {
            [Option('p', "points", Required = true, HelpText = "Control points - Format: x,y;x,y;x,y", Separator = ';')]
            public IEnumerable<Point> Points { get; set; }

            [Option('i', "intervals", Required = true, HelpText = "Number of intervals")]
            public int Intervals { get; set; }
        }

        [Verb("quit", HelpText = "Quit/exit")]
        class QuitOptions
        {
            public bool Quit => true;
        }

        static void Main(string[] args)
        {
            var run = true;
            while (run)
            {
                Console.Write("Bezier Test> ");
                var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                Parser.Default.ParseArguments<CubicOptions, QuitOptions>(input).MapResult(
                (CubicOptions opts) =>
                {
                    try
                    {
                        var controlPoints = opts.Points.ToArray();
                        var cubicBezierCurve = CurveFactory.CreateCubicBezierCurve(controlPoints[0], controlPoints[1], controlPoints[2], controlPoints[3], opts.Intervals);

                        cubicBezierCurve.Points.ToList().ForEach(p =>
                        {
                            Console.WriteLine($"X = {p.X}, Y = {p.Y}");
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    return 0;
                },
                (QuitOptions opts) =>
                {
                    run = !opts.Quit;
                    return 0;
                },
                errors => 1);
            }
        }
    }
}
