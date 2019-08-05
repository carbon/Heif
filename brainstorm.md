Provide a lightweight opensource wrapper around libheif / libde265  exposing buffers 
that can be passed through to ImageSharp, MagicScaler, or any other imaging pipeline.

Build Native DLL (with script) of libheif + libde265

Psedo API for brainstorming.


```csharp
public static class Hief 
{
  public HeifImage Decode(Span<byte> input)
  {

  }

  public HeifMetadata GetMetadata(Span<byte> input) 
  {
    // TBD
  }
}

public sealed class HeifImage : IDisposable 
{
  HeifPlane GetPlane(HeifChannel channel); 
  
  HeifMetadata Metadata { get; }
    
  int Width { get; }
  
  int Height { get; }
  
  void Dispose() { }
}

public enum HeifChannel
{
    Y = 1,
    Cb = 2,
    Cr = 3
}

public class HeifMetadata 
{
   public byte[] ExifData { get; }
   
   public int Height { get; }
   
   public int Width { get; }
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
`
