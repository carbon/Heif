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

public sealed class HeifImage : IDisposable 
{
  internal Hief(IntPtr[] planePointer, int[] planeStrides) { 
      this.managedBuffer = ptr; 
  } 
  
  HeifPlane GetPlane(HeifChannel channel); 
  
  byte[] ExifData { get; set; }
  
  int Width { get; }
  
  int Height { get; }
  
  void Dispose() { }
}

public enum HeifChannel 
{
    Y,
    Cb,
    Cr
}

public class HeifMetadata {
   public byte[] Data { get; get; } // buffrer
   
   public int Height {get; set; }
   
   public int Width {get; set; }
}
public readonly struct HeifPlane 
{
  public HeifPlane(int stride, IntPtr pointer)
  {
  } 
  public int Stride { get; }
  
  public IntPtr Pointer {get; } 
  
  public Span<byte> Span { get; }
}

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
