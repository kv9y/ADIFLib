# ADIFLib
C# Library to read, parse and write ADIF (version 3.1.0) files.   

This is a simple library for reading and parsing ADIF files, written in Visual Studio Community Edition 2017.  This library is based on .NET Standard version 2.0  ADIF version 3.1.0 is implemented.  Browse here for details regarding this version: https://adif.org/310/ADIF_310.htm

ADIF files are typically used in ham radio applications but could be used by other applications as well.  

ADIFLib simply reads an ADIF file into a C# List of items that represent the data within the ADIF file.  There are many import options that can be used.  Contextural validation of the imported data is not performed.  This library is also capable of writing ADIF formatted files.

ADX formatted files are not yet supported but will be implemented in future versions.

If you need an ADIF parser for your amateur radio program, I hope you enjoy this library.  

73
Ken Linder
KC7RAD
