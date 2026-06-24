namespace SunamoEntity._sunamo.SunamoString;

internal class SH
{
    internal static string FirstCharUpper(ref string text)
    {
        text = SH.FirstCharUpper(text);

        return text;
    }

    internal static string FirstCharUpper(string text, bool isOnlyFirstUpper = false)
    {
        if (text != null)
        {
            var substring = text.Substring(1);
            if (isOnlyFirstUpper) substring = substring.ToLower();

            return text[0].ToString().ToUpper() + substring;
        }

        return null!;
    }

    internal static List<char> ContainsAnyChar(string text, bool isCheckInCaseOnlyOneString, IList<char> characters)
    {
        var found = new List<char>();
        if (characters.Count() == 1 && isCheckInCaseOnlyOneString)
        {
            text.Contains(characters.First());
        }
        else
        {
            foreach (var character in characters)
            {
                if (text.Contains(character))
                {
                    found.Add(character);
                }
            }
        }

        return found;
    }

    internal static bool ContainsBracket(string text, ref List<char> leftBrackets, ref List<char> rightBrackets, bool isMustBeLeftAndRight = false)
    {
        leftBrackets = SH.ContainsAnyChar(text, false, AllLists.LeftBrackets);
        rightBrackets = SH.ContainsAnyChar(text, false, AllLists.LeftBrackets);
        if (isMustBeLeftAndRight)
        {
            if (leftBrackets.Count > 0 && rightBrackets.Count > 0)
            {
                return true;
            }
        }
        else
        {
            if (leftBrackets.Count > 0 || rightBrackets.Count > 0)
            {
                return true;
            }
        }

        return false;
    }

#pragma warning disable CS0649
    protected static Dictionary<BracketsShared, char>? BracketsLeft;
    protected static Dictionary<BracketsShared, char>? BracketsRight;

    protected static List<char>? BracketsLeftList;
    protected static List<char>? BracketsRightList;
#pragma warning restore CS0649

    internal static char ClosingBracketFor(char openingBracket)
    {
        foreach (var item in BracketsLeft!)
        {
            if (item.Value == openingBracket)
            {
                return BracketsRight![item.Key];
            }
        }

        ThrowEx.IsNotAllowed(openingBracket + " as bracket");
        return char.MaxValue;
    }

    internal static string GetTextBetween(string text, char afterChar, char beforeChar, bool isThrowingExceptionIfNotContains = true, object? notAllowedInRanges = null, bool isEndLastIndexOf = false)
    {
        return GetTextBetweenTwoChars(text, afterChar, beforeChar, isThrowingExceptionIfNotContains, notAllowedInRanges, isEndLastIndexOf);
    }

    internal static bool NotAllowedInRanges(object rangeChecker, int index)
    {
        if (rangeChecker is Func<int, bool> predicate)
        {
            return predicate(index);
        }

        ThrowEx.NotImplementedCase("NotAllowedInRanges: " + rangeChecker);
        return false;
    }

    internal static string GetTextBetweenTwoChars(string text, char beginChar, char endChar, bool isThrowingExceptionIfNotContains = true, object? notAllowedInRanges = null, bool isEndLastIndexOf = false)
    {
        int beginIndex = text.IndexOf(beginChar);
        int endIndex = -1;
        if (isEndLastIndexOf)
        {
            endIndex = text.LastIndexOf(endChar);
        }
        else
        {
            endIndex = text.IndexOf(endChar, beginIndex + 1);
            if (notAllowedInRanges != null)
            {
                while (endIndex != -1 && NotAllowedInRanges(notAllowedInRanges, endIndex))
                {
                    endIndex = text.IndexOf(endChar, endIndex + 1);
                }
            }
        }

        if (beginIndex == -1 || endIndex == -1)
        {
            if (isThrowingExceptionIfNotContains)
            {
                ThrowEx.NotContains(text, beginChar.ToString(), endChar.ToString());
            }
            else if (endIndex == -1)
            {
                return null!;
            }

            return text;
        }

        return GetTextBetweenTwoCharsInts(text, beginIndex, endIndex);
    }

    internal static string GetTextBetweenTwoCharsInts(string text, int beginIndex, int endIndex)
    {
        if (endIndex > beginIndex)
            return text.Substring(beginIndex + 1, endIndex - beginIndex - 1);
        return text;
    }

    internal static string WrapWith(string text, string wrapper) => wrapper + text + wrapper;

    internal static string TextWithoutDiacritic(string text) => text.RemoveDiacritics();
}
