using System;
using FluentAssertions;
using LinesOfCodeCounter.Model;
using NUnit.Framework;

namespace LinesOfCodeCounter.Tests
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
            // Arrange
            ConsoleUi consoleUi = CreateConsoleUi();
            var linesOfCodeStat = new LinesOfCodeStat("filePath", 10, 5);
            string expectedResult = $"filePath 10 5{Environment.NewLine}";

            // Act
            consoleUi.PrintLinesOfCodeStatToConsole(
                linesOfCodeStat);

            // Assert
            ( _mockConsole as MockConsoleWrapper ).MockConsole.ToString().Should().Be(expectedResult);
        }

        [Test]
        public void PShould_Print_Lines_Of_Code_Summary_To_Console()
        {
            // Arrange
            ConsoleUi consoleUi = CreateConsoleUi();
            var linesOfCodeSummary = new LinesOfCodeSummary(10000, 5000);
            string expectedResult = $"Total{Environment.NewLine}   Lines 10.000{Environment.NewLine}   Lines of Code 5.000{Environment.NewLine}";

            // Act
            consoleUi.PrintLinesOfCodeSummaryToConsole(
                linesOfCodeSummary);

            // Assert
            ( _mockConsole as MockConsoleWrapper ).MockConsole.ToString().Should().Be(expectedResult);
        }
    }
}
