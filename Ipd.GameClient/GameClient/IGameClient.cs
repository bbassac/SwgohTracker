// Decompiled with JetBrains decompiler
// Type: Ipd.GameClient.IGameClient
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C5118B-19F9-4A1A-8B17-10E7D299DD18
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.GameClient.dll

using Ipd.Game.Protocol;
using Ipd.GameClient.Models;

namespace Ipd.GameClient
{
  public interface IGameClient
  {
    AuthGuestResponse GetGuestAuth();

    PlayerArena GetPlayerArenaRanks(string playerAllyCode, AuthGuestResponse auth);
  }
}
