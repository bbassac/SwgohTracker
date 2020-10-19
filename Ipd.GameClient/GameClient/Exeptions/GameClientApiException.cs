// Decompiled with JetBrains decompiler
// Type: Ipd.GameClient.Exeptions.GameClientApiException
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C5118B-19F9-4A1A-8B17-10E7D299DD18
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.GameClient.dll

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
