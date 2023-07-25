# SharpMetal

Metal bindings for C#.

<img width="1552" alt="Screenshot 2023-07-25 at 07 30 19" src="https://github.com/IsaacMarovitz/SharpMetal/assets/42140194/558e95e2-e91f-454c-9ac6-6917692112bf">

## Why?

The .NET ecosystem is very much lacking a good Metal binding package. Existing options are out of date, or don't integrate well into cross-platform projects. This project aims to be a complete, up to date, package that stays true to the original API, while making the API easy to use and integrate into C#.

## I want to contribute!

Wonderful! SharpMetal is built with .NET 7.0, and follows a couple of specific guidelines:
- Block Namespaces
- Source Generated P/Invokes
  - `LibraryImport` not `DllImport`
- Use C# types where possible
  - `NSInteger` -> `long` 
  - `NSUInteger` -> `ulong`
- Mark structs and classes with `SupportedOSPlatform` attribute
- SharpMetal is built for macOS primarily so when there are platform specific differences, use the macOS option
