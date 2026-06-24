namespace SunamoEntity.Entity;

public partial class SongFromInternet : IEquatable<SongFromInternet>
{
    private List<string> artistWords = new List<string>();
    private List<string> titleWords = new List<string>();
    private List<string> remixWords = new List<string>();
    private List<string> artistWordsWithoutDiacritic = new List<string>();
    private List<string> titleWordsWithoutDiacritic = new List<string>();
    private List<string> remixWordsWithoutDiacritic = new List<string>();

    public string? YtCode { get; set; } = null;

    public int IdInDb { get; set; } = int.MaxValue;

    private string? artistConvention = null;
    private string? titleConvention = null;
    private string? remixConvention = null;

    public string ArtistC
    {
        get => artistConvention!;
        set => artistConvention = value;
    }

    public string TitleC
    {
        get => titleConvention!;
        set => titleConvention = value;
    }

    public string RemixC
    {
        get => remixConvention!;
        set => remixConvention = value;
    }

    public void SetArtist(string text)
    {
        artistWords.Clear();
        artistWordsWithoutDiacritic.Clear();
        artistWords.AddRange(SplitArtistTitle(text));
        artistWordsWithoutDiacritic = CA.WithoutDiacritic(artistWords);
        artistConvention = ArtistInConvention();
    }

    public SongFromInternet()
    {
    }

    public SongFromInternet(string song, string? ytCode = null)
    {
        ManageArtistDashTitle.GetArtistTitleRemix(song, out var artist, out var title, out var remix);
        Init(artist, title, remix);
        YtCode = ytCode;
    }

    public SongFromInternet(SongFromInternet other)
    {
        artistWords = new List<string>(other.artistWords);
        titleWords = new List<string>(other.titleWords);
        remixWords = new List<string>(other.remixWords);
        SetInConvention();
    }

    public SongFromInternet Init(Tuple<string, string, string> tuple)
    {
        return Init(tuple.Item1, tuple.Item2, tuple.Item3);
    }

    public SongFromInternet Init(string artist, string title, string remix)
    {
        SetArtist(artist);
        var splittedTitle = SplitArtistTitle(title);
        var splittedRemix = SplitRemix(remix);
        titleWords.AddRange(splittedTitle);
        remixWords.AddRange(splittedRemix);
        titleWordsWithoutDiacritic = CA.WithoutDiacritic(new List<string>(titleWords));
        remixWordsWithoutDiacritic = CA.WithoutDiacritic(new List<string>(remixWords));
        SetInConvention();
        return this;
    }

    public static bool IsSimilar(string[] titleArray, string name)
    {
        return IsSimilar(new List<string>(titleArray), name);
    }

    public static bool IsSimilar(List<string> titleArray, string name)
    {
        var nameArray = SHSplit.Split(name, " ", ",", "-", "&", ".", ";", "(", ")", "[", "]");
        CountSameAndDifferent(titleArray, nameArray, out var sameCount, out var differentCount);
        if (CalculateSimilarity(sameCount, differentCount, titleArray, new List<string>(nameArray)) > 0.49f)
        {
            return true;
        }

        return false;
    }

    private void SetInConvention()
    {
        artistConvention = ArtistInConvention();
        titleConvention = TitleInConvention();
        remixConvention = RemixInConvention();
    }

    public string RemixOnlyContent()
    {
        var result = Remix();
        result = CA.ReplaceAll(result, AllLists.FeatLower, string.Empty);
        result = CA.ReplaceAll(result, AllLists.FeatUpper, string.Empty);
        return result;
    }

    public float CalculateSimilarity(string text)
    {
        SongFromInternet other = new SongFromInternet(text);
        return CalculateSimilarity(other, false);
    }

    public float CalculateSimilarity(SongFromInternet other, bool isWithoutDiacritic)
    {
        float artistSimilarity, titleSimilarity, remixSimilarity;
        if (isWithoutDiacritic)
        {
            CountSameAndDifferent(other.artistWordsWithoutDiacritic, artistWordsWithoutDiacritic, out var sameArtist, out var diffArtist);
            CountSameAndDifferent(other.titleWordsWithoutDiacritic, titleWordsWithoutDiacritic, out var sameTitle, out var diffTitle);
            CountSameAndDifferent(other.remixWordsWithoutDiacritic, remixWordsWithoutDiacritic, out var sameRemix, out var diffRemix);
            artistSimilarity = CalculateSimilarity(sameArtist, diffArtist, other.artistWords, artistWordsWithoutDiacritic);
            titleSimilarity = CalculateSimilarity(sameTitle, diffTitle, other.titleWords, titleWordsWithoutDiacritic);
            remixSimilarity = CalculateSimilarity(sameRemix, diffRemix, other.remixWords, remixWordsWithoutDiacritic);
        }
        else
        {
            CountSameAndDifferent(other.artistWords, artistWords, out var sameArtist, out var diffArtist);
            CountSameAndDifferent(other.titleWords, titleWords, out var sameTitle, out var diffTitle);
            CountSameAndDifferent(other.remixWords, remixWords, out var sameRemix, out var diffRemix);
            artistSimilarity = CalculateSimilarity(sameArtist, diffArtist, other.artistWords, artistWords);
            titleSimilarity = CalculateSimilarity(sameTitle, diffTitle, other.titleWords, titleWords);
            remixSimilarity = CalculateSimilarity(sameRemix, diffRemix, other.remixWords, remixWords);
        }

        float result = (artistSimilarity + titleSimilarity) / 2;
        if (result == 1)
        {
            result = (artistSimilarity + titleSimilarity + remixSimilarity) / 3;
        }

        return result;
    }
}
