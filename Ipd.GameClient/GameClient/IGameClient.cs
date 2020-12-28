// Decompiled with JetBrains decompiler
// Type: Ipd.GameClient.IGameClient
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1382BE-46D0-4B2A-9C39-C327EEFCB21C
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.GameClient.dll

using Ipd.GameClient.Models;

namespace Ipd.GameClient
{
  public interface IGameClient
  {
    PlayerArena GetSlimPlayerArenaRanks(string playerAllyCode);
  }
}
