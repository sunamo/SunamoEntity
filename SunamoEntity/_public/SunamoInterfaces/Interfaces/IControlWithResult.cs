namespace SunamoEntity._public.SunamoInterfaces.Interfaces;

/// <summary>
/// Represents the i control with result type.
/// </summary>
[ComVisible(true)]
[InterfaceType(ComInterfaceType.InterfaceIsDual)]
public interface IControlWithResult
{
    /// <summary>
    /// The change dialog result.
    /// </summary>
    event Action<bool?> ChangeDialogResult;

    /// <summary>
    /// Gets or sets the dialog result.
    /// </summary>
    bool? DialogResult { set; }

    /// <summary>
    /// Accept.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The accept result.</returns>
    void Accept(object value);

    /// <summary>
    /// Focus on main element.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The focus on main element result.</returns>
    void FocusOnMainElement();
}