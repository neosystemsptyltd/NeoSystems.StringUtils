using NUnit.Framework;

namespace NeoSystems.StringUtils.Tests;

public class SubStringExtensionsTests
{
    [SetUp]
    public void Setup()
    {
    }

    // Tests
    [Test]
    public void Between_WhenStringIsNull_ShouldReturnEmptyString()
    {
        // Arrange
        string? input = null;
        string a = "";
        string b = "";

        // Act
        var result = input.Between(a, b);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Between_WhenStringBPositionIsLessThanAPosition_ShouldReturnEmptyString()
    {
        // Arrange
        string input = "ABCD";
        string a = "B";
        string b = "A";

        // Act
        var result = input.Between(a, b);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Between_WhenStringAPositionIsNotFound_ShouldReturnEmptyString()
    {
        // Arrange
        string input = "ABCD";
        string a = "E";
        string b = "A";

        // Act
        var result = input.Between(a, b);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Between_WhenStringBPositionIsNotFound_ShouldReturnEmptyString()
    {
        // Arrange
        string input = "ABCD";
        string a = "B";
        string b = "E";

        // Act
        var result = input.Between(a, b);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Between_WhenStringIsValid_ShouldReturnExpectedResult()
    {
        // Arrange
        string input = "ABCDE";
        string a = "B";
        string b = "D";
        string expected = "C";

        // Act
        var result = input.Between(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Before_Extension_StringValueContainsInput()
    {
        string result = "This is a test".Before("is a");
        Assert.AreEqual("This ", result);
    }

    [Test]
    public void Before_Extension_StringValueDoesNotContainInput()
    {
        string result = "This is a test".Before("not");
        Assert.AreEqual("", result);
    }

    [Test]
    public void After_ReturnsEmptyString_WhenNoValueProvided()
    {
        // Arrange
        string expected = "";

        // Act
        string actual = "".After("a");

        // Assert 
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void After_ReturnsSubstring_WhenValueIsProvided()
    {
        // Arrange
        string expected = "HHHH";

        // Act
        string actual = "1234HHHH".After("1234");

        // Assert 
        Assert.AreEqual(expected, actual);
    }
}