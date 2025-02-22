Below is the markdown documentation for the provided code:

---

# NeoSystems.StringUtils Documentation

This library provides a collection of static string utility methods for various common tasks such as cleaning strings, formatting versions, converting values, and more.

## Namespace

**NeoSystems.StringUtils**

## Class

**StringUtils**  
A collection of static methods that perform various string manipulations and conversions.

---

## Methods

### StringToNumericsOnly

**Description**:  
Extracts only the numeric characters from the provided input string. Non-numeric characters are removed, and the result is trimmed of any leading or trailing periods.

**Parameters**:  
- `dirtystring` (`string`): The input string containing various characters.

**Returns**:  
- `string`: A string containing only numeric characters.

---

### GetTextBetweenMarkers

**Description**:  
Searches for the first occurrence of two marker strings within the original text and returns the substring located between them. Returns an empty string if either marker is not found or if the markers are in the wrong order.

**Parameters**:  
- `origtext` (`string`): The text to search in.  
- `marker1` (`string`): The starting marker.  
- `marker2` (`string`): The ending marker.

**Returns**:  
- `string`: The text found between the markers, or an empty string if not found.

---

### RemoveComment

**Description**:  
Removes a comment from a given string by truncating the string at the first occurrence of the specified comment character.

**Parameters**:  
- `s` (`string`): The string from which to remove the comment.  
- `commentchar` (`char`): The character that indicates the start of the comment.

**Returns**:  
- `string`: The string with the comment removed.

---

### FillToLength

**Description**:  
Extends a string to a specified length by appending a repeated character. The helper method `ConstCharStr` is used to generate the padding.

**Parameters**:  
- `s` (`string`): The original string.  
- `c` (`char`): The character to use for padding.  
- `l` (`int`): The target total length of the string.

**Returns**:  
- `string`: The padded string.

---

### VersionString

**Description**:  
Converts a numeric version represented as a `ushort` into a formatted version string. For example, an input of `12345` is converted to `"V 1.23.45"`.

**Parameters**:  
- `version` (`ushort`): The numeric representation of the version.

**Returns**:  
- `string`: The formatted version string.

---

### ConstCharArray

**Description**:  
Creates a character array of a specified length where each element is set to the provided character.

**Parameters**:  
- `c` (`char`): The character to fill the array with.  
- `length` (`int`): The number of elements in the array.

**Returns**:  
- `char[]`: The initialized character array.

---

### TextToFloat

**Description**:  
Converts a string to a `float` value. The method replaces commas with periods, attempts to parse the number, and ensures that the result falls within a given range. If parsing fails, a default value is used.

**Parameters**:  
- `str` (`string`): The string to convert.  
- `min` (`float`): The minimum allowed value.  
- `def` (`float`): The default value if conversion fails.  
- `max` (`float`): The maximum allowed value.

**Returns**:  
- `float`: The parsed and clamped float value.

---

### TextToDouble

**Description**:  
Similar to `TextToFloat`, this method converts a string to a `double` value while ensuring the result is within a specified range. A default value is used if conversion fails.

**Parameters**:  
- `str` (`string`): The string to convert.  
- `min` (`double`): The minimum allowed value.  
- `def` (`double`): The default value if conversion fails.  
- `max` (`double`): The maximum allowed value.

**Returns**:  
- `double`: The parsed and clamped double value.

---

### BoolToString

**Description**:  
Converts a boolean value to its corresponding string representation.

**Parameters**:  
- `Value` (`bool`): The boolean value to convert.  
- `truestring` (`string`, optional): The string to return if `Value` is true (default: `"True"`).  
- `falsestring` (`string`, optional): The string to return if `Value` is false (default: `"False"`).

**Returns**:  
- `string`: The string representation of the boolean value.

---

### MaskedBoolToStr

**Description**:  
Evaluates a bitmask against an unsigned integer and returns one of two strings based on whether the masked bit is set.

**Parameters**:  
- `value` (`uint`): The unsigned integer to test.  
- `mask` (`uint`): The bitmask to apply.  
- `truestring` (`string`, optional): The string to return if the bit is set (default: `"True"`).  
- `falsestring` (`string`, optional): The string to return if the bit is not set (default: `"False"`).

**Returns**:  
- `string`: The string representing the result of the masked test.

---

### MaskedBoolToYesNo

**Description**:  
Returns `"Yes"` or `"No"` based on a bitmask test applied to an unsigned integer.

**Parameters**:  
- `value` (`uint`): The unsigned integer to test.  
- `mask` (`uint`): The bitmask to apply.

**Returns**:  
- `string`: `"Yes"` if the bit is set, `"No"` otherwise.

---

### MaskedBoolToActiveInactive

**Description**:  
Returns `"Active"` or `"Inactive"` based on a bitmask test applied to an unsigned integer.

**Parameters**:  
- `value` (`uint`): The unsigned integer to test.  
- `mask` (`uint`): The bitmask to apply.

**Returns**:  
- `string`: `"Active"` if the bit is set, `"Inactive"` otherwise.

---

### MultiCharReplace

**Description**:  
Replaces all occurrences of a set of characters in a string with a specified new character.

**Parameters**:  
- `old_multichars` (`string`): A string containing the characters to be replaced.  
- `newchar` (`char`): The character to replace each occurrence with.  
- `str` (`string`): The input string.

**Returns**:  
- `string`: The resulting string after replacement.

---

### StringToIdentifier

**Description**:  
Converts a string into a valid identifier by replacing multiple special characters with underscores. If the resulting identifier starts with a number, an `"a"` is prepended to ensure it is valid.

**Parameters**:  
- `str` (`string`): The original string.

**Returns**:  
- `string`: A valid identifier.

---

### ConstCharStr

**Description**:  
Generates a string that consists of a specified character repeated a given number of times.

**Parameters**:  
- `c` (`char`): The character to repeat.  
- `count` (`int`): The number of times to repeat the character.

**Returns**:  
- `string`: The resulting string composed of the repeated character.

---

### SplitOnSizeOptions (Enum)

**Description**:  
Defines options for the `SplitOnSize` method.

**Members**:  
- `WholeWords`: When set, the splitting process will attempt to keep whole words together instead of breaking them.

---

### SplitOnSize

**Description**:  
Splits a string into an array of substrings where each substring does not exceed a specified maximum size. An option is provided to preserve whole words if desired.

**Parameters**:  
- `str` (`string`): The string to split.  
- `maxsize` (`int`): The maximum allowed length for each substring.  
- `opt` (`SplitOnSizeOptions`): Options for splitting (e.g., preserving whole words).

**Returns**:  
- `string[]`: An array of substrings.

---

### CountLeading

**Description**:  
Counts the number of consecutive occurrences of a specified character at the beginning of a string.

**Parameters**:  
- `s` (`string`): The string to inspect.  
- `c` (`char`): The character to count.

**Returns**:  
- `int`: The count of leading occurrences of the specified character.

---

### TrimFromLast

**Description**:  
Trims the string by removing all characters from the last occurrence of the specified character to the end of the string.

**Parameters**:  
- `s` (`string`): The original string.  
- `c` (`char`): The character to use as the trim marker.

**Returns**:  
- `string`: The trimmed string. If the character is not found or is at the beginning, the original string is returned.

---

### IsZARCellPhoneNumber

**Description**:  
Determines if the provided string is a South African cellphone number based on a predefined list of common prefixes.

**Parameters**:  
- `num` (`string`): The phone number string to test.

**Returns**:  
- `bool`: `true` if the string matches one of the known cellphone prefixes; otherwise, `false`.

---

### CompactWhitespaces

**Description**:  
Removes extra whitespace from a string, ensuring that words are separated by a single space.

**Overloads**:  
1. **CompactWhitespaces(String s)**  
   - **Parameters**:  
     - `s` (`string`): The string to compact.
   - **Returns**:  
     - `string`: A new string with compacted whitespace.

2. **CompactWhitespaces(StringBuilder sb)**  
   - **Parameters**:  
     - `sb` (`StringBuilder`): The `StringBuilder` instance to modify in place.
   - **Returns**:  
     - `void`: The method modifies the `StringBuilder` directly.

---

### ByteArrayToString

**Description**:  
Converts a byte array into its hexadecimal string representation.

**Overloads**:  
1. **ByteArrayToString(byte[] ba)**  
   - **Parameters**:  
     - `ba` (`byte[]`): The byte array to convert.
   - **Returns**:  
     - `string`: A hexadecimal string representing the entire byte array.

2. **ByteArrayToString(byte[] ba, int offs, int len)**  
   - **Parameters**:  
     - `ba` (`byte[]`): The byte array to convert.  
     - `offs` (`int`): The starting offset in the array.  
     - `len` (`int`): The number of bytes to convert.
   - **Returns**:  
     - `string`: A hexadecimal string representing the specified portion of the byte array.

---

### HexCharToByte

**Description**:  
Converts a single hexadecimal character to its corresponding byte value (0–15).

**Parameters**:  
- `c` (`char`): The hexadecimal character.

**Returns**:  
- `byte`: The numeric value corresponding to the hexadecimal character.

---

## License

This code is licensed under the MIT License. See [License.txt](./License.txt) for details.

---

## Usage Example

```csharp
using System;
using NeoSystems.StringUtils;

class Example
{
    static void Main()
    {
        // Extract only numeric characters from a dirty string
        string dirty = "abc123.def";
        string numbersOnly = StringUtils.StringToNumericsOnly(dirty);
        Console.WriteLine(numbersOnly); // Outputs: 123

        // Get text between two markers
        string text = "Hello [World]!";
        string extracted = StringUtils.GetTextBetweenMarkers(text, "[", "]");
        Console.WriteLine(extracted); // Outputs: World

        // Convert a ushort version number to a formatted version string
        ushort version = 12345;
        string versionStr = StringUtils.VersionString(version);
        Console.WriteLine(versionStr); // Outputs: V 1.23.45
    }
}
```

---

## Additional Notes

- Many methods include error handling (using try-catch blocks) to ensure that invalid input defaults to a safe or specified fallback value.
- The library provides both direct conversion methods (like `TextToFloat` and `TextToDouble`) and formatting utilities (like `VersionString`).
- Overloaded methods such as `ByteArrayToString` and `CompactWhitespaces` offer flexibility depending on whether you are working with full arrays/strings or portions thereof.

---

This documentation outlines the purpose, parameters, return types, and usage examples for the functions provided in the `NeoSystems.StringUtils` library.