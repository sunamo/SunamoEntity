namespace SunamoEntity._public.SunamoInterfaces.Interfaces;

public interface IPercentCalculator
{
    double OverallSum { get; set; }

    double Last { get; set; }

    IPercentCalculator Create(double overallSum);

    void AddOnePercent();

    int PercentFor(double value, bool isLast);

    void ResetComputedSum();
}