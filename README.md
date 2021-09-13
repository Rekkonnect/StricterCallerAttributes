# StricterCallerAttributes

A Roslyn analyzer that prevents substituting optional method parameters with `System.Runtime.CompilerServices.CallerXXX` attributes

# Quick Usage Reference

Upon installing the package of the analyzer, the analyzer works and reports the diagnostics on the appropriate places.

Errors are reported on function arguments with `System.Runtime.CompilerServices.CallerXXX` attributes that are explicitly substituted.

For example:

```csharp
void Function([CallerLineNumber] int lineNumber = default, [CallerFilePath] string filePath = default)
{
}

void AnotherFunction()
{
    Function(0, "");
}
```

Two errors will be reported on the arguments of calling `Function` in `AnotherFunction`.

# Motivation

The `CallerXXX` attributes implement a feature on the compiler that substitutes the arguments with the respective values according to the reference, if they are not expicitly substituted. However, there is a case where the caller invokes the methods and substitutes the arguments with custom values, preventing the compiler from doing its job. This analyzer enforces that the compiler does its job and prevents the user from preventing this behavior.
