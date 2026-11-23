namespace SunamoEntity.Entity;

public partial class SongFromInternet : IEquatable<SongFromInternet>
{
    /// <summary>
    /// Alternate artists.
    /// </summary>
    /// <returns>The alternate artists result.</returns>
    public List<string> AlternateArtists()
    {
        var remixText = Remix();
        remixText = SHReplace.ReplaceAll(remixText, "Ft", "ft", "Feat", "feat");
        remixText = remixText.Trim('.');
        remixText = remixText.Trim();
        var artists = SHSplit.Split(remixText, "&", " and ");
        return artists;
    }

    /// <summary>
    /// Compare.
    /// </summary>
    /// <param name="first">The first.</param>
    /// <param name="second">The second.</param>
    /// <returns>The compare result.</returns>
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

    /// <summary>
    /// Equals.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>The equals result.</returns>
    public override bool Equals(object? obj)
    {
        return Equals((SongFromInternet)obj!);
    }

    /// <summary>
    /// Equals.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>The equals result.</returns>
    public bool Equals(SongFromInternet? other)
    {
        return BTS.IntToBool(Compare(this, other!));
    }

    private readonly StringComparer comparer = StringComparer.OrdinalIgnoreCase;

    /// <summary>
    /// Get hash code.
    /// </summary>
    /// <returns>The get hash code result.</returns>
    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }
}
