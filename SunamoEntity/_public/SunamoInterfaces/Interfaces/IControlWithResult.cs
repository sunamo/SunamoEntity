namespace SunamoEntity._public.SunamoInterfaces.Interfaces;

[ComVisible(true)]
[InterfaceType(ComInterfaceType.InterfaceIsDual)]
public interface IControlWithResult
{
    event Action<bool?> ChangeDialogResult;

    bool? DialogResult { set; }

    void Accept(object value);

    void FocusOnMainElement();
}