// Decompiled with JetBrains decompiler
// Type: SimpleTracker.Services.StaticArenaRankStorage
// Assembly: SimpleTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0396F7-C081-4CFF-8F0B-03C9C1ACABC0
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\SimpleTracker.dll

using Ipd.Core.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleTracker.Services
{
  public class StaticArenaRankStorage : IArenaRankStorage
  {
    private static readonly IDictionary<string, int> _storage = (IDictionary<string, int>) new ConcurrentDictionary<string, int>();

    public int? GetRank(string allyCode) => StaticArenaRankStorage._storage.ContainsKey(allyCode) ? new int?(StaticArenaRankStorage._storage[allyCode]) : new int?();

    public IDictionary<string, int> GetRanks() => (IDictionary<string, int>) new Dictionary<string, int>(StaticArenaRankStorage._storage);

    public Task<IDictionary<string, int>> GetRanksAsync() => throw new NotImplementedException();

    public void SaveRank(string allyCode, int rank) => StaticArenaRankStorage._storage[allyCode] = rank;

    public Task SaveRanksAsync(IDictionary<string, int> ranks) => throw new NotImplementedException();
  }
}
