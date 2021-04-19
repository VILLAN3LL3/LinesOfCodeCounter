using System;
using FluentAssertions;
using LinesOfCodeCounter.Domain;
using NUnit.Framework;

namespace LinesOfCodeCounter.Tests.Domain
{
    [TestFixture]
    public class LineCounterTests
    {
        private string[] _lines;

        [OneTimeSetUp]
        public void SetUp()
        {
            _lines = new string[] {
                "  {",
                "    public class Foo",
                Environment.NewLine,
                string.Empty,
                " ",
                "// Comment",
                "       // Comment with white space",
            };
        }

        private LineCounter CreateLineCounter() => new LineCounter();

        [Test]
        public void Should_Count_Lines()
        {
            LineCounter lineCounter = CreateLineCounter();

            int result = lineCounter.CountLines(
                _lines);

            result.Should().Be(7);
        }

        [Test]
        public void Should_Count_Lines_Of_Code()
        {
            LineCounter lineCounter = CreateLineCounter();

            int result = lineCounter.CountLinesOfCode(
                _lines);

            result.Should().Be(2);
        }
    }
}
