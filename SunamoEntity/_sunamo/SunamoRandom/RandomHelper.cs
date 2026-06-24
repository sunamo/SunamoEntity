namespace SunamoEntity._sunamo.SunamoRandom;

internal class RandomHelper
{
    private static Random random = new Random(Guid.NewGuid().GetHashCode());

    internal static byte[] RandomBytes(int count)
    {
        byte[] bytes = new byte[count];
        for (int i = 0; i < count; i++)
        {
            bytes[i] = (byte)random.Next(0, byte.MaxValue);
        }
        return bytes;
    }
}
