namespace SunamoEntity.Entity;

public partial class SongFromInternet : IEquatable<SongFromInternet>
{
    public List<string> AlternateArtists()
    {
        var remixText = Remix();
        remixText = SHReplace.ReplaceAll(remixText, "Ft", "ft", Translate.FromKey(XlfKeys.Feat), "feat");
        remixText = remixText.Trim('.');
        remixText = remixText.Trim();
        var artists = SHSplit.Split(remixText, "&", " and ");
        return artists;
    }

    public int Compare(object first, object second)
    {
        var firstSong = (SongFromInternet)first;
        var secondSong = (SongFromInternet)second;
        const float min = 0.5f;
        var similarity = secondSong.CalculateSimilarityAll(firstSong, false, min);
        if (min <= similarity)
        {
            return 1;
        }

        return 0;
    }

    public override bool Equals(object? obj)
    {
        return Equals((SongFromInternet)obj!);
    }

    public bool Equals(SongFromInternet? other)
    {
        return BTS.IntToBool(Compare(this, other!));
    }

    private readonly StringComparer comparer = StringComparer.OrdinalIgnoreCase;

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }
}
