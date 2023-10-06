internal class Program
{
    private static void Main(string[] args)
    {
        var pffRankingsLines = File.ReadAllLines("pffRankings.csv");
        var pffRankings = pffRankingsLines.Skip(1).ToList();
        var underdogRankingsLines = File.ReadAllLines("underdogRankings.csv");
        var underdogRankings = underdogRankingsLines.Skip(1).ToList();
        var finalRankings = new List<string>();
        finalRankings.Add(underdogRankingsLines[0]);
        finalRankings.AddRange(FantasyRankingsConverter.RankingConverter.RankingConverter.ConvertRankings(pffRankings, underdogRankings));
        File.WriteAllLines("FinalRankings.csv", finalRankings);
        Console.WriteLine(finalRankings.Count);
        Console.WriteLine("Done");
    }
}