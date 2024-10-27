using FluentAssertions;
using NUnit.Framework;
using TDD.Task;

namespace TDD;

public class GameTests
{
    [Test]
    public void HaveZeroScore_BeforeAnyRolls()
    {
        new Game()
            .GetScore()
            .Should().Be(0);
    }
}