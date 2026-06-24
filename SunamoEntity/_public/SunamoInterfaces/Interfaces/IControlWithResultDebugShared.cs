namespace SunamoEntity._public.SunamoInterfaces.Interfaces;

[ComVisible(true)]
[InterfaceType(ComInterfaceType.InterfaceIsDual)]
public interface IControlWithResultDebugShared : IControlWithResult
{
    int CountOfHandlersChangeDialogResult();

    void AttachChangeDialogResult(Action<bool> handler, bool isThrowingException = true);
}