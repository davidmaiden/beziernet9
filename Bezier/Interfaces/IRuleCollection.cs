using System.Collections.Generic;

namespace Bezier.Interfaces;

interface IRuleCollection<T> where T : IRule
{
    ICollection<T> Rules { get; }
}