using Basic.Task.WordsStatistics.WordsStatistics;
using Basic.Task.WordsStatistics;
using NUnit.Framework;

namespace Basic.Classwork.DoNotOpen;

#region Не подглядывать!

public class IncorrectImplementationAttribute : Attribute {}

[IncorrectImplementation]
public class WordsStatisticsL2 : WordsStatisticsImpl
{
    public override void AddWord(string word)
    {
        if (word == null) throw new ArgumentNullException(nameof(word));
        if (string.IsNullOrWhiteSpace(word)) return;
        int count;
        statistics[word.ToLower()] = 1 + (statistics.TryGetValue(word.ToLower(), out count) ? count : 0);
    }
}

[IncorrectImplementation]
public class WordsStatisticsL3 : WordsStatisticsImpl
{
    public override void AddWord(string word)
    {
        if (word == null) throw new ArgumentNullException(nameof(word));
        if (string.IsNullOrWhiteSpace(word)) return;
        if (word.Length > 10) word = word.Substring(0, 10);
        else if (word.Length > 5) word = word.Substring(0, word.Length - 2);
        int count;
        statistics[word.ToLower()] = 1 + (statistics.TryGetValue(word.ToLower(), out count) ? count : 0);
    }
}

[IncorrectImplementation]
public class WordsStatisticsL4 : WordsStatisticsImpl
{
    public override void AddWord(string word)
    {
        if (word == null) throw new ArgumentNullException(nameof(word));
        if (string.IsNullOrWhiteSpace(word)) return;
        if (word.Length - 1 > 10) word = word.Substring(0, 10);
        int count;
        statistics[word.ToLower()] = 1 + (statistics.TryGetValue(word.ToLower(), out count) ? count : 0);
    }
}

[IncorrectImplementation]
public class WordsStatisticsC : WordsStatisticsImpl
{
    public override void AddWord(string word)
    {
        if (word == null) throw new ArgumentNullException(nameof(word));
        if (string.IsNullOrWhiteSpace(word)) return;
        if (word.Length > 10) word = word.Substring(0, 10);
        if (!statistics.ContainsKey(word.ToLower()))
            statistics[word] = 0;
        statistics[word]++;
    }
}

[IncorrectImplementation]
public class WordsStatisticsE : WordsStatisticsImpl
{
    public override void AddWord(string word)
    {
        if (string.IsNullOrWhiteSpace(word)) throw new ArgumentNullException(nameof(word));
        if (word.Length > 10) word = word.Substring(0, 10);
        int count;
        statistics[word.ToLower()] = 1 + (statistics.TryGetValue(word.ToLower(), out count) ? count : 0);
    }
}

[IncorrectImplementation]
internal class WordsStatisticsE2 : WordsStatisticsImpl
{
    public override void AddWord(string word)
    {
        if (string.IsNullOrWhiteSpace(word)) return;
        if (word.Length > 10) word = word.Substring(0, 10);
        int count;
        statistics[word.ToLower()] = 1 + (statistics.TryGetValue(word.ToLower(), out count) ? count : 0);
    }
}

[IncorrectImplementation]
internal class WordsStatisticsE3 : WordsStatisticsImpl
{
    public override void AddWord(string word)
    {
        if (word == null) throw new ArgumentNullException(nameof(word));
        if (word.Length > 10) word = word.Substring(0, 10);
        if (string.IsNullOrWhiteSpace(word)) return;
        int count;
        statistics[word.ToLower()] = 1 + (statistics.TryGetValue(word.ToLower(), out count) ? count : 0);
    }
}

[IncorrectImplementation]
internal class WordsStatisticsE4 : WordsStatisticsImpl
{
    public override void AddWord(string word)
    {
        if (word.Length == 0 || word.All(char.IsWhiteSpace)) return;
        if (word.Length > 10) word = word.Substring(0, 10);
        int count;
        statistics[word.ToLower()] = 1 + (statistics.TryGetValue(word.ToLower(), out count) ? count : 0);
    }
}

[IncorrectImplementation]
internal class WordsStatisticsO1 : WordsStatisticsImpl
{
    public override IEnumerable<WordCount> GetStatistics()
    {
        return statistics
            .Select(WordCount.Create)
            .OrderBy(wordCount => wordCount.Word);
    }
}

[IncorrectImplementation]
internal class WordsStatisticsO2 : WordsStatisticsImpl
{
    public override IEnumerable<WordCount> GetStatistics()
    {
        return statistics
            .Select(WordCount.Create)
            .OrderBy(wordCount => wordCount.Count);
    }
}

[IncorrectImplementation]
internal class WordsStatisticsO3 : WordsStatisticsImpl
{
    public override IEnumerable<WordCount> GetStatistics()
    {
        return base.GetStatistics().OrderBy(wordCount => wordCount.Word);
    }
}

[IncorrectImplementation]
internal class WordsStatisticsO4 : WordsStatisticsImpl
{
    public override IEnumerable<WordCount> GetStatistics()
    {
        return base.GetStatistics()
            .OrderByDescending(wordCount => wordCount.Count)
            .ThenByDescending(wordCount => wordCount.Word);
    }
}

[IncorrectImplementation]
public class WordsStatisticsCR : IWordsStatistics
{
    private readonly IDictionary<string, int> statistics =
        new Dictionary<string, int>();

    public void AddWord(string word)
    {
        if (word == null) throw new ArgumentNullException(nameof(word));
        if (string.IsNullOrEmpty(word)) return;
        if (word.Length > 10) word = word.Substring(0, 10);
        word = word.ToLower();
        int count;
        statistics[word] = 1 + (statistics.TryGetValue(word, out count) ? count : 0);
    }

    public IEnumerable<WordCount> GetStatistics()
    {
        return statistics
            .Select(WordCount.Create)
            .OrderByDescending(wordCount => wordCount.Count)
            .ThenBy(wordCount => wordCount.Word);
    }
}

[IncorrectImplementation]
internal class WordsStatisticsSTA : IWordsStatistics
{
    private static readonly IDictionary<string, int> statistics = new Dictionary<string, int>();

    public WordsStatisticsSTA()
    {
        statistics.Clear();
    }

    public void AddWord(string word)
    {
        if (word == null) throw new ArgumentNullException(nameof(word));
        if (string.IsNullOrWhiteSpace(word)) return;
        if (word.Length > 10) word = word.Substring(0, 10);
        int count;
        statistics[word.ToLower()] = 1 + (statistics.TryGetValue(word.ToLower(), out count) ? count : 0);
    }

    public IEnumerable<WordCount> GetStatistics()
    {
        return statistics
            .Select(WordCount.Create)
            .OrderByDescending(wordCount => wordCount.Count)
            .ThenBy(wordCount => wordCount.Word);
    }
}

[IncorrectImplementation]
internal class WordsStatistics123 : IWordsStatistics
{
    private const int MAX_SIZE = 1237;

    private readonly int[] statistics = new int[MAX_SIZE];
    private readonly string[] words = new string[MAX_SIZE];

    public void AddWord(string word)
    {
        if (word == null) throw new ArgumentNullException(nameof(word));
        if (string.IsNullOrWhiteSpace(word)) return;
        if (word.Length > 10) word = word.Substring(0, 10);
        var index = Math.Abs(word.ToLower().GetHashCode()) % MAX_SIZE;
        statistics[index]++;
        words[index] = word.ToLower();
    }

    public IEnumerable<WordCount> GetStatistics()
    {
        return statistics.Zip(words, (s, w) => new WordCount(w, s))
            .Where(t => t.Count > 0)
            .OrderByDescending(t => t.Count)
            .ThenBy(t => t.Word);
    }
}

[IncorrectImplementation]
internal class WordsStatisticsQWE : IWordsStatistics
{
    private readonly IDictionary<string, int> statistics = new Dictionary<string, int>();

    public void AddWord(string word)
    {
        if (word == null) throw new ArgumentNullException(nameof(word));
        if (string.IsNullOrWhiteSpace(word)) return;
        if (word.Length > 10) word = word.Substring(0, 10);
        word = ToLower(word);
        int count;
        statistics[word] = 1 + (statistics.TryGetValue(word, out count) ? count : 0);
    }

    public IEnumerable<WordCount> GetStatistics()
    {
        return statistics
            .Select(WordCount.Create)
            .OrderByDescending(wordCount => wordCount.Count)
            .ThenBy(wordCount => wordCount.Word);
    }

    private char ToLower(char c)
    {
        if ("QWERTYUIOPLJKHGFDSAZXCVBNM".Contains(c))
            return (char)(c - 'D' + 'd');
        else if ("ЙЦУКЕНГШЩЗФЫВАПРОЛДЯЧСМИТЬ".Contains(c))
            return (char)(c - 'Я' + 'я');
        return c;
    }

    private string ToLower(string s)
    {
        return new string(s.Select(ToLower).ToArray());
    }
}

[IncorrectImplementation]
internal class WordsStatistics998 : IWordsStatistics
{
    private readonly List<WordCount> statistics = new List<WordCount>();

    public void AddWord(string word)
    {
        if (word == null) throw new ArgumentNullException(nameof(word));
        if (string.IsNullOrWhiteSpace(word)) return;
        if (word.Length > 10) word = word.Substring(0, 10);
        var lowerCaseWord = word.ToLower();
        var wordCount = statistics.FirstOrDefault(s => s.Word == lowerCaseWord);
        if (wordCount.Word != null)
            statistics.Remove(wordCount);
        else
            wordCount = new WordCount(lowerCaseWord, 0);
        statistics.Add(new WordCount(wordCount.Word, wordCount.Count - 1));

        statistics.Sort((a, b) => a.Count == b.Count
            ? string.Compare(a.Word, b.Word, StringComparison.Ordinal)
            : a.Count - b.Count);
    }

    public IEnumerable<WordCount> GetStatistics()
    {
        return statistics.Select(w => new WordCount(w.Word, -w.Count));
    }
}

[IncorrectImplementation]
internal class WordsStatistics999 : IWordsStatistics
{
    private readonly HashSet<string> usedWords = new HashSet<string>();
    private readonly List<WordCount> statistics = new List<WordCount>();

    public void AddWord(string word)
    {
        if (word == null) throw new ArgumentNullException(nameof(word));
        if (string.IsNullOrWhiteSpace(word)) return;
        if (word.Length > 10) word = word.Substring(0, 10);
        word = word.ToLower();
        if (usedWords.Contains(word))
        {
            var stat = statistics.First(s => s.Word == word);
            statistics.Remove(stat);
            statistics.Add(new WordCount(stat.Word, stat.Count + 1));
        }
        else
        {
            statistics.Add(new WordCount(word, 1));
            usedWords.Add(word);
        }
    }

    public IEnumerable<WordCount> GetStatistics()
    {
        return statistics
            .OrderByDescending(t => t.Count)
            .ThenBy(t => t.Word);
    }
}

[IncorrectImplementation]
internal class WordsStatisticsEN1 : WordsStatisticsImpl
{
    private IDictionary<string, int> statistics
        = new Dictionary<string, int>();

    public void AddWord(string word)
    {
        if (word == null) throw new ArgumentNullException(nameof(word));
        if (string.IsNullOrWhiteSpace(word)) return;
        if (word.Length > 10)
            word = word.Substring(0, 10);
        int count;
        statistics[word.ToLower()] = 1 + (statistics.TryGetValue(word.ToLower(), out count) ? count : 0);
    }

    public IEnumerable<WordCount> GetStatistics()
    {
        var temp = statistics;
        statistics = new Dictionary<string, int>();
        return temp
            .Select(WordCount.Create)
            .OrderByDescending(wordCount => wordCount.Count)
            .ThenBy(wordCount => wordCount.Word);
    }
}

[IncorrectImplementation]
internal class WordsStatisticsEN2 : WordsStatisticsImpl
{
    private List<WordCount> result;

    public override IEnumerable<WordCount> GetStatistics()
    {
        return result ??= base.GetStatistics().ToList();
    }
}

public abstract class IncorrectImplementationTestsBase : WordsStatisticsTests
{
    public override IWordsStatistics CreateStatistics()
    {
        string ns = typeof(WordsStatisticsC).Namespace;
        var implTypeName = ns + "." + GetType().Name.Replace("_Tests", "");
        var implType = GetType().Assembly.GetType(implTypeName);
        if (implType == null)
            Assert.Fail($"no type {implTypeName}");
        return Activator.CreateInstance(implType) as IWordsStatistics;
    }
}

#endregion