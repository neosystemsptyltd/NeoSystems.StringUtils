# NeoSystems.StringUtils - SubstringExtensions Documentation

This documentation provides an overview of the `SubstringExtensions` class and its extension methods that simplify substring extraction from strings based on delimiter values.

---

## License

This code is released under the [MIT License](License.txt).

---

## Namespace

The class is part of the `NeoSystems.StringUtils` namespace.

---

## Overview

`SubstringExtensions` is a static class offering three extension methods for `string` objects:

- **Between:** Extracts a substring between the first occurrence of a starting delimiter and the last occurrence of an ending delimiter.
- **Before:** Retrieves the substring that occurs before the first occurrence of a specified delimiter.
- **After:** Retrieves the substring that occurs after the last occurrence of a specified delimiter.

These methods provide a convenient and safe way to handle substring extraction, returning an empty string if the required delimiters are not found or if the extraction conditions are not met.

---

## Extension Methods

### Between

**Signature:**

```csharp
public static string Between(this string value, string a, string b)
```

**Description:**

Extracts the substring between the first occurrence of the delimiter `a` and the last occurrence of the delimiter `b` within the input string.

**Parameters:**

- **value**: The source string from which to extract the substring.
- **a**: The starting delimiter.
- **b**: The ending delimiter.

**Behavior:**

- Returns an empty string if:
  - The input string is `null`.
  - The starting delimiter `a` is not found.
  - The ending delimiter `b` is not found.
  - The adjusted starting index (after delimiter `a`) is not less than the position of delimiter `b`.

**Example:**

```csharp
string sample = "Hello [World] Example";
string result = sample.Between("[", "]"); // result: "World"
```

---

### Before

**Signature:**

```csharp
public static string Before(this string value, string a)
```

**Description:**

Returns the substring of the input string that appears before the first occurrence of the delimiter `a`.

**Parameters:**

- **value**: The source string from which to extract the substring.
- **a**: The delimiter indicating where to stop the substring extraction.

**Behavior:**

- Returns an empty string if the delimiter `a` is not found.

**Example:**

```csharp
string sample = "Hello [World] Example";
string result = sample.Before("["); // result: "Hello "
```

---

### After

**Signature:**

```csharp
public static string After(this string value, string a)
```

**Description:**

Returns the substring of the input string that appears after the last occurrence of the delimiter `a`.

**Parameters:**

- **value**: The source string from which to extract the substring.
- **a**: The delimiter after which the substring extraction begins.

**Behavior:**

- Returns an empty string if:
  - The delimiter `a` is not found.
  - There is no content after the delimiter `a`.

**Example:**

```csharp
string sample = "Hello [World] Example";
string result = sample.After("]"); // result: " Example"
```

---

## Usage Example

Below is an example demonstrating how to use the `SubstringExtensions` methods:

```csharp
using System;
using NeoSystems.StringUtils;

class Program
{
    static void Main()
    {
        string sample = "Hello [World] Example";

        // Extract substring between "[" and "]"
        string betweenText = sample.Between("[", "]");
        // Expected output: "World"

        // Extract substring before "["
        string beforeText = sample.Before("[");
        // Expected output: "Hello "

        // Extract substring after "]"
        string afterText = sample.After("]");
        // Expected output: " Example"

        Console.WriteLine("Between: " + betweenText);
        Console.WriteLine("Before: " + beforeText);
        Console.WriteLine("After: " + afterText);
    }
}
```

---

## Remarks

- **Robustness:** The extension methods return an empty string rather than throwing exceptions when delimiters are missing or conditions aren’t met.
- **Null Handling:** In the `Between` method, a `null` input string is handled gracefully by returning an empty string.
- **Usage:** These methods can be easily integrated into any C# project by including the namespace `NeoSystems.StringUtils` and calling them on any string object.

---

This documentation should help you understand and integrate the `SubstringExtensions` class into your projects effectively.