namespace SunamoEntity._public.SunamoData.Data;

/// <summary>
/// Represents the file for searching type.
/// </summary>
public class FileForSearching
{
    /// <summary>
    /// Gets or sets the is surely no.
    /// </summary>
    public bool IsSurelyNo { get; set; } = false;

    /// <summary>
    /// Gets or sets the founded lines.
    /// </summary>
    public List<int> FoundedLines { get; set; } = new List<int>();

    /// <summary>
    /// Gets or sets the lines lower.
    /// </summary>
    public List<string> LinesLower { get; set; } = null!;

    /// <summary>
    /// Gets or sets the lines.
    /// </summary>
    public List<string> Lines { get; set; } = null!;

    private string path;

    /// <summary>
    /// Initializes a new instance of the file for searching class.
    /// </summary>
    /// <param name="path">The path.</param>
    public FileForSearching(string path)
    {
        this.path = path;
    }

    /// <summary>
    /// Init.
    /// </summary>
    public
    async Task
        Init()
    {
        Lines = (
            await FileAsync.ReadAllLinesAsync(path)
            ).ToList();
        LinesLower = new List<string>(Lines.Count);
        foreach (var item in Lines)
        {
            LinesLower.Add(item.ToLower());
        }
    }
}
