namespace SunamoEntity._public.SunamoInterfaces.Interfaces;

/// <summary>
/// Represents the i control with result debug shared type.
/// </summary>
[ComVisible(true)]
[InterfaceType(ComInterfaceType.InterfaceIsDual)]
public interface IControlWithResultDebugShared : IControlWithResult
{
    /// <summary>
    /// Count of handlers change dialog result.
    /// </summary>
    /// <returns>The count of handlers change dialog result result.</returns>
    int CountOfHandlersChangeDialogResult();

    /// <summary>
    /// Attach change dialog result.
    /// </summary>
    /// <param name="handler">The handler.</param>
    /// <param name="isThrowingException">The is throwing exception.</param>
    void AttachChangeDialogResult(Action<bool> handler, bool isThrowingException = true);
}