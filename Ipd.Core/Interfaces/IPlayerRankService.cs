// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Interfaces.IPlayerRankService
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10FD981A-2B33-4DE6-8525-B5BDF64E7AF8
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.Core.dll

using Ipd.Core.Models;
using System.Threading.Tasks;

namespace Ipd.Core.Interfaces
{
  public interface IPlayerRankService
  {
    Task<AuthResponse> Login();

    Task<PlayerArenaRank> GetPlayerRank(string allyCode, AuthResponse auth);
  }
}
