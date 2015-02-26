# C# Base Media File Format Library

## Project Description

C# parser libraries and tools for a variety of common media containers including MP4, MOV, ISMV, 3GP, DCF, JP2, MJ2, M21, DVB, F4V and TS.

Parses ISO Base Media File Format files including QuickTime (.mov, .mp4, .m4v, .m4a), Microsoft Smooth Streaming (.ismv, .isma, .ismc), JPEG2000 (.jp2, .jpf, .jpx), Motion JPEG2000 (.mj2, .mjp2), 3GPP/3GPP2 (.3gp, .3g2), Adobe Flash (.f4v, .f4p, .f4a, .f4b) and other conforming format extensions.

Additional support is underway for MPEG TS and Matroska.

**NOTE:** This library only parses the container format. It can be used for muxing, demuxing, and other manipulations of the container. It does NOT decode/play the contained track bitstreams.

**IMPORTANT:** This solution requires that Microsoft's [Portable Library Tools](http://visualstudiogallery.msdn.microsoft.com/b0e0b5e9-e138-410b-ad10-00cb3caf4981/) be installed for the project to load in Visual Studio 2010. This allows the library to be used with .NET Framework 4, Silverlight 4, Windows Phone 7 and Xbox 360 applications. Visual Studio 2011 has Portable Library support built in.

## About

This library serializes and deserializes Base Media File Format (ISO 14496-12) files and streams. 

Boxes (or Atoms for those more familiar with the QuickTime format BMFF is based on) that have a known and supported FourCC are deserialized into strongly typed classes with exposed properties for the encoded information. Unknown Boxes are deserialized gracefully as a generic UnknownBox type from which the contents can be read as a byte stream.

All of the standard Container Boxes are implemented. Most of the common Box types are implemented especially those necessary for implementing qt-faststart, locating chunks for Smooth Streaming and loading JPEG2000 codestreams.

Work is currently underway to unify the BmffReader/BmffWriter API (this project grew out of three others that did the bare minimum necessary for their task) and we'll be systematically adding the remaining Box types.

## Samples

BmffViewer is a sample WPF application that lets you open any BMFF file and displays a tree of Boxes and a property grid for the selected Box. It's pretty rough at this point but it loads any well formed file (even with many unknown Box types) without crashing and will let you view any box's properties and binary content. It will also allow you to convert a file to progressive ordering like qt-faststart.

Additional samples splitting and serving MS Smooth Streaming from datasources other than disk (like Windows Azure Blobs) will be added as they are converted to use the new unified API. 

The J2KSharp library and samples in the CSJ2K project here on CodePlex will also be making use of this library soon.

## Points of Interest:

ConstrainedStream is a stream wrapper class that lets you push and pop nested byte ranges and prevents the application from reading outside the bounds of the current range on the stack. It's designed to wrap both seekable and unseekable streams and adds byte counting for Stream.Position to unseekable streams. Streams are wrapped with the ConstrainedStream.WrapStream(Stream baseStream) static method which either casts it to ConstrainedStream if it is already wrapped or wraps it in a new ConstrainedStream.

BoxAttribute allows you to mark a class as implementing a specific FourCC (specified as a string literal or unsigned integer) or UUID and additionally holds a description field. This allows the library to locate all supported types within the Assembly and add them to its Activator. Additional Boxes defined in an extension assembly can be loaded with the Box.LoadBoxTypesFromAssembly(Assembly assembly) static method.

BoxToDescriptionConverter in the BmffViewer project is a WPF IValueConverter and MarkupExtension that allows you to bind the BoxAttribute description of a given Box.

ObjectPropertiesToCollectionViewConverter in the BmffViewer project is a WPF IValueConverter and MarkupExtension that allows you to bind a ListView(GridView) to reflected properties on an object grouped by the base class that implements each property.
