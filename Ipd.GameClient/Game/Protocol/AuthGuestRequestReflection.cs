// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.AuthGuestRequestReflection
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C5118B-19F9-4A1A-8B17-10E7D299DD18
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;

namespace Ipd.Game.Protocol
{
  public static class AuthGuestRequestReflection
  {
    private static FileDescriptor descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("ChZBdXRoR3Vlc3RSZXF1ZXN0LnByb3RvEhFpcGQuZ2FtZS5wcm90b2NvbCKz" + "AgoQQXV0aEd1ZXN0UmVxdWVzdBILCgN1aWQYASABKAkSFwoPZGV2aWNlX3Bs" + "YXRmb3JtGAIgASgJEhAKCGxhbmd1YWdlGAMgASgJEhMKC3BsYXllcl9uYW1l" + "GAQgASgJEhEKCWJ1bmRsZV9pZBgFIAEoCRIOCgZyZWdpb24YBiABKAkSJgoe" + "bG9jYWxfdGltZV96b25lX29mZnNldF9taW51dGVzGAcgASgREkUKFXNlc3Np" + "b25fc3RhcnRfY29udGV4dBgIIAEoDjImLmlwZC5nYW1lLnByb3RvY29sLlNl" + "c3Npb25TdGFydENvbnRleHQSQAoSZGV2aWNlX3ByZWZlcmVuY2VzGAkgASgL" + "MiQuaXBkLmdhbWUucHJvdG9jb2wuRGV2aWNlUHJlZmVyZW5jZXMidgoRRGV2" + "aWNlUHJlZmVyZW5jZXMSGQoRcHVzaG5vdGVzX2FsbG93ZWQYASABKAgSFQoN" + "bXVzaWNfc2V0dGluZxgCIAEoCBITCgtzZnhfc2V0dGluZxgDIAEoCBIaChJu" + "ZXR3b3JrX2Nvbm5lY3Rpb24YBCABKAkqUAoTU2Vzc2lvblN0YXJ0Q29udGV4" + "dBIMCghQVVNITk9URRAAEhIKDk5PUk1BTEFQUFNUQVJUEAESCgoGUkVTVU1F" + "EAISCwoHUkVTVEFSVBADYgZwcm90bzM="), new FileDescriptor[0], new GeneratedClrTypeInfo(new System.Type[1]
    {
      typeof (SessionStartContext)
    }, new GeneratedClrTypeInfo[2]
    {
      new GeneratedClrTypeInfo(typeof (AuthGuestRequest), (MessageParser) AuthGuestRequest.Parser, new string[9]
      {
        "Uid",
        "DevicePlatform",
        "Language",
        "PlayerName",
        "BundleId",
        "Region",
        "LocalTimeZoneOffsetMinutes",
        "SessionStartContext",
        "DevicePreferences"
      }, (string[]) null, (System.Type[]) null, (GeneratedClrTypeInfo[]) null),
      new GeneratedClrTypeInfo(typeof (DevicePreferences), (MessageParser) DevicePreferences.Parser, new string[4]
      {
        "PushnotesAllowed",
        "MusicSetting",
        "SfxSetting",
        "NetworkConnection"
      }, (string[]) null, (System.Type[]) null, (GeneratedClrTypeInfo[]) null)
    }));

    public static FileDescriptor Descriptor => AuthGuestRequestReflection.descriptor;
  }
}
