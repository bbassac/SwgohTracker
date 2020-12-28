// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.PlayerProfileRequestReflection
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1382BE-46D0-4B2A-9C39-C327EEFCB21C
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;

namespace Ipd.Game.Protocol
{
  public static class PlayerProfileRequestReflection
  {
    private static FileDescriptor descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("ChpQbGF5ZXJQcm9maWxlUmVxdWVzdC5wcm90bxIRaXBkLmdhbWUucHJvdG9j" + "b2wiPAoUUGxheWVyUHJvZmlsZVJlcXVlc3QSEQoJcGxheWVyX2lkGAEgASgJ" + "EhEKCWFsbHlfY29kZRgCIAEoCWIGcHJvdG8z"), new FileDescriptor[0], new GeneratedClrTypeInfo((System.Type[]) null, new GeneratedClrTypeInfo[1]
    {
      new GeneratedClrTypeInfo(typeof (PlayerProfileRequest), (MessageParser) PlayerProfileRequest.Parser, new string[2]
      {
        "PlayerId",
        "AllyCode"
      }, (string[]) null, (System.Type[]) null, (GeneratedClrTypeInfo[]) null)
    }));

    public static FileDescriptor Descriptor => PlayerProfileRequestReflection.descriptor;
  }
}
