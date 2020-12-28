// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.SlimPlayerProfileReflection
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1382BE-46D0-4B2A-9C39-C327EEFCB21C
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;

namespace Ipd.Game.Protocol
{
  public static class SlimPlayerProfileReflection
  {
    private static FileDescriptor descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("ChdTbGltUGxheWVyUHJvZmlsZS5wcm90bxIRaXBkLmdhbWUucHJvdG9jb2wi" + "RQodU2xpbVBsYXllckFyZW5hUHJvZmlsZVJlcXVlc3QSEQoJcGxheWVyX2lk" + "GAEgASgJEhEKCWFsbHlfY29kZRgCIAEoCSLFAQoeU2xpbVBsYXllckFyZW5h" + "UHJvZmlsZVJlc3BvbnNlEgwKBG5hbWUYASABKAkSDQoFbGV2ZWwYAiABKAUS" + "EQoJYWxseV9jb2RlGAMgASgDEhEKCXBsYXllcl9pZBgEIAEoCRI4CgtwdnBf" + "cHJvZmlsZRgFIAMoCzIjLmlwZC5nYW1lLnByb3RvY29sLlBsYXllclB2cFBy" + "b2ZpbGUSJgoebG9jYWxfdGltZV96b25lX29mZnNldF9taW51dGVzGAYgASgR" + "ImQKEFBsYXllclB2cFByb2ZpbGUSMAoDdGFiGAEgASgOMiMuaXBkLmdhbWUu" + "cHJvdG9jb2wuUGxheWVyUHJvZmlsZVRhYhIMCgRyYW5rGAIgASgFEhAKCGV2" + "ZW50X2lkGAQgASgJKncKEFBsYXllclByb2ZpbGVUYWISHAoYUGxheWVyUHJv" + "ZmlsZVRhYl9ERUZBVUxUEAASFwoTUFJPRklMRVBWUENIQVJBQ1RFUhABEhIK" + "DlBST0ZJTEVQVlBTSElQEAISGAoUUFJPRklMRVBWUFRPVVJOQU1FTlQQA2IG" + "cHJvdG8z"), new FileDescriptor[0], new GeneratedClrTypeInfo(new System.Type[1]
    {
      typeof (PlayerProfileTab)
    }, new GeneratedClrTypeInfo[3]
    {
      new GeneratedClrTypeInfo(typeof (SlimPlayerArenaProfileRequest), (MessageParser) SlimPlayerArenaProfileRequest.Parser, new string[2]
      {
        "PlayerId",
        "AllyCode"
      }, (string[]) null, (System.Type[]) null, (GeneratedClrTypeInfo[]) null),
      new GeneratedClrTypeInfo(typeof (SlimPlayerArenaProfileResponse), (MessageParser) SlimPlayerArenaProfileResponse.Parser, new string[6]
      {
        "Name",
        "Level",
        "AllyCode",
        "PlayerId",
        "PvpProfile",
        "LocalTimeZoneOffsetMinutes"
      }, (string[]) null, (System.Type[]) null, (GeneratedClrTypeInfo[]) null),
      new GeneratedClrTypeInfo(typeof (PlayerPvpProfile), (MessageParser) PlayerPvpProfile.Parser, new string[3]
      {
        "Tab",
        "Rank",
        "EventId"
      }, (string[]) null, (System.Type[]) null, (GeneratedClrTypeInfo[]) null)
    }));

    public static FileDescriptor Descriptor => SlimPlayerProfileReflection.descriptor;
  }
}
