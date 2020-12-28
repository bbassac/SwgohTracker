// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.PlayerRankService
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

using System.Threading.Tasks;
using Ipd.Core.Interfaces;
using Ipd.Core.Models;
using Ipd.GameClient;
using Ipd.GameClient.Models;

namespace Ipd.Core.Services
{
  public class PlayerRankService : IPlayerRankService
  {
    private IGameClient Client { get; set; }

    public PlayerRankService(IGameClient client) => this.Client = client;

    public Task<PlayerArenaRank> GetPlayerRank(
      string allyCode,
      AuthResponse auth)
    {
      PlayerArena playerArenaRanks = this.Client.GetSlimPlayerArenaRanks(allyCode);
      return Task.FromResult<PlayerArenaRank>(new PlayerArenaRank()
      {
        PlayerName = playerArenaRanks.PlayerName,
        FleetArenaRank = playerArenaRanks.FleetArenaRank,
        SquadArenaRank = playerArenaRanks.SquadArenaRank,
        PayoutOffsetMinutes = playerArenaRanks.PayoutOffsetMinutes
      });
    }
  }
}
