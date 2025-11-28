# TODO

## Bugs

- [ ] **Fix `IsEmail` Regex**: The current regex implementation in `StringExtensions.IsEmail` is too simple and may not catch all valid/invalid email formats.
- [ ] **Fix `IsZARCellPhoneNumber`**: The method in `StringUtils` has a `@AJTODO` comment and needs a rewrite using regex. The current prefix list is likely incomplete.
- [ ] **Fix `SubstringExtensions.Between` Logic**: It uses `LastIndexOf` for the second marker, which makes it greedy (finds the last occurrence). This might be unexpected compared to `StringUtils.GetTextBetweenMarkers` or standard "between" logic which usually finds the closest closing marker.
- [ ] **Consistent Null Handling**: `SubstringExtensions.Between` handles null input, while `StringUtils.GetTextBetweenMarkers` might throw if `origtext` is null.
- [ ] **Exception Swallowing**: `StringUtils.TextToFloat` and `StringUtils.TextToDouble` swallow all exceptions. This should be improved to at least allow optional throwing or better error reporting.

## Improvements

- [ ] **Refactor `ContainsAnyOf` / `IsEqualToAnyOf`**: Use `IEnumerable<string>` or generics to avoid duplication between Array and List overloads in `StringExtensions`.
- [ ] **Use Standard Libraries**:
    - Replace `StringUtils.HexCharToByte` and `StringUtils.ByteArrayToString` with standard .NET methods like `Convert.ToHexString` (if targeting newer .NET) or `BitConverter`.
- [ ] **Naming Consistency**:
    - `StringExtensions.IsNumericsOnly` vs `StringUtils.StringToNumericsOnly`.
- [ ] **Code Optimization**:
    - `StringExtensions.Comment` modifies the array in place, which is fine, but the implementation is verbose.
    - `StringUtils.StringToIdentifier` uses manual replacements; could be optimized with Regex.

## New Features

- [ ] **`ToSlug`**: Add a method to convert strings to URL-friendly slugs.
- [ ] **`Truncate`**: Add a method to truncate strings to a specific length, optionally adding an ellipsis.
- [ ] **`IsUrl`**: Add a method to validate if a string is a valid URL.
- [ ] **Base64 Helpers**: Add methods for Base64 encoding and decoding.
- [ ] **`Reverse`**: Add a string reversal extension method.

## Documentation

- [ ] **Fix README Example**: The README shows an example using `.Between()` but the text claims it demonstrates how to "reverse a string". This is confusing and incorrect.
- [ ] **Update README Features**: The "And more!" section is vague. List more key features like `IsEmail`, `IsAlphaNumeric`, etc.
