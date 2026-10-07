namespace SunamoEntity._sunamo.SunamoCollections;

internal class CA
{
    internal static List<string> TrimStart(string prefix, List<string> list)
    {
        ThrowEx.IsNull("prefix", prefix);
        ThrowEx.IsNull("list", list);

        for (int index = 0; index < list.Count; index++)
        {
            if (list[index].StartsWith(prefix))
            {
                list[index] = list[index].Substring(prefix.Length);
            }
        }
        return list;
    }

    internal static List<string> Trim(List<string> list)
    {
        for (var index = 0; index < list.Count; index++) list[index] = list[index].Trim();

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
        for (int index = 0; index < list.Count; index++)
        {
            list[index] = list[index].RemoveDiacritics();
        }
        return list;
    }

    internal static List<string> RemoveStringsEmpty(List<string> list)
    {
        for (int index = list.Count - 1; index >= 0; index--)
        {
            if (list[index] == string.Empty)
            {
                list.RemoveAt(index);
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
