// Decompiled with JetBrains decompiler
// Type: Ipd.GameClient.Exeptions.GameClientApiException
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1382BE-46D0-4B2A-9C39-C327EEFCB21C
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.GameClient.dll

using Ipd.Game.Protocol;
using System;

namespace Ipd.GameClient.Exeptions
{
  public class GameClientApiException : Exception
  {
    public ResponseCode ErrorCode { get; set; }

    public GameClientApiException()
    {
    }

    public GameClientApiException(string message)
      : base(message)
    {
    }

    public GameClientApiException(string message, Exception inner)
      : base(message, inner)
    {
    }
  }
}
