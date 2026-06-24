namespace SunamoEntity.Entity;

public class ComplexInfoString
{
    private int quantityNumbers = 0;
    private int quantityUpperChars = 0;
    private int quantityLowerChars = 0;
    private int quantitySpecialChars = 0;
    private Dictionary<char, int> characterCounts = new Dictionary<char, int>();

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

    public int QuantityNumbers => quantityNumbers;

    public int QuantityLowerChars => quantityLowerChars;

    public int QuantitySpecialChars => quantitySpecialChars;

    public int QuantityUpperChars => quantityUpperChars;

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

    public int CountOfNeededLettersOrDigit { get; set; } = int.MaxValue;

    public int NumberLettersOrDigit { get; set; } = 0;
}
