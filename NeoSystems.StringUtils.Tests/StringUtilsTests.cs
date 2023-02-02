using System.Text;
using NUnit.Framework;

namespace NeoSystems.StringUtils.Tests;

public class StringUtilsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void StringToNumericsOnly_Empty_String()
    {
        // Arrange
        string testString = "";

        // Act
        string cleanString = StringUtils.StringToNumericsOnly(testString);

        // Assert
        Assert.AreEqual("", cleanString);
    }

    [Test]
    public void StringToNumericsOnly_Alphanumeric_String()
    {
        // Arrange
        string testString = "t3e5t7s9tring";

        // Act
        string cleanString = StringUtils.StringToNumericsOnly(testString);

        // Assert
        Assert.AreEqual("3579", cleanString);
    }

    [Test]
    public void StringToNumericsOnly_SpecialChars_String()
    {
        // Arrange
        string testString = "t3#$%^&*09tring";

        // Act
        string cleanString = StringUtils.StringToNumericsOnly(testString);

        // Assert
        Assert.AreEqual("309", cleanString);
    }

    [Test]
    public void GetTextBetweenMarkers_Test()
    {
        string origtext = "This is the {data} to be processed";
        string marker1 = "{", marker2 = "}";

        string expected = "data";
        string actual = StringUtils.GetTextBetweenMarkers(origtext, marker1, marker2);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GetTextBetweenMarkers_Test_LeftDoesNotExist()
    {
        string origtext = "This is the {data} to be processed";
        string marker1 = "<", marker2 = "}";

        string expected = "";
        string actual = StringUtils.GetTextBetweenMarkers(origtext, marker1, marker2);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GetTextBetweenMarkers_Test_RightDoesNotExist()
    {
        string origtext = "This is the {data} to be processed";
        string marker1 = "{", marker2 = ">";

        string expected = "";
        string actual = StringUtils.GetTextBetweenMarkers(origtext, marker1, marker2);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GetTextBetweenMarkers_Test_NeitherExists()
    {
        string origtext = "This is the {data} to be processed";
        string marker1 = "<", marker2 = ">";

        string expected = "";
        string actual = StringUtils.GetTextBetweenMarkers(origtext, marker1, marker2);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void RemoveComment_NoComments_ReturnsSameString()
    {
        // Arrange
        string input = "This is a valid string.";
        char commentChar = '#';
        string expected = "This is a valid string.";

        // Act
        string actual = StringUtils.RemoveComment(input, commentChar);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void RemoveComment_WithComments_ReturnStringWithoutComments()
    {
        // Arrange
        string input = "This is an invalid #comment.";
        char commentChar = '#';
        string expected = "This is an invalid ";

        // Act
        string actual = StringUtils.RemoveComment(input, commentChar);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void RemoveComment_CommentAtIndexZero_ReturnsEmptyString()
    {
        // Arrange
        string input = "#comment at beginning of string";
        char commentChar = '#';
        string expected = "";

        // Act
        string actual = StringUtils.RemoveComment(input, commentChar);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void FillToLength_Test_LengthZero()
    {
        string s = "abc";
        char c = '0';
        int l = 3;
        string expected = "abc";
        string actual = StringUtils.FillToLength(s, c, l);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void FillToLength_Test_LengthGreater()
    {
        string s = "abc";
        char c = '0';
        int l = 10;
        string expected = "abc0000000";
        string actual = StringUtils.FillToLength(s, c, l);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void FillToLength_Test_LengthEqual()
    {
        string s = "abc";
        char c = '0';
        int l = 5;
        string expected = "abc00";
        string actual = StringUtils.FillToLength(s, c, l);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void VersionStringV1845Test()
    {
        Assert.AreEqual("V 1.84.05", StringUtils.VersionString(18405));
    }

    [Test]
    public void VersionStringV2032Test()
    {
        Assert.AreEqual("V 2.03.22", StringUtils.VersionString(20322));
    }

    [Test]
    public void Test_ConstCharArray_withCharC_Length1()
    {
        char[] result = StringUtils.ConstCharArray('c', 1);
        Assert.AreEqual('c', result[0]);
        Assert.AreEqual(1, result.Length);
    }

    [Test]
    public void Test_ConstCharArray_withCharC_Length2()
    {
        char[] result = StringUtils.ConstCharArray('c', 2);
        Assert.AreEqual('c', result[0]);
        Assert.AreEqual('c', result[1]);
        Assert.AreEqual(2, result.Length);
    }

    [Test]
    public void Test_ConstCharArray_withCharC_Length0()
    {
        char[] result = StringUtils.ConstCharArray('c', 0);
        Assert.AreEqual(0, result.Length);
    }

    [Test]
    public void TestParseFloatValidInput()
    {
        float expected = 3.14f;
        float actual = StringUtils.TextToFloat("3.14", 0f, 0f, 10f);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TestParseFloatOutOfRangeUpper()
    {
        float expected = 10f;
        float actual = StringUtils.TextToFloat("11.0", 0f, 0f, 10f);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TestParseFloatOutOfRangeLower()
    {
        float expected = 0f;
        float actual = StringUtils.TextToFloat("-11.0", 0f, 0f, 10f);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TestParseFloatInvalidInput()
    {
        float expected = 0f;
        float actual = StringUtils.TextToFloat("abc", 0f, 0f, 10f);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TextToDouble_PassValidInputWithinLimits_OutputsValidResult()
    {
        //Arrange
        const string input = "2.22";
        const double min = 0.00;
        const double expected = 2.22;
        const double max = 10.00;
        const double def = 0.00;

        //Act
        double actual = StringUtils.TextToDouble(input, min, def, max);

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TextToDouble_FailValidInputOutOfLimits_OutputsDefaultValue()
    {
        //Arrange
        const string input = "12.22";
        const double min = 0.00;
        const double expected = 10.00;
        const double max = 10.00;
        const double def = 0.00;

        //Act
        double actual = StringUtils.TextToDouble(input, min, def, max);

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TextToDouble_PassInvalidInput_OutputsDefaultValue()
    {
        //Arrange
        const string input = "not a number";
        const double min = 0.00;
        const double expected = 0.00;
        const double max = 10.00;
        const double def = 0.00;

        //Act
        double actual = StringUtils.TextToDouble(input, min, def, max);

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TestBoolToString()
    {
        // Test passing in True
        Assert.AreEqual("True", StringUtils.BoolToString(true));

        // Test passing in False
        Assert.AreEqual("False", StringUtils.BoolToString(false));

        // Test passing different strings for true and false
        Assert.AreEqual("Yes", StringUtils.BoolToString(true, "Yes", "No"));
        Assert.AreEqual("No", StringUtils.BoolToString(false, "Yes", "No"));
    }

    [Test]
    public void MaskedBoolToStr_UintValueMatchesMask_ReturnsTrueString()
    {
        uint value = 1;
        uint mask = 1;
        var expected = "True";
        var actual = StringUtils.MaskedBoolToStr(value, mask);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void MaskedBoolToStr_UintValueDoesNotMatchMask_ReturnsFalseString()
    {
        uint value = 1;
        uint mask = 2;
        var expected = "False";
        var actual = StringUtils.MaskedBoolToStr(value, mask);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void MaskedBoolToStr_CustomTrueAndFalseStrings_ReturnsAppropriateValues()
    {
        uint value = 1;
        uint mask = 1;
        var truestring = "Yup";
        var falsestring = "Nope";

        var expectedTrueResult = "Yup";
        var trueResult = StringUtils.MaskedBoolToStr(value, mask, truestring, falsestring);
        Assert.AreEqual(expectedTrueResult, trueResult);

        var expectedFalseResult = "Nope";
        var falseResult = StringUtils.MaskedBoolToStr(value, mask + 1, truestring, falsestring);
        Assert.AreEqual(expectedFalseResult, falseResult);
    }

    [Test]
    public void MaskedBoolToYesNo_TrueValue_ReturnsYes()
    {
        Assert.AreEqual("Yes", StringUtils.MaskedBoolToYesNo(7, 7));
    }

    [Test]
    public void MaskedBoolToYesNo_FalseValue_ReturnsNo()
    {
        Assert.AreEqual("No", StringUtils.MaskedBoolToYesNo(2, 5));
    }

    [Test]
    public void ExpectedTrueValueReturnActive()
    {
        Assert.AreEqual("Active", StringUtils.MaskedBoolToActiveInactive(1, 5));
    }

    [Test]
    public void ExpectedFalseValueReturnInActive()
    {
        Assert.AreEqual("Inactive", StringUtils.MaskedBoolToActiveInactive(2, 5));
    }

    [Test]
    public void DifferentValuesReturnInActive()
    {
        Assert.AreEqual("Inactive", StringUtils.MaskedBoolToActiveInactive(2, 5));
    }

    [Test]
    public void MultiCharReplaceTest1()
    {
        string expected = "4bcd4";
        string actual = StringUtils.MultiCharReplace("aeiou", '4', "abcde");

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void MultiCharReplaceTest2()
    {
        string expected = "@llb3t";
        string actual = StringUtils.MultiCharReplace("aeiou", '3', "@llbet");

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void StringToIdentifier_NoChange_Test()
    {
        string input = "abc123";
        string expected = "abc123";
        string actual = StringUtils.StringToIdentifier(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void StringToIdentifier_BeginningNumber_Test()
    {
        string input = "123abc";
        string expected = "a123abc";
        string actual = StringUtils.StringToIdentifier(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void StringToIdentifier_SpecialCharacter_Test()
    {
        string input = "a\\bc?";
        string expected = "a_bc_";
        string actual = StringUtils.StringToIdentifier(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void StringToIdentifier_EmptyString_Test()
    {
        string input = "";
        string expected = "";
        string actual = StringUtils.StringToIdentifier(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ConstCharStr_WhenGivenAGivenCharacter_ShouldReturnThatGivenNumberOfCharacter()
    {
        //Arrange
        char c = 'a';
        int count = 5;

        //Act
        string result = StringUtils.ConstCharStr(c, count);

        //Assert
        Assert.AreEqual("aaaaa", result);

    }

    [Test]
    public void ConstCharStr_WheGivenNegativNumber_ShouldReturnEmptryString()
    {
        //Arrange
        char c = 'a';
        int count = -2;

        //Act
        string result = StringUtils.ConstCharStr(c, count);

        //Assert
        Assert.AreEqual("", result);
    }

    //Negative test:
    [Test]
    public void SplitOnSize_SizeBiggerThanString_NullReturned()
    {
        string str = "abcde";
        int maxsize = 10;
        StringUtils.SplitOnSizeOptions opt = 0;

        string[] result = StringUtils.SplitOnSize(str, maxsize, opt);
        Assert.AreEqual(1, result.Length);
    }

    //Possitive test 1:
    [Test]
    public void SplitOnSize_SplitOnRegularCharacter_ResultEquals3()
    {
        string str = "abcde";
        int maxsize = 2;
        StringUtils.SplitOnSizeOptions opt = 0;

        string[] result = StringUtils.SplitOnSize(str, maxsize, opt);
        Assert.AreEqual(3, result.Length);
    }

    //Possitive test 2:
    [Test]
    public void SplitOnSize_SplitOnWholeWords_ResultEqual2()
    {
        string str = "ab cd";
        int maxsize = 3;
        StringUtils.SplitOnSizeOptions opt = StringUtils.SplitOnSizeOptions.WholeWords;

        string[] result = StringUtils.SplitOnSize(str, maxsize, opt);
        Assert.AreEqual(2, result.Length);
    }

    [Test]
    public void CountLeadingTest()
    {
        // Check edge case
        Assert.AreEqual(0, StringUtils.CountLeading("", 'a'));

        // Check when it is the only character
        Assert.AreEqual(3, StringUtils.CountLeading("aaa", 'a'));

        // Check when it is mixed with other characters
        Assert.AreEqual(2, StringUtils.CountLeading("aab", 'a'));

        // Check when the character is not present
        Assert.AreEqual(0, StringUtils.CountLeading("bbb", 'a'));

    }

    //Test 1
    [Test]
    public void TrimFromLast_ShouldReturnStringWithoutTrailingChar()
    {
        // Arrange
        string s = "Hello, world! How are you?";
        char c = '!';

        // Act
        string result = StringUtils.TrimFromLast(s, c);

        // Assert
        Assert.AreEqual("Hello, world", result);
    }

    //Test 2
    [Test]
    public void TrimFromLast_ShouldReturnOriginalStringIfNoTrailingChar()
    {
        // Arrange
        string s = "Hello, world. How are you?";
        char c = '!';

        // Act
        string result = StringUtils.TrimFromLast(s, c);

        // Assert
        Assert.AreEqual("Hello, world. How are you?", result);
    }


    [Test]
    public void CompactWhitespaces_MultipleSpaces_ReturnsCompactedString()
    {
        // Arrange
        string s = "  This   is a   string  with   multiple   spaces   ";
        string expected = "This is a string with multiple spaces";

        // Act
        string actual = StringUtils.CompactWhitespaces(s);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CompactWhitespaces_LeadingAndTrailingSpaces_ReturnsCompactedString()
    {
        // Arrange
        string s = "  This is a string with leading and trailing spaces  ";
        string expected = "This is a string with leading and trailing spaces";

        // Act
        string actual = StringUtils.CompactWhitespaces(s);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CompactWhitespaces_NoWhitespaces_SameString()
    {
        var sb = new StringBuilder("abcxyz");
        StringUtils.CompactWhitespaces(sb);
        Assert.AreEqual("abcxyz", sb.ToString());
    }

    [Test]
    public void CompactWhitespaces_CompactMultipleWhitespaces_OneWhitespace()
    {
        var sb = new StringBuilder("a   b   c   x   y   z");
        StringUtils.CompactWhitespaces(sb);
        Assert.AreEqual("a b c x y z", sb.ToString());
    }

    [Test]
    public void CompactWhitespaces_DontCompactTab()
    {
        var sb = new StringBuilder(string.Empty);
        sb.Append("a\tb\tc\tx\ty\tz");
        StringUtils.CompactWhitespaces(sb);
        Assert.AreEqual("a b c x y z", sb.ToString());
    }

    [Test]
    public void CompactWhitespaces_LeadingAndTrailingWhitespace()
    {
        var sb = new StringBuilder("   a   b   c   x   y   z   ");
        StringUtils.CompactWhitespaces(sb);
        Assert.AreEqual("a b c x y z", sb.ToString());
    }

    [Test]
    public void CompactWhitespaces_StringWithOnlyWhitespaces_EmptyString()
    {
        var sb = new StringBuilder("      ");
        StringUtils.CompactWhitespaces(sb);
        Assert.AreEqual(string.Empty, sb.ToString());
    }

    [Test]
    public void CompactWhitespaces_StringWithOnlyTabs_EmptyString()
    {
        var sb = new StringBuilder("\t\t\t\t");
        StringUtils.CompactWhitespaces(sb);
        Assert.AreEqual(string.Empty, sb.ToString());
    }

    [Test]
    public void CompactWhitespaces_StringWithNonVisibleCharacter_CompactsToOneWhitespace()
    {
        var sb = new StringBuilder("   a   \x000b   c   ");
        StringUtils.CompactWhitespaces(sb);
        Assert.AreEqual("a c", sb.ToString());
    }

    [TestFixture]
    public class ByteArrayToStringTests
    {
        [Test]
        public void WhenEmptyByteArray_ReturnEmptyString()
        {
            byte[] ba = new byte[0];
            string expected = string.Empty;
            string actual = StringUtils.ByteArrayToString(ba);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WhenNullByteArray_ReturnEmptyString()
        {
            byte[]? ba = null;
            string expected = string.Empty;
            string actual = StringUtils.ByteArrayToString(ba);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WhenByteArray_ReturnExpectedString()
        {
            byte[] ba = new byte[] { 0xFF, 0x12, 0xA0 };
            string expected = "ff12a0";
            string actual = StringUtils.ByteArrayToString(ba);
            Assert.AreEqual(expected, actual);
        }

    }

    [TestFixture]
    public class ByteArrayToStringTestsOffsLen
    {
        [Test]
        public void ZeroLengthInput_ReturnsEmptyString()
        {
            int offs = 0;
            int len = 0;
            byte[] ba = new byte[0];
            string expected = string.Empty;

            string result = StringUtils.ByteArrayToString(ba, offs, len);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void NonZeroLengthInput_ReturnsExpectedString()
        {
            int offs = 0;
            int len = 3;
            byte[] ba = new byte[3] { 0xFF, 0xFE, 0x21 };
            string expected = "fffe21";

            string result = StringUtils.ByteArrayToString(ba, offs, len);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void OffsetLeadingZeroInput_ReturnsExpectedString()
        {
            int offs = 1;
            int len = 3;
            byte[] ba = new byte[4] { 0x34, 0xFF, 0xFE, 0x21 };
            string expected = "fffe21";

            string result = StringUtils.ByteArrayToString(ba, offs, len);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void OffsetNonLeadingZeroInput_ReturnsExpectedString()
        {
            int offs = 2;
            int len = 2;
            byte[] ba = new byte[4] { 0x34, 0xFF, 0xFE, 0x21 };
            string expected = "fe21";

            string result = StringUtils.ByteArrayToString(ba, offs, len);

            Assert.AreEqual(expected, result);
        }
    }

    [Test]
    public void HexCharToByte_ReturnsZero_WhenCharacterIsSmallerThanZero()
    {
        Assert.AreEqual(0, StringUtils.HexCharToByte('-'));
    }

    [Test]
    public void HexCharToByte_ReturnsValue_WhenCharacterIsBetweenZeroAndNine()
    {
        Assert.AreEqual(4, StringUtils.HexCharToByte('4'));
    }

    [Test]
    public void HexCharToByte_ReturnsValue_WhenCharacterIsBetweenAAndF()
    {
        Assert.AreEqual(14, StringUtils.HexCharToByte('E'));
        Assert.AreEqual(15, StringUtils.HexCharToByte('F'));
    }
    
    [Test]
    public void HexCharToByte_ReturnsValue_WhenCharacterIsBetweenATandF()
    {
        Assert.AreEqual(14, StringUtils.HexCharToByte('e'));
        Assert.AreEqual(15, StringUtils.HexCharToByte('f'));
    }

}


