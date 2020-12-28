// Decompiled with JetBrains decompiler
// Type: SimpleTracker.Services.EnvAllyCodesProvider
// Assembly: SimpleTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D0ABE11D-B397-4D3E-B71F-B80A8D542387
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\SimpleTracker.dll

using Ipd.Core.Interfaces;
using Ipd.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTracker.Services
{
  public class EnvAllyCodesProvider : IAllyCodesProvider
  {
    public IList<PlayerSettings> GetAllyCodes()
    {
      List<string> source = new List<string>();
      foreach (object key in (IEnumerable) Environment.GetEnvironmentVariables().Keys)
      {
        string str = key.ToString();
        if (str.StartsWith("AC_"))
          source.Add(str.Replace("AC_", "").Replace("-", "").Trim());
      }
      return (IList<PlayerSettings>) source.Distinct<string>().Take<string>(75).Select<string, PlayerSettings>((Func<string, PlayerSettings>) (ac => new PlayerSettings()
      {
        AllyCode = ac
      })).ToList<PlayerSettings>();
    }

    public Task<IList<PlayerSettings>> GetAllyCodesAsync() => throw new NotImplementedException();
  }
}
