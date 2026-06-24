namespace SunamoEntity._sunamo.SunamoInterfaces.Interfaces;


internal interface IDW
{
    string SelectOfFolder(string rootFolder);

    string SelectOfFolder(Environment.SpecialFolder rootFolder);
}
