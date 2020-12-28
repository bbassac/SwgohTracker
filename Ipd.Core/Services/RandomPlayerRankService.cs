// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.RandomPlayerRankService
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

using Ipd.Core.Interfaces;
using Ipd.Core.Models;
using System;
using System.Threading.Tasks;

namespace Ipd.Core.Services
{
  public class RandomPlayerRankService : IPlayerRankService
  {
    private int _min;
    private int _max;

    public RandomPlayerRankService(int min = 1, int max = 51)
    {
      this._min = min;
      this._max = max;
    }

    public Task<PlayerArenaRank> GetPlayerRank(
      string allyCode,
      AuthResponse auth)
    {
      Random random = new Random();
      return Task.FromResult<PlayerArenaRank>(new PlayerArenaRank()
      {
        PlayerName = allyCode,
        SquadArenaRank = random.Next(this._min, this._max),
        FleetArenaRank = random.Next(this._min, this._max)
      });
    }

    public Task<AuthResponse> Login() => Task.FromResult<AuthResponse>(new AuthResponse());
  }
}
