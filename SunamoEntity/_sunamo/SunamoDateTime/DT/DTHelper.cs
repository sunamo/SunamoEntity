namespace SunamoEntity._sunamo.SunamoDateTime.DT;

internal class DTHelper
{
    internal static string DateTimeToFileName(DateTime dateTime, bool isIncludingTime)
    {
        string dateDelimiter = "_";
        string spaceDelimiter = "_";
        string timeDelimiter = "_";
        string result = dateTime.Year + dateDelimiter + dateTime.Month.ToString("D2") + dateDelimiter + dateTime.Day.ToString("D2");
        if (isIncludingTime)
        {
            result += spaceDelimiter + dateTime.Hour.ToString("D2") + timeDelimiter + dateTime.Minute.ToString("D2");
        }
        return result;
    }

    internal static string DateToString(DateTime dateTime, LangsShared lang) => DTHelperMulti.DateToString(dateTime, lang);

    internal static string DateTimeToString(DateTime dateTime, LangsShared lang, DateTime minDateTime)
    {
        if (dateTime == minDateTime)
        {
            if (lang == LangsShared.cs)
            {
                return "ItWasNotMentioned";
            }
            else
            {
                return "NotIndicated";
            }
        }

        if (lang == LangsShared.cs)
        {
            return dateTime.Day + "." + dateTime.Month + "." + dateTime.Year + " " + dateTime.Hour.ToString("D2") + ":" + dateTime.Minute.ToString("D2");
        }
        else
        {
            return dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year + " " + dateTime.Hour.ToString("D2") + ":" + dateTime.Minute.ToString("D2");
        }
    }
}
