// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.AuthGuestResponseReflection
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C5118B-19F9-4A1A-8B17-10E7D299DD18
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;

namespace Ipd.Game.Protocol
{
  public static class AuthGuestResponseReflection
  {
    private static FileDescriptor descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("ChdBdXRoR3Vlc3RSZXNwb25zZS5wcm90bxIRaXBkLmdhbWUucHJvdG9jb2wi" + "OAoRQXV0aEd1ZXN0UmVzcG9uc2USDwoHYXV0aF9pZBgBIAEoCRISCgphdXRo" + "X3Rva2VuGAIgASgJYgZwcm90bzM="), new FileDescriptor[0], new GeneratedClrTypeInfo((System.Type[]) null, new GeneratedClrTypeInfo[1]
    {
      new GeneratedClrTypeInfo(typeof (AuthGuestResponse), (MessageParser) AuthGuestResponse.Parser, new string[2]
      {
        "AuthId",
        "AuthToken"
      }, (string[]) null, (System.Type[]) null, (GeneratedClrTypeInfo[]) null)
    }));

    public static FileDescriptor Descriptor => AuthGuestResponseReflection.descriptor;
  }
}
