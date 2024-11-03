using BenchmarkDotNet.Running;
using System;

namespace Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Analyser>();
        }
    }
}
