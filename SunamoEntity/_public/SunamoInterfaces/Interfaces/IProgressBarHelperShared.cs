namespace SunamoEntity._public.SunamoInterfaces.Interfaces;

/// <summary>
/// Represents the i progress bar helper shared type.
/// </summary>
public interface IProgressBarHelperShared
{
    /// <summary>
    /// Done.
    /// </summary>
    void Done();

    /// <summary>
    /// Done partially.
    /// </summary>
    void DonePartially();

    /// <summary>
    /// Create instance.
    /// </summary>
    /// <param name="progressBar">The progress bar.</param>
    /// <param name="overall">The overall.</param>
    /// <param name="dispatcher">The dispatcher.</param>
    /// <returns>The create instance result.</returns>
    IProgressBarHelperShared CreateInstance(object progressBar, double overall, object dispatcher);
}