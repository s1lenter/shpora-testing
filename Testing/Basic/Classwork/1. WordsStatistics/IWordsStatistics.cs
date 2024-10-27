namespace Basic.Task.WordsStatistics.WordsStatistics;

public interface IWordsStatistics
{
    public void AddWord(string word);
    public IEnumerable<WordCount> GetStatistics();
}