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
    public void Chomp_WithNewLines_ReturnsStringWithNewLinesAndcarriageReturnRemoved()
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


}





