namespace SunamoEntity._sunamo.SunamoBts;

internal class BTS
{
    internal static bool IntToBool(int value) => Convert.ToBoolean(value);

    internal static int ParseInt(string text, int defaultValue)
    {
        text = text.Replace(" ", string.Empty);

        if (int.TryParse(text, out var parsedValue))
        {
            return parsedValue;
        }
        return defaultValue;
    }
}
