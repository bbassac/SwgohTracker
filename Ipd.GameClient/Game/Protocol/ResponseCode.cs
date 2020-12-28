// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.ResponseCode
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1382BE-46D0-4B2A-9C39-C327EEFCB21C
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.GameClient.dll

using Google.Protobuf.Reflection;

namespace Ipd.Game.Protocol
{
  public enum ResponseCode
  {
    [OriginalName("NONE")] None = 0,
    [OriginalName("OK")] Ok = 1,
    [OriginalName("ERROR")] Error = 2,
    [OriginalName("SERVERERROR")] Servererror = 3,
    [OriginalName("SESSIONEXPIRED")] Sessionexpired = 4,
    [OriginalName("AUTHFAILED")] Authfailed = 5,
    [OriginalName("RATEEXCEEDED")] Rateexceeded = 6,
    [OriginalName("SERVERUNAVAILABLE")] Serverunavailable = 7,
    [OriginalName("INVALIDREQUEST")] Invalidrequest = 8,
    [OriginalName("INVALIDDATA")] Invaliddata = 9,
    [OriginalName("LEADERBOARDMATCHMAKINGERROR")] Leaderboardmatchmakingerror = 10, // 0x0000000A
    [OriginalName("UNAUTHORIZED")] Unauthorized = 11, // 0x0000000B
    [OriginalName("SUSPENDED")] Suspended = 12, // 0x0000000C
    [OriginalName("SERVEROUTAGE")] Serveroutage = 13, // 0x0000000D
    [OriginalName("NETWORKUNAVAILABLE")] Networkunavailable = 20, // 0x00000014
    [OriginalName("SEQUENCEHIGH")] Sequencehigh = 30, // 0x0000001E
    [OriginalName("SEQUENCELOW")] Sequencelow = 31, // 0x0000001F
    [OriginalName("RECORDNOTFOUND")] Recordnotfound = 32, // 0x00000020
    [OriginalName("EVENTNOTFOUND")] Eventnotfound = 33, // 0x00000021
    [OriginalName("INSUFFICIENTRESOURCES")] Insufficientresources = 40, // 0x00000028
    [OriginalName("INVALIDCLIENTVERSION")] Invalidclientversion = 50, // 0x00000032
    [OriginalName("FORCECLIENTRESTART")] Forceclientrestart = 51, // 0x00000033
    [OriginalName("INCOMPATIBLEDEVICE")] Incompatibledevice = 52, // 0x00000034
    [OriginalName("ACCOUNTUPDATED")] Accountupdated = 53, // 0x00000035
    [OriginalName("INVALIDRECEIPT")] Invalidreceipt = 60, // 0x0000003C
    [OriginalName("PAYMENTPENDING")] Paymentpending = 61, // 0x0000003D
    [OriginalName("OPPONENTINBATTLE")] Opponentinbattle = 71, // 0x00000047
    [OriginalName("UNDERATTACK")] Underattack = 72, // 0x00000048
    [OriginalName("OPPONENTDATASTALE")] Opponentdatastale = 73, // 0x00000049
    [OriginalName("BATTLETIMEDOUT")] Battletimedout = 74, // 0x0000004A
    [OriginalName("PLAYERRANKSTALE")] Playerrankstale = 75, // 0x0000004B
  }
}
