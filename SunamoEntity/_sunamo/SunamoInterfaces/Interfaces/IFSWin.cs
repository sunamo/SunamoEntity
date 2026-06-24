namespace SunamoEntity._sunamo.SunamoInterfaces.Interfaces;


internal interface IFSWin
{
    void DeleteFileMaybeLocked(string filePath);

    void DeleteFileOrFolderMaybeLocked(string path);
}
