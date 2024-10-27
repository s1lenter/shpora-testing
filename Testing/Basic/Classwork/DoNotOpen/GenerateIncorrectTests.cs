using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Basic.Classwork.DoNotOpen;

[TestFixture]
public class GenerateIncorrectTests
{
    [Test]
    public void Generate()
    {
        var impls = ChallengeHelpers.GetIncorrectImplementationTypes();
        var code = string.Join(Environment.NewLine,
            impls.Select(imp => $"public class {imp.Name}Tests : {nameof(IncorrectImplementationTestsBase)} {{}}")
            );
        Console.WriteLine(code);
    }

    [Test]
    public void CheckAllTestsAreInPlace()
    {
        var implTypes = ChallengeHelpers.GetIncorrectImplementationTypes();
        var testedImpls = ChallengeHelpers.GetIncorrectImplementationTests()
            .Select(t => t.CreateStatistics())
            .ToArray();

        foreach (var impl in implTypes)
        {
            ClassicAssert.NotNull(testedImpls.SingleOrDefault(t => t.GetType().FullName == impl.FullName),
                "Single implementation of tests for {0} not found. Regenerate tests with test above!", impl.FullName);
        }
    }
}

#region Generated with test above

public class WordsStatisticsC_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsE_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsCR_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsE2_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsE3_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsE4_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsL2_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsL3_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsL4_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsO1_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsO2_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsO3_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsO4_Tests : IncorrectImplementationTestsBase { }
public class WordsStatistics123_Tests : IncorrectImplementationTestsBase { }
public class WordsStatistics998_Tests : IncorrectImplementationTestsBase { }
public class WordsStatistics999_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsEN1_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsEN2_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsQWE_Tests : IncorrectImplementationTestsBase { }
public class WordsStatisticsSTA_Tests : IncorrectImplementationTestsBase { }

#endregion
