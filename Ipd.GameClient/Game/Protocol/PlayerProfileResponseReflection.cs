// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.PlayerProfileResponseReflection
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1382BE-46D0-4B2A-9C39-C327EEFCB21C
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;

namespace Ipd.Game.Protocol
{
  public static class PlayerProfileResponseReflection
  {
    private static FileDescriptor descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("ChtQbGF5ZXJQcm9maWxlUmVzcG9uc2UucHJvdG8SEWlwZC5nYW1lLnByb3Rv" + "Y29sImMKFVBsYXllclByb2ZpbGVSZXNwb25zZRIMCgRuYW1lGAEgASgJEjwK" + "DmFyZW5hX3N0YXR1c2VzGBEgAygLMiQuaXBkLmdhbWUucHJvdG9jb2wuUGxh" + "eWVyQXJlbmFTdGF0dXMiWgoRUGxheWVyQXJlbmFTdGF0dXMSNgoKYXJlbmFf" + "dHlwZRgBIAEoDjIiLmlwZC5nYW1lLnByb3RvY29sLlBsYXllckFyZW5hVHlw" + "ZRINCgVwbGFjZRgCIAEoBSpHCg9QbGF5ZXJBcmVuYVR5cGUSFAoQUGxheWVy" + "QXJlbmFfTm9uZRAAEg4KClNxdWFkQXJlbmEQARIOCgpGbGVldEFyZW5hEAJi" + "BnByb3RvMw=="), new FileDescriptor[0], new GeneratedClrTypeInfo(new System.Type[1]
    {
      typeof (PlayerArenaType)
    }, new GeneratedClrTypeInfo[2]
    {
      new GeneratedClrTypeInfo(typeof (PlayerProfileResponse), (MessageParser) PlayerProfileResponse.Parser, new string[2]
      {
        "Name",
        "ArenaStatuses"
      }, (string[]) null, (System.Type[]) null, (GeneratedClrTypeInfo[]) null),
      new GeneratedClrTypeInfo(typeof (PlayerArenaStatus), (MessageParser) PlayerArenaStatus.Parser, new string[2]
      {
        "ArenaType",
        "Place"
      }, (string[]) null, (System.Type[]) null, (GeneratedClrTypeInfo[]) null)
    }));

    public static FileDescriptor Descriptor => PlayerProfileResponseReflection.descriptor;
  }
}
