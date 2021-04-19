using Bezier.Interfaces;
using System.Collections.Generic;

namespace Bezier.Rules
{
    class CubicBezierInputValidationRules : IRuleCollection<IInputRule>
    {
        private readonly ICollection<IInputRule> _rules;

        internal CubicBezierInputValidationRules()
        {
            _rules = new List<IInputRule>
            {
                new MinimumIntervalsRule()
            };
        }

        public ICollection<IInputRule> Rules => _rules;
    }
}
