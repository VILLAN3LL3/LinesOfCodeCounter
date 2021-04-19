using System;
using System.Collections.Generic;
using FluentAssertions;
using LinesOfCodeCounter.Domain;
using LinesOfCodeCounter.IO;
using NSubstitute;
using NUnit.Framework;

namespace LinesOfCodeCounter.Tests.Domain
{
    [TestFixture]
    public class FileCrawlerTests
    {
        private IDirectoryReader _subDirectoryReader;

        [SetUp]
        public void SetUp() => _subDirectoryReader = Substitute.For<IDirectoryReader>();

        private FileCrawler CreateFileCrawler() => new FileCrawler(
                _subDirectoryReader);

        [Test]
        public void Should_Find_Source_File_Names()
        {
            // Arrange
            FileCrawler fileCrawler = CreateFileCrawler();
            string directory = "TestData";
            _subDirectoryReader.GetFiles("TestData", "*.cs").Returns(new string[] { @"TestData\TestData.cs" });
            _subDirectoryReader.GetDirectories("TestData").Returns(new string[] { @"TestData\TestDataSubDirectory" });
            _subDirectoryReader.GetFiles(@"TestData\TestDataSubDirectory", "*.cs").Returns(new string[] { @"TestData\TestDataSubDirectory\SubTestData.cs" });
            _subDirectoryReader.GetDirectories(@"TestData\TestDataSubDirectory").Returns(Array.Empty<string>());
            var expectedResult = new List<string>()
            {
                @"TestData\TestData.cs",
                @"TestData\TestDataSubDirectory\SubTestData.cs"
            };

            // Act
            IEnumerable<string> result = fileCrawler.FindSourceFileNames(
                directory);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
