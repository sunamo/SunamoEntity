namespace SunamoEntity._sunamo.SunamoFileSystem;

internal class FS
{
    internal static List<char> InvalidFileNameChars = Path.GetInvalidFileNameChars().ToList();

#pragma warning disable CS0649
    internal static Action<string>? DeleteFileMaybeLocked;
#pragma warning restore CS0649

    internal static string DeleteWrongCharsInFileName(string filenameOrPath, bool isPath)
    {
        var invalidChars = isPath
            ? Path.GetInvalidPathChars().ToList()
            : Path.GetInvalidFileNameChars().ToList();

        var stringBuilder = new StringBuilder();
        foreach (char item in filenameOrPath)
        {
            if (!invalidChars.Contains(item))
            {
                stringBuilder.Append(item);
            }
        }

        var result = stringBuilder.ToString();
        SH.FirstCharUpper(ref result);
        return result;
    }

    internal static bool TryDeleteFile(string filePath)
    {
        try
        {
            File.Delete(filePath);
            return true;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Failed to delete file {filePath}: {exception.Message}");
            return false;
        }
    }
}
