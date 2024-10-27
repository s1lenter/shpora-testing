using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections;
using System.Globalization;
using Xunit;

namespace Basic.Samples.Libraries;

[TestFixture]
internal class NUnitTests
{
    [Test]
    public void Sum()
    {
        var result = 1d + 2d;

        ClassicAssert.AreEqual(result, 3d);
    }

    [Test, TestCaseSource(nameof(DivideTestCases))]
    public double Divide(double a, double b)
    {
        return a / b;
    }

    public static IEnumerable DivideTestCases
    {
        get
        {
            yield return new TestCaseData(12.0, 3.0).Returns(4);
            yield return new TestCaseData(12.0, 2.0).Returns(6);
            yield return new TestCaseData(12.0, 4.0).Returns(3);
        }
    }

    [TestCase("123", ExpectedResult = 123, TestName = "integer")]
    [TestCase("1.1", ExpectedResult = 1.1, TestName = "fraction")]
    [TestCase("1.1e1", ExpectedResult = 1.1e1, TestName = "scientific with positive exp")]
    [TestCase("1.1e-1", ExpectedResult = 1.1e-1, TestName = "scientific with negative exp")]
    [TestCase("-0.1", ExpectedResult = -0.1, TestName = "negative fraction")]
    public double Parse_WithInvariantCulture(string input)
    {
        return double.Parse(input, CultureInfo.InvariantCulture);
    }
}


public class XUnitTests
{
    [Fact]
    public void Sum()
    {
        var result = 1d + 2d;

        Xunit.Assert.Equal(3d, result);
    }

    [Xunit.Theory]
    [Xunit.ClassData(typeof(DivideTestCases))]
    public void Divide(double a, double b, double expected)
    {
        Xunit.Assert.Equal(a / b, expected);
    }

    public class DivideTestCases : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 12.0, 3.0, 4 };
            yield return new object[] { 12.0, 2.0, 6 };
            yield return new object[] { 12.0, 4.0, 3 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Xunit.Theory]
    [InlineData("123", 123)]
    [InlineData("1.1", 1.1)]
    [InlineData("1.1e1", 1.1e1)]
    [InlineData("1.1e-1", 1.1e-1)]
    [InlineData("-0.1", -0.1)]
    public void Parse_WithInvariantCulture(string input, double expected)
    {
        Xunit.Assert.Equal(double.Parse(input, CultureInfo.InvariantCulture), expected);
    }
}