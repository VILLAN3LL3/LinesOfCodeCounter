using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using LinesOfCodeCounter.Model;
using NUnit.Framework;

namespace LinesOfCodeCounter.Tests
{
    [TestFixture]
    public class InteractorTests
    {
        private Interactor CreateInteractor() => new Interactor();

        [Test]
        public void GetLinesOfCodeStats_StateUnderTest_ExpectedBehavior()
        {
            Interactor interactor = CreateInteractor();
            string directory = "TestData";
            var expectedResult = new List<LinesOfCodeStat>()
            {
                new LinesOfCodeStat(Path.Combine(directory, "TestData.cs"), 11, 9),
                new LinesOfCodeStat(Path.Combine(directory, "TestDataSubDirectory", "SubTestData.cs"), 9, 6)
            };

            IEnumerable<LinesOfCodeStat> result = interactor.GetLinesOfCodeStats(
                directory);

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
