namespace SunamoEntity._sunamo.SunamoRandom;

internal class RandomHelper
{
    private static Random random = new Random(Guid.NewGuid().GetHashCode());

    internal static byte[] RandomBytes(int count)
    {
        byte[] bytes = new byte[count];
        for (int index = 0; index < count; index++)
        {
            bytes[index] = (byte)random.Next(0, byte.MaxValue);
        }
        return bytes;
    }
}
