namespace SunamoEntity.Entity;

/// <summary>
/// Represents the timestamp type.
/// </summary>
public class Timestamp
{
    /// <summary>
    /// Get all time stamps.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The get all time stamps result.</returns>
    public static List<string> GetAllTimeStamps(string text)
    {
        List<string> result = new List<string>();
        var words = SHSplit.SplitChar(text, ' ', '.');
        foreach (var item in words)
        {
            if (item.Length == 9)
            {
                var firstChar = item[0];
                var secondChar = item[1];
                var thirdChar = item[2];
                var fifthChar = item[4];
                var sixthChar = item[5];
                var eighthChar = item[7];
                var ninthChar = item[8];
                if (firstChar == 'T' && char.IsDigit(secondChar) && char.IsDigit(thirdChar) && char.IsDigit(fifthChar) && char.IsDigit(sixthChar) && char.IsDigit(eighthChar) && char.IsDigit(ninthChar))
                {
                    result.Add(item);
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Make up to 2 numbers to zero.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <returns>The make up to 2 numbers to zero result.</returns>
    public static object MakeUpTo2NumbersToZero(int number)
    {
        if (number.ToString().Length == 1)
        {
            return "0" + number;
        }
        return number;
    }
}
