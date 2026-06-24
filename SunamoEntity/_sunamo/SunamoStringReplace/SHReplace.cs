namespace SunamoEntity._sunamo.SunamoStringReplace;

internal class SHReplace
{
    internal static string ReplaceOnce(string text, string what, string replacement)
    {
        return new Regex(what).Replace(text, replacement, 1);
    }

    internal static string ReplaceAll(string text, string replacement, params string[] what)
    {
        foreach (var item in what)
        {
            if (string.IsNullOrEmpty(item))
            {
                return text;
            }
        }

        foreach (var item in what)
        {
            text = text.Replace(item, replacement);
        }
        return text;
    }
}
