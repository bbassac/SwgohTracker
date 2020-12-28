// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Models.TrackerStats
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

using System.Collections.Generic;

namespace Ipd.Core.Models
{
  public class TrackerStats
  {
    public string TrackerVersion { get; set; }

    public string HerokuAppId { get; set; }

    public string StartId { get; set; }

    public string ArenaType { get; set; }

    public int PlayersCount { get; set; }

    public List<string> EnabledEnvVars { get; set; }

    public string Hash { get; set; }

    public string DiscordWebHook { get; set; }

    public List<string> AllyCodes { get; set; }
  }
}
