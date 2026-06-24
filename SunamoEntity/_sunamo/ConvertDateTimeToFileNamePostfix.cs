namespace SunamoEntity._sunamo;

internal class ConvertDateTimeToFileNamePostfix
{
    private static char delimiter = '_';

    internal static string ToConvention(string postfix, DateTime dateTime, bool isIncludingTime)
    {
        return DTHelper.DateTimeToFileName(dateTime, isIncludingTime) + delimiter + postfix;
    }
}