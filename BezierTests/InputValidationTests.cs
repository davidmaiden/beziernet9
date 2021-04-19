using Bezier;
using Bezier.Interfaces;
using Bezier.Rules;
using System.Drawing;
using Xunit;
using Xunit.Abstractions;

namespace BezierTests
{
    public class InputValidationTests
    {
        private readonly ITestOutputHelper _output;
        public InputValidationTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Too_Few_Intervals()
        {
            // arrange
            IRuleCollection<IInputRule> rules = new CubicBezierInputValidationRules();
            IInputAnalyser sut = new InputAnalyser(rules);

            // act
            var input = new Point[] { new Point(100, 100), new Point(200, 200), new Point(300, 300), new Point(400, 400) };
            var result = sut.IsValidInput(input, 3);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void Same_Number_Of_Intervals()
        {
            // arrange
            IRuleCollection<IInputRule> rules = new CubicBezierInputValidationRules();
            IInputAnalyser sut = new InputAnalyser(rules);

            // act
            var input = new Point[] { new Point(100, 100), new Point(200, 200), new Point(300, 300), new Point(400, 400) };
            var result = sut.IsValidInput(input, 4);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void Higher_Number_Of_Intervals()
        {
            // arrange
            IRuleCollection<IInputRule> rules = new CubicBezierInputValidationRules();
            IInputAnalyser sut = new InputAnalyser(rules);

            // act
            var input = new Point[] { new Point(100, 100), new Point(200, 200), new Point(300, 300), new Point(400, 400) };
            var result = sut.IsValidInput(input, 10);

            //assert
            Assert.True(result);
        }
    }
}
