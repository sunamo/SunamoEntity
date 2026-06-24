namespace SunamoEntity._sunamo.SunamoCollections;

internal class CA
{
    internal static List<string> TrimStart(string prefix, List<string> list)
    {
        ThrowEx.IsNull("prefix", prefix);
        ThrowEx.IsNull("list", list);

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].StartsWith(prefix))
            {
                list[i] = list[i].Substring(prefix.Length);
            }
        }
        return list;
    }

    internal static List<string> Trim(List<string> list)
    {
        for (var i = 0; i < list.Count; i++) list[i] = list[i].Trim();

        return list;
    }

    internal static string ReplaceAll(string text, List<string> what, string replacement)
    {
        foreach (var item in what)
        {
            text = text.Replace(item, replacement);
        }

        return text;
    }

    internal static List<string> WithoutDiacritic(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].RemoveDiacritics();
        }
        return list;
    }

    internal static List<string> RemoveStringsEmpty(List<string> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] == string.Empty)
            {
                list.RemoveAt(i);
            }
        }
        return list;
    }

    internal static bool IsThereAnotherIndex(char[] array, int index)
    {
        if (array.Length >= index)
        {
            return true;
        }
        return false;
    }

    internal static bool IsSomethingTheSame(string text, IList<string> list, ref string contained)
    {
        foreach (var item in list)
        {
            if (item == text)
            {
                contained = item;
                return true;
            }
        }
        return false;
    }

    internal static List<byte> JoinBytesArray(byte[] firstArray, byte[] secondArray)
    {
        var result = new List<byte>(firstArray.Length + secondArray.Length);
        result.AddRange(firstArray);
        result.AddRange(secondArray);
        return result;
    }
}
