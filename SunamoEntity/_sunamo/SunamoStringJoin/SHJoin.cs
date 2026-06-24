namespace SunamoEntity._sunamo.SunamoStringJoin;

internal class SHJoin
{
    internal static string JoinFromIndex(int startIndex, object delimiter, IList parts)
    {
        string delimiterText = delimiter.ToString()!;
        var stringBuilder = new StringBuilder();
        int index = 0;
        foreach (var item in parts)
        {
            if (index >= startIndex)
            {
                stringBuilder.Append(item + delimiterText);
            }
            index++;
        }
        string result = stringBuilder.ToString();
        return result.Substring(0, result.Length - 1);
    }
}
