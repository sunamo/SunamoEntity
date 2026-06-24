namespace SunamoEntity._sunamo.SunamoInterfaces.Interfaces.SunamoPS;

internal interface IPowershellHelper
{
    Task
    CmdC(string command);

    Task<string>
    DetectLanguageForFileGithubLinguist(string windowsPath);

    List<string> ProcessNames();
}
