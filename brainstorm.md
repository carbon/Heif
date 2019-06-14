Provide a lightweight opensource wrapper around libheif / libde265  exposing buffers 
that can be passed through to ImageSharp, MagicScaler, or any other imaging pipeline.

Build Native DLL (with script) of libheif + libde265

Psedo API for brainstorming.

$2,500 USD sponsorship.


```csharp
public static class Hief {
  public HeifBitmap Decode(Stream stream) {

  }

  public HeifMetadata GetMetadata(Stream stream) {
    // TBD
  }
}

public class HeifBitmap : IDisposable {


  public Hief(IntPtr ptr) { 
      this.managedBuffer = ptr;
  } 
  
  Span<byte> Data { get; } // bytes

  PixelFormat PixelFormat { get; } 

  int Width { get; }
  
  int Height { get; }

  int Stride { get; } // in bytes
}

// v2: Do we have to read the entire buffer in memory? Can we lazily decode regions
// v2: Consder color spaces / pixel format

```

Consider using https://github.com/xoofx/CppAst to parse raw AST and generate csharp introp code

https://github.com/strukturag/libheif/blob/master/libheif/heif.h

```
Introp { 
  HeifError { code, subcode }
  HeifErrorCode
  HeifSuberrorCode
  HeifBrand
  HeifReader
  HeifColorPrimaries
  HeifTransferCharacteristics
  HeifMatrixCoefficients
  HeifColorProfileNclx
  HeifCompressionFormat
  HeifChroma
  HeifColorspace
  HeifChannel
  HeifProgressStep
  HeifDecodingOptions
  HeifContext
}
...
`


