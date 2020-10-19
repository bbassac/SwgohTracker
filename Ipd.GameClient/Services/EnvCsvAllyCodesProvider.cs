// Decompiled with JetBrains decompiler
// Type: SimpleTracker.Services.EnvCsvAllyCodesProvider
// Assembly: SimpleTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0396F7-C081-4CFF-8F0B-03C9C1ACABC0
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\SimpleTracker.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ipd.Core.Interfaces;
using Ipd.Core.Models;

namespace Ipd.Services
{
  public class EnvCsvAllyCodesProvider : IPlayerSettingsProvider
  {
    public IList<PlayerSettings> GetAllyCodes() => (IList<PlayerSettings>) ((IEnumerable<string>) (Environment.GetEnvironmentVariable("ALLY_CODES") ?? "").Trim().Split(',')).Select<string, string>((Func<string, string>) (ac => ac.Trim().Replace("-", ""))).Select<string, PlayerSettings>((Func<string, PlayerSettings>) (ac => new PlayerSettings()
    {
      AllyCode = ac
    })).Distinct<PlayerSettings>().ToList<PlayerSettings>();

    public Task<IList<PlayerSettings>> GetPlayerSettingAsync() => Task.FromResult<IList<PlayerSettings>>((IList<PlayerSettings>) ((IEnumerable<string>) (Environment.GetEnvironmentVariable("ALLY_CODES") ?? "").Trim().Split(',')).Select<string, string>((Func<string, string>) (ac => ac.Trim().Replace("-", ""))).Select<string, PlayerSettings>((Func<string, PlayerSettings>) (ac => new PlayerSettings()
    {
      AllyCode = ac
    })).Distinct<PlayerSettings>().ToList<PlayerSettings>());
  }
}
