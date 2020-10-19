// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Interfaces.IArenaRankStorage
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10FD981A-2B33-4DE6-8525-B5BDF64E7AF8
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.Core.dll

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ipd.Core.Interfaces
{
  public interface IArenaRankStorage
  {
    int? GetRank(string allyCode);

    void SaveRank(string allyCode, int rank);

    IDictionary<string, int> GetRanks();

    Task<IDictionary<string, int>> GetRanksAsync();

    Task SaveRanksAsync(IDictionary<string, int> ranks);
  }
}
