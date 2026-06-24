namespace SunamoEntity._sunamo.SunamoDateTime.DT;

internal class DTHelperMulti
{
    internal static string DateToString(DateTime dateTime, LangsShared lang)
    {
        if (lang == LangsShared.cs)
        {
            return dateTime.Day + "." + dateTime.Month + "." + dateTime.Year;
        }
        return dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year;
    }
}
