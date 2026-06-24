namespace SunamoEntity._sunamo.SunamoArgs;

internal class GetFilesMoreMascArgs : GetFilesBaseArgsShared
{
    internal bool IsLoadFromFileWhenDebug { get; set; } = false;
    internal string Path { get; set; } = null!;
    internal string Mask { get; set; } = "*";
    internal SearchOption FileSearchOption { get; set; } = SearchOption.TopDirectoryOnly;
    internal bool IsDeleteFromDriveWhenCannotBeResolved { get; set; } = false;
}
