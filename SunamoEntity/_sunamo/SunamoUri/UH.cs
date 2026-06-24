namespace SunamoEntity._sunamo.SunamoUri;

internal class UH
{
    internal static string UrlEncode(string text)
    {
        return WebUtility.UrlEncode(text.Trim());
    }
}
