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
        var pffName = CleanName(pffSeperate[1]);
        return underdogRankings.First(rank => 
        {
            var rankParts = rank.Split(',');
            var name = rankParts[1].Replace("\"", "") + " " + rankParts[2].Replace("\"", "");
            return name == pffName;
        });
    }

    private static string CleanName(string originalName)
    {
        var cleanedName = CleanSpecialCases(originalName);
        if(cleanedName != String.Empty)
        {
            return cleanedName;
        }
        return originalName.Replace(" Jr.", "").Replace(" Sr.", "").Replace(" III", "").Replace(" II", "");
    }

    private static string CleanSpecialCases(string originalName)
    {
        return originalName switch
        {
            "D.K. Metcalf" => "DK Metcalf",
            "De'Von Achane" => "Devon Achane",
            "Tank Dell" => "Nathaniel Dell",
            "D'Wayne Eskridge" => "Dee Eskridge",
            _ => String.Empty,
        };
    }
}