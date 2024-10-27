using NUnit.Framework;
using FluentAssertions;

namespace Basic.Samples.Specifications;


[TestFixture]
public class Stack_Specification
{
    [Test]
    public void Constructor_CreatesEmptyStack()
    {
        // ReSharper disable once CollectionNeverUpdated.Local
        var stack = new Stack<int>();

        0.Should().Be(stack.Count);
    }

    [Test]
    public void Constructor_PushesItemsToEmptyStack()
    {
        var stack = new Stack<int>(new[] { 1, 2, 3 });

        3.Should().Be(stack.Count);
        3.Should().Be(stack.Pop());
        2.Should().Be(stack.Pop());
        1.Should().Be(stack.Pop());
        0.Should().Be(stack.Count);
    }

    [Test]
    public void ToArray_ReturnsItemsInPopOrder()
    {
        var stack = new Stack<int>(new[] { 1, 2, 3 });

        new[] { 3, 2, 1 }.Should().BeEquivalentTo(stack.ToArray());
    }

    [Test]
    public void Push_AddsItemToStackTop()
    {
        var stack = new Stack<int>(new[] { 1, 2, 3 });

        stack.Push(42);

        new[] { 42, 3, 2, 1 }.Should().BeEquivalentTo(stack.ToArray());
    }

    [Test]
    public void Pop_OnEmptyStack_Fails()
    {
        var stack = new Stack<int>();
        Action action = () => stack.Pop();

        action.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void Pop_ReturnsLastPushedItem()
    {
        var stack = new Stack<int>(new[] { 1, 2, 3 });

        stack.Push(42);

        42.Should().Be(stack.Pop());
    }
}
