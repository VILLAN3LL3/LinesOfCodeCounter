using System;
using FluentAssertions;
using LinesOfCodeCounter.Model;
using LinesOfCodeCounter.UI;
using NUnit.Framework;

namespace LinesOfCodeCounter.Tests.UI
{
    [TestFixture]
    public class ConsoleUiTests
    {
        private IConsole _mockConsole;

        [SetUp]
        public void SetUp() => _mockConsole = new MockConsoleWrapper();

        private ConsoleUi CreateConsoleUi() => new ConsoleUi(
                _mockConsole);

        [Test]
        public void Should_Print_Lines_Of_Code_Stat_To_Console()
        {
            ConsoleUi consoleUi = CreateConsoleUi();
            var linesOfCodeStat = new LinesOfCodeStat("filePath", 10, 5);
            string expectedResult = $"filePath 10 5{Environment.NewLine}";

            consoleUi.PrintLinesOfCodeStatToConsole(
                linesOfCodeStat);

            ( _mockConsole as MockConsoleWrapper ).MockConsole.ToString().Should().Be(expectedResult);
        }

        [Test]
        public void Should_Print_Lines_Of_Code_Summary_To_Console()
        {
            ConsoleUi consoleUi = CreateConsoleUi();
            var linesOfCodeSummary = new LinesOfCodeSummary(10000, 5000);
            string expectedResult = $"Total{Environment.NewLine}   Lines 10.000{Environment.NewLine}   Lines of Code 5.000{Environment.NewLine}";

            consoleUi.PrintLinesOfCodeSummaryToConsole(
                linesOfCodeSummary);

            ( _mockConsole as MockConsoleWrapper ).MockConsole.ToString().Should().Be(expectedResult);
        }
    }
}
