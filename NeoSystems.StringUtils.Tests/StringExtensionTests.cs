using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NeoSystems.StringUtils.Tests;

public class StringExtensionTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void String_Count_Letters_A()
    {
        // Arrange
        string source = "abracadabra";

        // Act
        int result = source.Count('a');

        // Assert
        Assert.AreEqual(5, result);
    }

    [Test]
    public void String_Count_Letters_B()
    {
        // Arrange
        string source = "Supercalifragilisticexpialidocious";

        // Act
        int result = source.Count('i');

        // Assert
        Assert.AreEqual(7, result);
    }

    [Test]
    public void IsEmailTest_ValidEmail_ReturnsTrue()
    {
        string[] inputEmails = new string[] {
            "test@test.com",
            "test@test.co.uk",
            "name.surname@test.co.uk",
            "name.surname007@gmail.com",
            "name.surname1992@gmail.com",
            "example@gmail.com",
            "student123@yahoo.com",
            "abc@outlook.com",
            "johnson_family@msn.com",
            "surveyresponse@aol.com",
            "cheapskate@hotmail.com",
            "abcsolutions@comcast.net",
            "susan@verizon.net",
            "sunshine@sbcglobal.net",
            "tester123@frontier.com"
        };

        bool expected = true;

        foreach(string input in inputEmails)
        {
            bool result = input.IsEmail();
            Assert.AreEqual(expected, result);
        }
    }

    [Test]
    public void IsEmailTest_InvalidEmail_ReturnsFalse()
    {
        string[] inputEmails = new string[] {
            "testtest.com",
            "test@test",
            "name.surname@test",
            "name.surname007@gmail",
            "name.surname1992@gmail",
            "name@surname@some.address",
            "name@surname@some.address in the world",
            "name@this cannot be valid",
            "@gmail.com",
            "name.surname@",
            "joe@",
            "@domain.com",
            "john@.net",
            "sally#example.net",
            "johnsmith@",
            "john@smith@example.com",
            "john@example@example.com"
        };

        foreach (string input in inputEmails)
        {
            bool expected = false;
            bool result = input.IsEmail();
            Assert.AreEqual(expected, result);
        }
    }

    // Test 1
    [Test]
    public void RemoveAll_ShouldReplaceCharSuccessfully()
    {
        string expected = "abcd";
        string str = "a-b-c-d";
        char c = '-';
        string actual = str.RemoveAll(c);
        Assert.AreEqual(expected, actual);
    }

    // Test 2
    [Test]
    public void RemoveAll_ShouldReplaceMultipleCharsSuccessfully()
    {
        string expected = "abcd";
        string str = "a*b-c_d";
        char[] chars = new char[] { '*', '-', '_' };
        string actual = str.RemoveAll(chars);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Chomp_WithNewLines_ReturnsStringWithNewLinesAndCarriageReturnRemoved()
    {
        // arrange
        string input = "Hello\n\r";
        string expected = "Hello";
        // act
        string actual = input.Chomp();
        // assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Chomp_WithNewLines_ReturnsStringWithNewLinesRemoved()
    {
        // arrange
        string input = "Hello\n";
        string expected = "Hello";
        // act
        string actual = input.Chomp();
        // assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Chomp_WithCarriageReturns_ReturnsStringWithCarriageReturnRemoved()
    {
        // arrange
        string input = "Hello\r";
        string expected = "Hello";
        // act
        string actual = input.Chomp();
        // assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Chomp_WithEmptyString_ReturnsEmptyString()
    {
        // arrange
        string input = "";
        string expected = "";
        // act
        string actual = input.Chomp();
        // assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void IsNumericsOnlyTest()
    {
        // Arrange
        var inputString1 = "1234566";
        var inputString2 = "123a566";
        var inputString3 = "abcd";

        // Act
        var result1 = inputString1.IsNumericsOnly();
        var result2 = inputString2.IsNumericsOnly();
        var result3 = inputString3.IsNumericsOnly();

        // Assert
        Assert.IsTrue(result1);
        Assert.IsFalse(result2);
        Assert.IsFalse(result3);
    }

    // IsEqualToAnyOf Test
    [Test]
    public void IsEqualToAnyOf_ShouldReturnTrue_WithSingleMatch()
    {
        string[] toCheckArr = { "test1", "test2", "test3" };
        bool result = "test1".IsEqualToAnyOf(toCheckArr);
        Assert.AreEqual(true, result);
    }

    // IsEqualToAnyOf Test
    [Test]
    public void IsEqualToAnyOf_ShouldReturnFalse_WithNoMatches()
    {
        string[] toCheckArr = { "test1", "test2", "test3" };
        bool result = "test4".IsEqualToAnyOf(toCheckArr);
        Assert.AreEqual(false, result);
    }

    // IsEqualToAnyOf Test
    [Test]
    public void IsEqualToAnyOf_ShouldReturnTrue_WithMultipleMatches()
    {
        string[] toCheckArr = { "test1", "test2", "test2" };
        bool result = "test2".IsEqualToAnyOf(toCheckArr);
        Assert.AreEqual(true, result);
    }

    [Test]
    public void IsEqualToAnyOf_test()
    {
        string[] arrayToTest = { "one", "two", "three"};
        string compareToString = "One";

        //Test Default StringComparison
        Assert.IsFalse(compareToString.IsEqualToAnyOf(arrayToTest));

        // Test non-default StringComparison
        Assert.IsTrue(compareToString.IsEqualToAnyOf(arrayToTest, StringComparison.OrdinalIgnoreCase));
    }

    [Test]
    public void IsEqualToAnyOf_WhenSourceExists_ReturnsTrue()
    {
        // Arrange
        var source = "test";
        var list = new List<string>(){"test", "test2"};

        // Act
        bool result = source.IsEqualToAnyOf(list);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsEqualToAnyOf_WhenSourceDoesntExists_ReturnsFalse()
    {
        // Arrange
        var source = "test";
        var list = new List<string>() { "test2", "test3" };

        // Act
        bool result = source.IsEqualToAnyOf(list);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsEqualToAnyOf_ValuesInList_ReturnsTrue()
    {
        // Arrange
        List<string> checkList = new List<string> { "value1", "value2" };
        string source = "value2";

        // Act
        bool result = source.IsEqualToAnyOf(checkList, StringComparison.Ordinal);

        // Assert
        Assert.True(result);
    }

    [Test]
    public void IsEqualToAnyOf_ValueNotInList_ReturnsFalse()
    {
        // Arrange
        List<string> checkList = new List<string> { "value1", "value2" };
        string source = "value3";

        // Act
        bool result = source.IsEqualToAnyOf(checkList, StringComparison.Ordinal);

        // Assert
        Assert.False(result);
    }

    [Test]
    public void ToIdentifier_ShouldReturnExpectedIdentifier_ForValidInput()
    {
        // Arrange
        string input = "Valid Input";
        string expectedOutput = "Valid_Input"; // Assuming underscores replace spaces

        // Act
        string result = input.ToIdentifier();

        // Assert
        Assert.AreEqual(expectedOutput, result);
    }

    [Test]
    public void ToIdentifier_ShouldHandleEmptyString()
    {
        // Arrange & Act & Assert
        Assert.AreEqual(string.Empty, string.Empty.ToIdentifier());
    }

    [Test]
    public void ToIdentifier_ShouldHandleSpecialCharacters()
    {
        // Arrange
        string input = "Special@Chars!";
        string expectedOutput = "Special_Chars_"; // Assuming special characters are removed or replaced

        // Act
        string result = input.ToIdentifier();

        // Assert
        Assert.AreEqual(expectedOutput, result);
    }

    [Test]
    public void IsAlphaNumeric_WithLettersOnly_ReturnsTrue()
    {
        // Arrange
        string input = "HelloWorld";

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsAlphaNumeric_WithDigitsOnly_ReturnsTrue()
    {
        // Arrange
        string input = "123456";

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsAlphaNumeric_WithLettersAndDigits_ReturnsTrue()
    {
        // Arrange
        string input = "Hello123";

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsAlphaNumeric_WithSpecialCharacters_ReturnsFalse()
    {
        // Arrange
        string input = "Hello@123";

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsAlphaNumeric_EmptyString_ReturnsTrue()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsAlphaNumeric_WithWhitespace_ReturnsFalse()
    {
        // Arrange
        string input = "Hello 123";

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsUsername_WithValidLengthAndCharacters_ReturnsTrue()
    {
        // Arrange
        string input = "User_123";

        // Act
        bool result = input.IsUsername();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsUsername_WithTooShortUsername_ReturnsFalse()
    {
        // Arrange
        string input = "User";

        // Act
        bool result = input.IsUsername();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsUsername_WithTooLongUsername_ReturnsFalse()
    {
        // Arrange
        string input = "ThisIsAVeryLongUsername123";

        // Act
        bool result = input.IsUsername();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsUsername_WithSpecialCharacters_ReturnsFalse()
    {
        // Arrange
        string input = "User!@#";

        // Act
        bool result = input.IsUsername();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsUsername_WithValidCustomLength_ReturnsTrue()
    {
        // Arrange
        string input = "Usr";
        int minLength = 3;
        int maxLength = 10;

        // Act
        bool result = input.IsUsername(minLength, maxLength);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsUsername_WithInvalidCustomLength_ReturnsFalse()
    {
        // Arrange
        string input = "TooLongUsername";
        int minLength = 5;
        int maxLength = 10;

        // Act
        bool result = input.IsUsername(minLength, maxLength);

        // Assert
        Assert.IsFalse(result);
    }
}





