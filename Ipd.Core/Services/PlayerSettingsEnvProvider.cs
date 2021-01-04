// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.PlayerSettingsEnvProvider
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

using Ipd.Core.Extensions;
using Ipd.Core.Interfaces;
using Ipd.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ipd.Core.Services
{
  public class PlayerSettingsEnvProvider : IPlayerSettingsProvider
  {
    private readonly ILog _logger;
    public const string TAGS_ENV_NAME = "DISCORD_TAGS";
    public const string ALLY_CODES_ENV_NAME = "ALLY_CODES";

    public PlayerSettingsEnvProvider(ILog logger) => this._logger = logger;

    public async Task<IList<PlayerSettings>> GetPlayerSettingAsync()
    {
      IEnumerable<string> codes = ((IEnumerable<string>) (Environment.GetEnvironmentVariable("ALLY_CODES") ?? "").Trim().Split(',')).Select<string, string>((Func<string, string>) (ac => ac.Trim().Replace("-", ""))).Distinct<string>();
      Dictionary<string, string> tags = await this.GetTagsAsync();
      IList<PlayerSettings> list = (IList<PlayerSettings>) codes.Select<string, PlayerSettings>((Func<string, PlayerSettings>) (ac => new PlayerSettings()
      {
        AllyCode = ac,
        Name = "",
        DiscordId = tags.ContainsKey(ac) ? tags[ac] : ""
      })).ToList<PlayerSettings>();
      codes = (IEnumerable<string>) null;
      return list;
    }

    private Task<Dictionary<string, string>> GetTagsAsync()
    {
      try
      {
        List<string> stringList = new List<string>();
        foreach (DictionaryEntry environmentVariable in Environment.GetEnvironmentVariables())
        {
          if (environmentVariable.Key.ToString().StartsWith("DISCORD_TAGS"))
          {
            string str = environmentVariable.Value.ToString().Trim();
            if (!string.IsNullOrEmpty(str))
              stringList.AddRange((IEnumerable<string>) str.Split(','));
          }
        }
        Dictionary<string, string> result = new Dictionary<string, string>();
        stringList.ForEach((Action<string>) (t =>
        {
          string[] strArray = t.Trim().Split('|');
          if (strArray.Length != 2)
          {
            this._logger.Log("Invalid tag format in " + t);
          }
          else
          {
            string str = strArray[0].NormalizeAllyCode();
            long resultParse = 0;
                
                if (!long.TryParse(str, out resultParse) || str.Length != 9)
              this._logger.Log("Error: ally code `" + strArray[0] + "` should consist of 9 digits.");
            else
              result[str] = strArray[1];
          }
        }));
        return Task.FromResult<Dictionary<string, string>>(result);
      }
      catch (Exception ex)
      {
        this._logger.Log("Failed to process `TAGS_ENV_NAME` environment variable");
      }
      return Task.FromResult<Dictionary<string, string>>(new Dictionary<string, string>());
    }
  }
}
