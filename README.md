# NeoSystems.StringUtils

NeoSystems.StringUtils is a .NET library for string manipulation and operations. It provides a wide range of useful methods for working with strings in .NET applications.

## Installation

To install NeoSystems.StringUtils, you can use the NuGet package manager:

shell

PM> Install-Package NeoSystems.StringUtils

Usage

Here's a simple example of how to use the library to reverse a string:

``` csharp

using NeoSystems.StringUtils;

...

string input = "Hello, my good world!";
string between = input.Between("Hello, ","world!");

Console.WriteLine(between); // Output: "my good"
```

## Features

* Get text between two strings
* Get text after string
* Get text before string
* And more!

## Documentation

Full documentation and API reference can be found on the project website.

## Contributing

We welcome contributions! If you find a bug or have an idea for a new feature, please open an issue. For code contributions, please fork the repository and submit a pull request.

## License

NeoSystems.StringUtils is licensed under the MIT license. See **LICENSE** for details.
