namespace SunamoEntity.Entity;

public partial class SongFromInternet : IEquatable<SongFromInternet>
{
    public static float CalculateSimilarity(int sameCount, int differentCount, List<string> newWords, List<string> originalWords)
    {
        if (sameCount == differentCount && sameCount == 0)
        {
            return 1.0f;
        }

        if (sameCount > differentCount)
        {
            if (differentCount == 0)
            {
                int matchCount = 0;
                for (int i = 0; i < newWords.Count; i++)
                {
                    if (originalWords.Contains(newWords[i]))
                    {
                        matchCount++;
                    }
                }

                if (matchCount == newWords.Count)
                {
                    return 1.0f;
                }

                return 1f / 3f * 2f;
            }

            if (differentCount != 0)
            {
                if (differentCount != 1)
                {
                    return sameCount / differentCount;
                }

                if (sameCount > 3)
                {
                    float similarity = (sameCount - differentCount) / 2f;
                    while (similarity > 1f)
                    {
                        similarity /= 2f;
                    }

                    return similarity;
                }
                else
                {
                    float similarity = (sameCount - sameCount / (sameCount - 1f)) / 2;
                    int matchCount = 0;
                    for (int i = 0; i < newWords.Count; i++)
                    {
                        if (originalWords.Contains(newWords[i]))
                        {
                            matchCount++;
                        }
                    }

                    if (matchCount > 0)
                    {
                        similarity = matchCount / (float)differentCount / 2f;
                    }

                    if (similarity > 0.99f)
                    {
                        similarity = similarity / 2f;
                    }

                    return similarity;
                }
            }

            return 0f;
        }

        if (sameCount + 1 > differentCount && sameCount < 3)
        {
            return 0.5f;
        }

        return 0f;
    }

    public float CalculateSimilarityAll(SongFromInternet other, bool isWithoutDiacritic, float minimal)
    {
        var result = CalculateSimilarity(other, isWithoutDiacritic);
        float alternateResult = 0;
        bool shouldContinue = true;
        if (minimal <= result)
        {
            shouldContinue = false;
        }

        List<string>? feats = null;
        if (shouldContinue)
        {
            var song = other.TitleC;
            feats = other.AlternateArtists();
            foreach (var item in feats)
            {
                other = new SongFromInternet(item + "-" + song);
                alternateResult = CalculateSimilarity(other, true);
                if (IsBreakInCalculateSimilarity)
                {
                    System.Diagnostics.Debugger.Break();
                }

                if (alternateResult > result)
                {
                    result = alternateResult;
                }

                if (minimal <= result)
                {
                    break;
                }
            }
        }

        if (IsBreakInCalculateSimilarity)
        {
            System.Diagnostics.Debugger.Break();
        }

        return result;
    }

    public static bool IsBreakInCalculateSimilarity { get; set; } = false;

    public string Artist()
    {
        return string.Join(" ", artistWords);
    }

    public string ArtistInConvention()
    {
        return ConvertEveryWordLargeCharConvention.ToConvention(Artist());
    }

    public string Title()
    {
        return string.Join(" ", titleWords);
    }

    public string TitleInConvention()
    {
        return ConvertEveryWordLargeCharConvention.ToConvention(Title());
    }

    public string Remix()
    {
        return string.Join(" ", remixWords);
    }

    public string RemixInConvention()
    {
        return ConvertEveryWordLargeCharConvention.ToConvention(Remix());
    }

    public string TitleAndRemixInConvention()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(TitleInConvention());
        if (remixWords.Count != 0)
        {
            stringBuilder.Append("[" + RemixInConvention() + "]");
        }

        return stringBuilder.ToString();
    }

    public static void CountSameAndDifferent(List<string> firstList, List<string> secondList, out int sameCount, out int differentCount)
    {
        List<string> firstCopy = new List<string>(firstList.ToArray());
        List<string> secondCopy = new List<string>(secondList.ToArray());
        sameCount = 0;
        for (int i = firstCopy.Count - 1; i >= 0; i--)
        {
            int foundIndex = secondCopy.IndexOf(firstCopy[i]);
            if (foundIndex != -1)
            {
                firstCopy.RemoveAt(i);
                secondCopy.RemoveAt(foundIndex);
                sameCount++;
            }
        }

        differentCount = firstCopy.Count + secondCopy.Count;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(Artist() + "-" + Title());
        if (remixWords.Count != 0)
        {
            stringBuilder.Append(" [" + Remix() + "]");
        }

        return stringBuilder.ToString();
    }

    public string ToConventionString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(ArtistInConvention() + "-" + TitleInConvention());
        if (remixWords.Count != 0)
        {
            stringBuilder.Append(" [" + RemixInConvention() + "]");
        }

        return stringBuilder.ToString();
    }

    private IList<string> SplitRemix(string text)
    {
        List<string> words = SHSplit.Split(text, "&", " ", ",", "-", "[", "]", "(", ")");
        for (int i = 0; i < words.Count; i++)
        {
            words[i] = words[i].ToLower();
        }

        return words;
    }

    private IList<string> SplitArtistTitle(string text)
    {
        List<string> words = SHSplit.Split(text, "&", " ", ",", "-");
        for (int i = 0; i < words.Count; i++)
        {
            words[i] = words[i].ToLower();
        }

        return words;
    }
}
