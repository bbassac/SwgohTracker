// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.SessionStartContext
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C5118B-19F9-4A1A-8B17-10E7D299DD18
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.GameClient.dll

using Google.Protobuf.Reflection;

namespace Ipd.Game.Protocol
{
  public enum SessionStartContext
  {
    [OriginalName("PUSHNOTE")] Pushnote,
    [OriginalName("NORMALAPPSTART")] Normalappstart,
    [OriginalName("RESUME")] Resume,
    [OriginalName("RESTART")] Restart,
  }
}
