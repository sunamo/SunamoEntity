namespace SunamoEntity.Entity;

/// <summary>
/// Represents the complex info string type.
/// </summary>
public class ComplexInfoString
{
    private int quantityNumbers = 0;
    private int quantityUpperChars = 0;
    private int quantityLowerChars = 0;
    private int quantitySpecialChars = 0;
    private Dictionary<char, int> characterCounts = new Dictionary<char, int>();

    /// <summary>
    /// The this char.
    /// </summary>
    public int this[char character]
    {
        get
        {
            if (characterCounts.ContainsKey(character))
            {
                return characterCounts[character];
            }
            return 0;
        }
    }

    /// <summary>
    /// Gets the quantity numbers.
    /// </summary>
    public int QuantityNumbers => quantityNumbers;

    /// <summary>
    /// Gets the quantity lower chars.
    /// </summary>
    public int QuantityLowerChars => quantityLowerChars;

    /// <summary>
    /// Gets the quantity special chars.
    /// </summary>
    public int QuantitySpecialChars => quantitySpecialChars;

    /// <summary>
    /// Gets the quantity upper chars.
    /// </summary>
    public int QuantityUpperChars => quantityUpperChars;

    /// <summary>
    /// Initializes a new instance of the complex info string class.
    /// </summary>
    /// <param name="text">The text.</param>
    public ComplexInfoString(string text)
    {
        foreach (char item in text)
        {
            int keyCode = item;
            LetterAndDigitKeyCodeService letterAndDigitKeyCodeService = new();
            SpecialKeyCodeServices specialKeyCodeService = new();
            if (letterAndDigitKeyCodeService.LowerKeyCodes.Contains(keyCode))
            {
                quantityLowerChars++;
                NumberLettersOrDigit++;
            }
            else if (letterAndDigitKeyCodeService.UpperKeyCodes.Contains(keyCode))
            {
                quantityUpperChars++;
                NumberLettersOrDigit++;
            }
            else if (letterAndDigitKeyCodeService.NumericKeyCodes.Contains(keyCode))
            {
                quantityNumbers++;
                NumberLettersOrDigit++;
            }
            else if (specialKeyCodeService.SpecialKeyCodes.Contains(keyCode))
            {
                quantitySpecialChars++;
            }
            if (characterCounts.ContainsKey(item))
            {
                characterCounts[item]++;
            }
            else
            {
                characterCounts.Add(item, 1);
            }
            if (CountOfNeededLettersOrDigit != int.MaxValue)
            {
                if (NumberLettersOrDigit > CountOfNeededLettersOrDigit)
                {
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Gets or sets the count of needed letters or digit.
    /// </summary>
    public int CountOfNeededLettersOrDigit { get; set; } = int.MaxValue;

    /// <summary>
    /// Gets or sets the number letters or digit.
    /// </summary>
    public int NumberLettersOrDigit { get; set; } = 0;
}
