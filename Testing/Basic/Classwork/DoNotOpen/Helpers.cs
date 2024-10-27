using Basic.Task.WordsStatistics.WordsStatistics;
using System.Reflection;

namespace Basic.Classwork.DoNotOpen;

public static class ChallengeHelpers
{
    public static Type[] GetIncorrectImplementationTypes()
    {
        return GetInheritorsOf<IWordsStatistics>()
            .Where(t => t.HasAttribute<IncorrectImplementationAttribute>())
            .OrderBy(t => t.Name.Length).ThenBy(t => t.Name)
            .ToArray();
    }

    public static IncorrectImplementationTestsBase[] GetIncorrectImplementationTests()
    {
        return GetInheritorsOf<IncorrectImplementationTestsBase>()
            .Select(Activator.CreateInstance)
            .Cast<IncorrectImplementationTestsBase>()
            .ToArray();
    }

    public static bool HasAttribute<TAttribute>(this Type method) where TAttribute : Attribute
    {
        return method.GetCustomAttributes(typeof(TAttribute), true).Any();
    }

    public static Type[] GetInheritorsOf<T>()
    {
        var baseType = typeof(T);
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(baseType.IsAssignableFrom)
            .Where(t => t != baseType && !t.IsAbstract && !t.IsInterface)
            .ToArray();
    }
}