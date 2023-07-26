<div align="center">

# SharpMetal
*Metal bindings for C#.*

![](https://img.shields.io/github/actions/workflow/status/IsaacMarovitz/SharpMetal/dotnet.yml?style=for-the-badge)
<!-- ![](https://img.shields.io/github/actions/workflow/status/IsaacMarovitz/SharpMetal/dotnet.yml?style=for-the-badge) -->

<img width="624" alt="primitive" src="https://github.com/IsaacMarovitz/SharpMetal/assets/42140194/478e2341-7c5d-47ad-9638-615b3091cef1">
</div>

## Why?

The .NET ecosystem is very much lacking a good Metal binding package. Existing options are outdated or don't integrate well into cross-platform projects. This project aims to be a complete, up-to-date package that stays true to the original API while making the API easy to use and integrate into C#.

## What can you make with it?

Progress is underway to build a full set of working reimplementations of the metal-cpp samples. Thanks to the generator, the entire Metal API, from compute shaders to raytracing, should be available, although specific things may take further tweaking.

## I want to contribute!

Wonderful! SharpMetal is built with .NET 7.0, and follows a couple of specific guidelines:
- Block Namespaces
- Source Generated P/Invokes
  - `LibraryImport` not `DllImport`
- Use C# types where possible
  - `NSInteger` -> `long` 
  - `NSUInteger` -> `ulong`
- Mark structs and classes with `SupportedOSPlatform` attribute
- SharpMetal is built for macOS primarily, so when there are platform-specific differences, use the macOS option
