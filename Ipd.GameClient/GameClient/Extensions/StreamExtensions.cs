// Decompiled with JetBrains decompiler
// Type: Ipd.GameClient.Extensions.StreamExtensions
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1382BE-46D0-4B2A-9C39-C327EEFCB21C
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.GameClient.dll

using System.IO;
using System.IO.Compression;

namespace Ipd.GameClient.Extensions
{
  public static class StreamExtensions
  {
    public static byte[] ToByteArray(this Stream stream)
    {
      byte[] buffer = new byte[16384];
      using (MemoryStream memoryStream = new MemoryStream())
      {
        int count;
        while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
          memoryStream.Write(buffer, 0, count);
        return memoryStream.ToArray();
      }
    }

    public static byte[] Unzip(this byte[] gzip)
    {
      using (GZipStream gzipStream = new GZipStream((Stream) new MemoryStream(gzip), CompressionMode.Decompress))
      {
        byte[] buffer = new byte[4096];
        using (MemoryStream memoryStream = new MemoryStream())
        {
          int count;
          do
          {
            count = gzipStream.Read(buffer, 0, 4096);
            if (count > 0)
              memoryStream.Write(buffer, 0, count);
          }
          while (count > 0);
          return memoryStream.ToArray();
        }
      }
    }
  }
}
