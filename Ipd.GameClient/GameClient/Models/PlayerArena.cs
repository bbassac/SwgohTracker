// Decompiled with JetBrains decompiler
// Type: Ipd.GameClient.Models.PlayerArena
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1382BE-46D0-4B2A-9C39-C327EEFCB21C
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.GameClient.dll

namespace Ipd.GameClient.Models
{
  public class PlayerArena
  {
    public string PlayerName { get; set; }

    public int SquadArenaRank { get; set; }

    public int FleetArenaRank { get; set; }

    public int PayoutOffsetMinutes { get; set; }
  }
}
