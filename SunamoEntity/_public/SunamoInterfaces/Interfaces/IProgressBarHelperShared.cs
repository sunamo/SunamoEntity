namespace SunamoEntity._public.SunamoInterfaces.Interfaces;

public interface IProgressBarHelperShared
{
    void Done();

    void DonePartially();

    IProgressBarHelperShared CreateInstance(object progressBar, double overall, object dispatcher);
}