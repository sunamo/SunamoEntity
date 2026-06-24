namespace SunamoEntity._public.SunamoData.Data;

public class FileForSearching
{
    public bool IsSurelyNo { get; set; } = false;

    public List<int> FoundedLines { get; set; } = new List<int>();

    public List<string> LinesLower { get; set; } = null!;

    public List<string> Lines { get; set; } = null!;

    private string path;

    public FileForSearching(string path)
    {
        this.path = path;
    }

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
