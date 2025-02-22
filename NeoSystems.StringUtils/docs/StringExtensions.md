Below is an example of Markdown documentation for the provided C# code:

---

# NeoSystems.StringUtils Documentation

This documentation covers the extension methods provided in the `NeoSystems.StringUtils` namespace. The methods extend the native `string` class with additional utilities for searching, comparison, manipulation, and validation.

## Overview

The `StringExtensions` static class provides a collection of extension methods for strings. These methods include:
- Case-insensitive searches.
- Checking for the existence of any substring from a list or array.
- Equality comparisons.
- ASCII checks and character counting.
- Email validation.
- Removing specified characters.
- Commenting blocks of text.
- Newline removal and numeric validations.
- Converting a string to a valid identifier.

## Namespace

`NeoSystems.StringUtils`

## Class: StringExtensions

### Contains

```csharp
public static bool Contains(this string source, string toCheck, StringComparison comp)
```

- **Description:**  
  Determines whether the `source` string contains the substring `toCheck` using the specified `StringComparison` type.

- **Parameters:**  
  - `source`: The string to search within.  
  - `toCheck`: The substring to find.  
  - `comp`: The type of string comparison to perform.

- **Returns:**  
  `true` if the substring is found; otherwise, `false`.

---

### ContainsAnyOf (Array)

```csharp
public static bool ContainsAnyOf(this string source, string[] toCheckArr)
```

- **Description:**  
  Checks if the `source` string contains any of the substrings provided in the `toCheckArr` array.

- **Parameters:**  
  - `source`: The string to search within.  
  - `toCheckArr`: An array of substrings to check.

- **Returns:**  
  `true` if at least one substring is found; otherwise, `false`.

#### Overload with Comparison

```csharp
public static bool ContainsAnyOf(this string source, string[] toCheckArr, StringComparison comp)
```

- **Description:**  
  Same as above, but uses the specified `StringComparison` for each check.

- **Parameters:**  
  - `comp`: The type of string comparison to perform.

- **Returns:**  
  `true` if at least one substring is found using the specified comparison; otherwise, `false`.

---

### ContainsAnyOf (List)

```csharp
public static bool ContainsAnyOf(this string source, List<string> toCheckList)
```

- **Description:**  
  Checks if the `source` string contains any of the substrings in the provided `List<string>`.

- **Parameters:**  
  - `source`: The string to search within.  
  - `toCheckList`: A list of substrings to check.

- **Returns:**  
  `true` if at least one substring is found; otherwise, `false`.

#### Overload with Comparison

```csharp
public static bool ContainsAnyOf(this string source, List<string> toCheckList, StringComparison comp)
```

- **Description:**  
  Performs the check using the specified `StringComparison`.

- **Parameters:**  
  - `comp`: The type of string comparison to perform.

- **Returns:**  
  `true` if a match is found based on the comparison; otherwise, `false`.

---

### IsEqualToAnyOf (Array)

```csharp
public static bool IsEqualToAnyOf(this string source, string[] toCheckArr)
```

- **Description:**  
  Checks if the `source` string is exactly equal to any string in the `toCheckArr` array.

- **Parameters:**  
  - `source`: The string to compare.  
  - `toCheckArr`: An array of strings to compare against.

- **Returns:**  
  `true` if an exact match is found; otherwise, `false`.

#### Overload with Comparison

```csharp
public static bool IsEqualToAnyOf(this string source, string[] toCheckArr, StringComparison comp)
```

- **Description:**  
  Performs the equality check using the specified `StringComparison`.

- **Parameters:**  
  - `comp`: The type of string comparison to perform.

- **Returns:**  
  `true` if a match is found; otherwise, `false`.

---

### IsEqualToAnyOf (List)

```csharp
public static bool IsEqualToAnyOf(this string source, List<string> toCheckList)
```

- **Description:**  
  Checks if the `source` string is exactly equal to any string in the `toCheckList` list.

- **Parameters:**  
  - `source`: The string to compare.  
  - `toCheckList`: A list of strings to compare against.

- **Returns:**  
  `true` if an exact match is found; otherwise, `false`.

#### Overload with Comparison

```csharp
public static bool IsEqualToAnyOf(this string source, List<string> toCheckList, StringComparison comp)
```

- **Description:**  
  Checks for equality using the specified `StringComparison`.

- **Parameters:**  
  - `comp`: The type of string comparison to perform.

- **Returns:**  
  `true` if a match is found; otherwise, `false`.

---

### IsASCIIOnly

```csharp
public static bool IsASCIIOnly(this string source)
```

- **Description:**  
  Determines if the `source` string contains only ASCII characters.  
  *Note:* Uses UTF8 encoding to detect multi-byte sequences.

- **Returns:**  
  `true` if all characters are ASCII; otherwise, `false`.

---

### Count

```csharp
public static int Count(this string source, char c)
```

- **Description:**  
  Counts the number of occurrences of the specified character `c` in the `source` string.

- **Parameters:**  
  - `source`: The string in which to count occurrences.  
  - `c`: The character to count.

- **Returns:**  
  The number of times `c` appears in the string.

---

### IsEmail

```csharp
public static bool IsEmail(this string source)
```

- **Description:**  
  Validates whether the `source` string is a properly formatted email address.

- **Implementation Details:**  
  - Uses a regular expression to match the email format.  
  - Additionally, ensures that there is exactly one '@' character in the string.

- **Returns:**  
  `true` if the string is a valid email address; otherwise, `false`.

---

### RemoveAll (Character)

```csharp
public static string RemoveAll(this string s, char c)
```

- **Description:**  
  Removes all occurrences of the specified character `c` from the string `s`.

- **Parameters:**  
  - `s`: The original string.  
  - `c`: The character to remove.

- **Returns:**  
  A new string with all instances of `c` removed.

---

### RemoveAll (Character Array)

```csharp
public static string RemoveAll(this string s, char[] c)
```

- **Description:**  
  Removes all occurrences of the characters provided in the `c` array from the string `s`.

- **Parameters:**  
  - `s`: The original string.  
  - `c`: An array of characters to remove.

- **Returns:**  
  A new string with the specified characters removed.

---

### Comment (Using Custom Comment Strings)

```csharp
public static void Comment(this string[] lines, string commentstringFront, string commentstringAfter)
```

- **Description:**  
  Prepends `commentstringFront` and appends `commentstringAfter` to each line in the `lines` array.

- **Parameters:**  
  - `lines`: An array of strings to be commented.  
  - `commentstringFront`: The text to add at the beginning of each line.  
  - `commentstringAfter`: The text to add at the end of each line.

---

### Comment (Using Enums)

```csharp
public static void Comment(this string[] lines, CommentType type, CommentPosition position = CommentPosition.Front)
```

- **Description:**  
  Adds comments to each line of the `lines` array using a predefined comment style determined by the `CommentType` and its placement by `CommentPosition`.

- **Parameters:**  
  - `lines`: An array of strings to be commented.  
  - `type`: The type of comment to use (see **CommentType** below).  
  - `position`: Where to place the comment relative to the text. Defaults to `Front`.

---

### Chomp

```csharp
public static string Chomp(this string s)
```

- **Description:**  
  Removes a single trailing newline from the end of the string, if present. Supports `\n`, `\r`, or `\r\n`.

- **Returns:**  
  The string without the trailing newline characters.

---

### IsNumericsOnly

```csharp
public static bool IsNumericsOnly(this string s)
```

- **Description:**  
  Determines whether the string contains only numeric characters.

- **Returns:**  
  `true` if all characters are numeric; otherwise, `false`.

---

### ToIdentifier

```csharp
public static string ToIdentifier(this string s)
```

- **Description:**  
  Converts the string into a valid identifier for use in most coding languages by replacing non-identifier characters with an underscore (`_`).

- **Implementation Details:**  
  Delegates to the external method `StringUtils.StringToIdentifier(s)`.

- **Returns:**  
  A valid identifier string.

---

## Enums

### CommentType

Defines the types of comments that can be added using the `Comment` methods.

- **TraditionalC:**  
  Uses traditional C-style comments (`/* ... */`).

- **HashCharComments:**  
  Uses the hash (`#`) character for commenting.

- **Cplusplus:**  
  Uses C++ style comments (`//`).

---

### CommentPosition

Specifies the position where the comment should be added relative to the text.

- **Front:**  
  Adds the comment before the text.

- **After:**  
  Adds the comment after the text.

---

## Usage Examples

### Example 1: Case-Insensitive Contains Check

```csharp
string source = "Hello World";
bool containsHello = source.Contains("hello", StringComparison.OrdinalIgnoreCase);
```

### Example 2: Removing All Occurrences of a Character

```csharp
string original = "Hello World";
string result = original.RemoveAll('l');  // Result: "Heo Word"
```

### Example 3: Validating an Email Address

```csharp
string email = "user@example.com";
bool isValid = email.IsEmail();
```

### Example 4: Commenting a Block of Text

```csharp
string[] lines = { "Line 1", "Line 2", "Line 3" };
lines.Comment(StringExtensions.CommentType.Cplusplus, StringExtensions.CommentPosition.Front);
// Each line is prefixed with "// "
```

---

## Conclusion

The `NeoSystems.StringUtils` namespace offers a robust set of string extension methods to simplify common string manipulation tasks in C#. These methods enhance the functionality of the native `string` class and can improve code readability and maintainability.

Feel free to integrate these utilities into your projects to streamline your string handling operations.

---