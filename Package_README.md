## Why?

The .NET ecosystem is very much lacking a good Metal binding package. Existing options are outdated or don't integrate well into cross-platform projects. This project aims to be a complete, up-to-date package that stays true to the original API while making the API easy to use and integrate into C#.

## What can you make with it?

Progress is underway to build a full set of working reimplementations of the metal-cpp samples. Thanks to the generator, the entire Metal API, from compute shaders to raytracing, should be available, although specific things may take further tweaking.

## How do you generate the bindings?

1. Download the latest headers from [Apple's website](https://developer.apple.com/metal/cpp/).
2. Copy all the headers to `SharpMetal.Generator/Headers/`, make sure to remove the `SingleHeader` folder.
3. Find and replace `#include <Foundation/Foundation.hpp>` with `#include "../Foundation/Foundation.hpp"`, this is due to an including problem, if you can find a nicer way to fix this please let me know.
4. Build and run `SharpMetal.Generator`.

## I want to contribute!

Wonderful! SharpMetal is built with .NET 8.0, and follows a couple of specific guidelines:
- Block Namespaces
- Source Generated P/Invokes
  - `LibraryImport` not `DllImport`
- Use C# types where possible
  - `NSInteger` -> `long`
  - `NSUInteger` -> `ulong`
- Mark structs and classes with `SupportedOSPlatform` attribute
- SharpMetal is built for macOS primarily, so when there are platform-specific differences, use the macOS option
