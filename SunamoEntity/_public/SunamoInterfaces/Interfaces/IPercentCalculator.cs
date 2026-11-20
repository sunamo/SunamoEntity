namespace SunamoEntity._public.SunamoInterfaces.Interfaces;

/// <summary>
/// Represents the i percent calculator type.
/// </summary>
public interface IPercentCalculator
{
    /// <summary>
    /// Gets or sets the overall sum.
    /// </summary>
    double OverallSum { get; set; }

    /// <summary>
    /// Gets or sets the last.
    /// </summary>
    double Last { get; set; }

    /// <summary>
    /// Create.
    /// </summary>
    /// <param name="overallSum">The overall sum.</param>
    /// <returns>The create result.</returns>
    IPercentCalculator Create(double overallSum);

    /// <summary>
    /// Add one percent.
    /// </summary>
    /// <param name="overallSum">The overall sum.</param>
    /// <returns>The add one percent result.</returns>
    void AddOnePercent();

    /// <summary>
    /// Percent for.
    /// </summary>
    /// <param name="overallSum">The overall sum.</param>
    /// <returns>The percent for result.</returns>
    int PercentFor(double value, bool isLast);

    /// <summary>
    /// Reset computed sum.
    /// </summary>
    /// <param name="overallSum">The overall sum.</param>
    /// <returns>The reset computed sum result.</returns>
    void ResetComputedSum();
}