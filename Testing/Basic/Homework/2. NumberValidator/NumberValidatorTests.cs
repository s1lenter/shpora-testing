
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace HomeExercise.Tasks.NumberValidator;

[TestFixture]
public class NumberValidatorTests
{
    private const string PrecisionExceptionMessage = "precision must be a positive number";
    private const string ScaleExceptionMessage = "scale must be a non-negative number less or equal than precision";

    [Test]
    [TestCase(1, 2)]
    [TestCase(1, 1)]
    public void Should_ThrowException_WhenPositivePrecisionLessOrEqualScale(int  precision, int scale)
    {
        var createValidator = () => new NumberValidator(precision, scale, true);

        createValidator.Should().Throw<ArgumentException>()
            .WithMessage(ScaleExceptionMessage);
    }

    [Test]
    public void Should_ThrowException_WhenNegativeScale()
    {
        var createValidator = () => new NumberValidator(1, -1, true);

        createValidator.Should().Throw<ArgumentException>()
            .WithMessage(ScaleExceptionMessage);
    }

    [Test]
    [TestCase(1, 0, true)]
    [TestCase(5, 2, false)]
    [TestCase(4, 3, true)]
    public void Should_NotThrowException_WhenValidParameters(int precision, int scale, bool onlyPositive)
    {
         var createValidator = () => new NumberValidator(precision, scale, onlyPositive);

         createValidator.Should().NotThrow();
    }

    [Test]
    [TestCase(4, 2, true, "12.34")]
    [TestCase(4, 3, true, "+1.23")]
    [TestCase(5, 4, true, "1.2345")]
    public void Should_BeTrue_WhenValidNumber(int precision, int scale, bool onlyPositive, string testNumber)
    {
        var validator = new NumberValidator(precision, scale, onlyPositive);

        validator.IsValidNumber(testNumber).Should().BeTrue(because: $"values is ({precision}, {scale}, onlyPositive: {onlyPositive}, testNumber: {testNumber})");
    }

    [Test]
    public void Should_BeFalse_WhenNegativeNumberWithOnlyPositiveTrue()
    {
        var validator = new NumberValidator(4, 2, true);

        validator.IsValidNumber("-2.34").Should().BeFalse();
    }

    [Test]
    public void Should_BeTrue_WhenNegativeNumberWithOnlyPositiveFalse()
    {
        var validator = new NumberValidator(4, 2, false);

        validator.IsValidNumber("-2.34").Should().BeTrue();
    }

    [Test]
    [TestCase(4, 2, true, "512.34")]
    [TestCase(4, 3, true, "12.345")]
    public void Should_BeFalse_WhenNumberLongerThanPrecision(int precision, int scale, bool onlyPositive, string testNumber)
    {
        var validator = new NumberValidator(precision, scale, onlyPositive);

        validator.IsValidNumber(testNumber).Should().BeFalse();
    }

    [Test]
    public void Should_BeFalse_WhenNumberWithFracLongerThanScaleButValidPrecision()
    {
        var validator = new NumberValidator(5, 2, true);

        validator.IsValidNumber("12.345").Should().BeFalse();
    }

    [Test]
    [TestCase("aaa")]
    [TestCase("bbb")]
    [TestCase("ab.cd")]
    [TestCase("./wqq")]
    public void Should_BeFalse_WhenString(string testNumber)
    {
        var validator = new NumberValidator(4, 2, true);

        validator.IsValidNumber(testNumber).Should().BeFalse();
    }

    [Test]
    public void Should_BeTrue_WhenInt()
    {
        var validator = new NumberValidator(4, 2, true);

        validator.IsValidNumber("12").Should().BeTrue();
    }

    [Test]
    [TestCase("")]
    [TestCase(null)]
    public void Should_BeFalse_WhenNullOrEmpty(string testNumber)
    {
        var validator = new NumberValidator(4, 2, true);

        validator.IsValidNumber(testNumber).Should().BeFalse();
    }

    [Test]
    [TestCase("12.3")]
    [TestCase("12,3")]
    public void Should_BeTrue_WhenDifferentSeparator(string testNumber)
    {
        var validator = new NumberValidator(4, 2, true);

        validator.IsValidNumber(testNumber).Should().BeTrue();
    }

    [Test]
    [TestCase("1.")]
    [TestCase("1,")]
    public void Should_BeFalse_WhenNumberWithinInt(string testNumber)
    {
        var validator = new NumberValidator(4, 2, true);

        validator.IsValidNumber(testNumber).Should().BeFalse();
    }

    [Test]
    [TestCase("1.")]
    [TestCase("1,")]
    public void Should_BeFalse_WhenNumberWithSeparatorButWithinFrac(string  testNumber)
    {
        var validator = new NumberValidator(4, 2, true);

        validator.IsValidNumber(testNumber).Should().BeFalse();
    }

    [Test]
    [TestCase("1.2.3")]
    [TestCase("1,222,3")]
    public void Should_BeFalse_WhenIncorrectNum(string  testNumber)
    {
        var validator = new NumberValidator(4, 2, true);

        validator.IsValidNumber(testNumber).Should().BeFalse();
    }

    [Test]
    [TestCase("    12")]
    [TestCase("12    ")]
    [TestCase("1   2")]
    public void Should_BeFalse_WhenNumWithWhitespaces(string  testNumber)
    {
        var validator = new NumberValidator(4, 2, true);
        
        validator.IsValidNumber(testNumber).Should().BeFalse(because: $"value is {testNumber}");
    }
}