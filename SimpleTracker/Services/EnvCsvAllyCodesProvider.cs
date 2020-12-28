// Decompiled with JetBrains decompiler
// Type: SimpleTracker.Services.EnvCsvAllyCodesProvider
// Assembly: SimpleTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D0ABE11D-B397-4D3E-B71F-B80A8D542387
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\SimpleTracker.dll

using Ipd.Core.Interfaces;
using Ipd.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTracker.Services
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
