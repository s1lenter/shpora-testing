using FluentAssertions;
using NUnit.Framework;

namespace Samples.AAA;

[TestFixture]
public class ZipTests
{
    [Test]
    public void GiveResultOfSameSize_OnEqualSizeArrays()
    {
        var arr1 = new[] { 1 };
        var arr2 = new[] { 2 };

        var expected = new[] { Tuple.Create(1, 2) };
        var result = arr1.Zip(arr2, Tuple.Create);


        expected.Should().BeEquivalentTo(result);
    }

    [Test]
    public void BeEmpty_WhenBothInputsAreEmpty()
    {
        var arr1 = new int[0];
        var arr2 = new int[0];

        var result = arr1.Zip(arr2, Tuple.Create);

        result.Should().BeEmpty();
    }

    [Test]
    public void BeEmpty_WhenFirstIsEmpty()
    {
        var arr1 = new int[0];
        var arr2 = new[] { 1, 2 };

        var result = arr1.Zip(arr2, Tuple.Create);

        result.Should().BeEmpty();
    }

    [Test]
    public void BeEmpty_WhenSecondIsEmpty()
    {
        var arr1 = new[] { 1, 2 };
        var arr2 = new int[0];

        var result = arr1.Zip(arr2, Tuple.Create);

        result.Should().BeEmpty();
    }

    [Test]
    public void HaveLengthOfSecond_WhenFirstContainsMoreElements()
    {
        var arr1 = new[] { 1, 3, 5, 7 };
        var arr2 = new[] { 2, 4 };

        var expected = new[] { Tuple.Create(1, 2), Tuple.Create(3, 4) };
        var result = arr1.Zip(arr2, Tuple.Create);

        expected.Should().BeEquivalentTo(result);
    }

    [Test]
    public void HaveLengthOfFirst_WhenSecondContainsMoreElements()
    {
        var arr1 = new[] { 1, 3 };
        var arr2 = new[] { 2, 4, 6, 8 };

        var expected = new[] { Tuple.Create(1, 2), Tuple.Create(3, 4) };

        var result = arr1.Zip(arr2, Tuple.Create);

        expected.Should().BeEquivalentTo(result);
    }
}