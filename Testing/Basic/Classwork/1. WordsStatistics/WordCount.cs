namespace Basic.Task.WordsStatistics.WordsStatistics;

public struct WordCount(string word, int count)
{
    public string Word { get; set; } = word;
    public int Count { get; set; } = count;

    public static WordCount Create(KeyValuePair<string, int> pair)
    {
        return new WordCount(pair.Key, pair.Value);
    }
}