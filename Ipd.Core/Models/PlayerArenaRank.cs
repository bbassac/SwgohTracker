// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Models.PlayerArenaRank
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

namespace Ipd.Core.Models
{
  public class PlayerArenaRank
  {
    public string PlayerName { get; set; }

    public int SquadArenaRank { get; set; }

    public int FleetArenaRank { get; set; }

    public int PayoutOffsetMinutes { get; set; }
  }
}
