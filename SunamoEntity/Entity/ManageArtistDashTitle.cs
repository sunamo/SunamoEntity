namespace SunamoEntity.Entity;

public class ManageArtistDashTitle
{
    public static void GetArtistTitleRemix(string text, out string artist, out string song, out string remix)
    {
        var result = GetArtistTitleRemix(text);
        artist = result.Item1;
        song = result.Item2;
        remix = result.Item3;
    }

    public static bool ContainsBracket(string text, ref List<char> left, ref List<char> right, bool isMustBeLeftAndRight = false)
    {
        left = SH.ContainsAnyChar(text, false, AllLists.LeftBrackets);
        right = SH.ContainsAnyChar(text, false, AllLists.LeftBrackets);
        if (isMustBeLeftAndRight)
        {
            if (left.Count > 0 && right.Count > 0)
            {
                return true;
            }
        }
        else
        {
            if (left.Count > 0 || right.Count > 0)
            {
                return true;
            }
        }

        return false;
    }

    public static Tuple<string, string, string> GetArtistTitleRemix(string text)
    {
        string artist; string song; string remix;
        string delimiter = SH.WrapWith("-", " ");

        if (!text.Contains(delimiter))
        {
            delimiter = "-";
        }

        List<string> parts = SHSplit.Split(text, delimiter);
        artist = song = "";
        if (parts.Count == 0)
        {
            artist = song = remix = "";
        }
        else if (parts.Count == 1)
        {
            artist = "";
            ExtractTitleRemix(parts[0], out song, out remix);
        }
        else
        {

            artist = parts[0];

            List<char>? left, right;
            left = right = null;

            if (SH.ContainsBracket(artist, ref left!, ref right!))
            {
                if (left.Count - 1 == right.Count)
                {
                    var closingBracket = SH.ClosingBracketFor(left[0]);
                    right.Add(closingBracket);
                    artist += closingBracket;
                }
                if (left.Count > 0 && right.Count > 0)
                {
                    var between = SH.GetTextBetween(artist, left[0], right[0]);
                    between = left[0] + between + right[0];
                    text = text.Replace(between, string.Empty);
                    text += " " + between;
                    parts = SHSplit.Split(text, delimiter);
                    if (parts.Count > 0)
                    {
                        artist = parts[0].Trim();
                    }
                }
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 1; i < parts.Count; i++)
            {
                stringBuilder.Append(parts[i]);
            }

            ExtractTitleRemix(stringBuilder.ToString().TrimEnd('-'), out song, out remix);
        }
        return new Tuple<string, string, string>(artist, song, remix);
    }

    private static void ExtractTitleRemix(string text, out string title, out string remix)
    {
        title = text;
        remix = "";
        int firstSquareBracketIndex = text.IndexOf(']');
        int firstParenthesisIndex = text.IndexOf('(');
        if (firstSquareBracketIndex == -1 && firstParenthesisIndex != -1)
        {
            SplitAtIndexInclusive(text, firstParenthesisIndex, out title, out remix);
        }
        else if (firstSquareBracketIndex != -1 && firstParenthesisIndex == -1)
        {
            SplitAtIndexInclusive(text, firstSquareBracketIndex, out title, out remix);
        }
        else if (firstSquareBracketIndex != -1 && firstParenthesisIndex != -1)
        {
            if (firstSquareBracketIndex < firstParenthesisIndex)
            {
                SplitAtIndexInclusive(text, firstParenthesisIndex, out title, out remix);
            }
            else
            {
                SplitAtIndexInclusive(text, firstSquareBracketIndex, out title, out remix);
            }
        }
    }

    private static void SplitAtIndexInclusive(string text, int splitIndex, out string title, out string remix)
    {
        title = text.Substring(0, splitIndex);
        remix = text.Substring(splitIndex);
    }

    public static string GetArtist(string text)
    {
        GetArtistTitle(text, out var artist, out _);
        return artist;
    }

    public static void GetArtistTitle(string text, out string artist, out string title)
    {
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
        List<string> parts = SHSplit.Split(fileNameWithoutExtension, "-");
        artist = title = "";
        if (parts.Count == 0)
        {
            artist = title = "";
        }
        else if (parts.Count == 1)
        {
            artist = "";
            title = parts[0];
        }
        else
        {
            artist = parts[0];
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 1; i < parts.Count; i++)
            {
                stringBuilder.Append(parts[i] + "-");
            }

            title = stringBuilder.ToString().TrimEnd('-');
        }
    }

    public static string ArtistAndTitleToUpper(string text, string separator)
    {
        char[] characters = text.ToCharArray();
        characters[0] = char.ToUpper(text[0]);
        int separatorIndex = text.IndexOf(separator);
        characters[separatorIndex + 1] = char.ToUpper(characters[separatorIndex + 1]);
        for (int i = 1; i < characters.Length; i++)
        {
            if (characters[i] == ' ')
            {
                if (CA.IsThereAnotherIndex(characters, i))
                {
                    characters[i + 1] = char.ToUpper(characters[i + 1]);
                }
            }
            else if (characters[i] == '-')
            {
                if (CA.IsThereAnotherIndex(characters, i))
                {
                    characters[i + 1] = char.ToUpper(characters[i + 1]);
                }
            }
            else if (characters[i] == ']')
            {
                if (CA.IsThereAnotherIndex(characters, i))
                {
                    characters[i + 1] = char.ToUpper(characters[i + 1]);
                }
            }
            else if (characters[i] == '(')
            {
                if (CA.IsThereAnotherIndex(characters, i))
                {
                    characters[i + 1] = char.ToUpper(characters[i + 1]);
                }
            }
        }

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(characters);
        return stringBuilder.ToString();
    }

    public static string ReplaceAllHyphensExceptTheFirst(string text, string replacement = " ")
    {
        int firstHyphenIndex = text.IndexOf('-');
        text = text.Replace("-", replacement);
        char[] characters = text.ToCharArray();
        characters[firstHyphenIndex] = '-';
        return new string(characters);
    }

    public string GetTitle(string text)
    {
        GetArtistTitle(text, out _, out var title);
        return title;
    }

    public static string Reverse(string text)
    {
        List<string> parts = SHSplit.SplitChar(text, '-');
        string firstPart = parts[0];
        parts[0] = parts[parts.Count - 1];
        parts[parts.Count - 1] = firstPart;
        StringBuilder stringBuilder = new StringBuilder();
        foreach (string item in parts)
        {
            stringBuilder.Append(item + "-");
        }

        return stringBuilder.ToString().TrimEnd('-');
    }
}
