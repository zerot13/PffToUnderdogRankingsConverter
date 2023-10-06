namespace FantasyRankingsConverter.RankingConverter;

public class RankingConverter
{
    public static List<string> ConvertRankings(List<string> pffRankings, List<string> underdogRankings)
    {
        var finalRankings = new List<string>();
        foreach(string rank in pffRankings)
        {
           finalRankings.Add(MatchRanking(rank, underdogRankings));
        }

        return finalRankings;
    }

    private static string MatchRanking(string pffLine, List<string> underdogRankings)
    {
        var pffSeperate = pffLine.Split(',', StringSplitOptions.TrimEntries);
        var pffName = pffSeperate[1];
        return underdogRankings.First(rank => 
        {
            var rankParts = rank.Split(',');
            var name = rankParts[1].Replace("\"", "") + " " + rankParts[2].Replace("\"", "");
            return name == pffName;
        });
    }
}