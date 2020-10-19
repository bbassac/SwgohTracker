// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.PlayerRankService
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10FD981A-2B33-4DE6-8525-B5BDF64E7AF8
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.Core.dll

using Ipd.Core.Interfaces;
using Ipd.Core.Models;
using Ipd.Game.Protocol;
using Ipd.GameClient;
using Ipd.GameClient.Models;
using System.Threading.Tasks;

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
      PlayerArena playerArenaRanks = this.Client.GetPlayerArenaRanks(allyCode, new AuthGuestResponse()
      {
        AuthId = auth.AuthId,
        AuthToken = auth.AuthToken
      });
      return Task.FromResult<PlayerArenaRank>(new PlayerArenaRank()
      {
        PlayerName = playerArenaRanks.PlayerName,
        FleetArenaRank = playerArenaRanks.FleetArenaRank,
        SquadArenaRank = playerArenaRanks.SquadArenaRank
      });
    }

    public Task<AuthResponse> Login()
    {
      AuthGuestResponse guestAuth = this.Client.GetGuestAuth();
      return Task.FromResult<AuthResponse>(new AuthResponse()
      {
        AuthId = guestAuth.AuthId,
        AuthToken = guestAuth.AuthToken
      });
    }
  }
}
