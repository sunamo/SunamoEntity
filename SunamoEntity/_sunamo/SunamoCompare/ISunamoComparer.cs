namespace SunamoEntity._sunamo.SunamoCompare;

internal interface ISunamoComparer<T>
{
    int Desc(T first, T second);
    int Asc(T first, T second);
}
