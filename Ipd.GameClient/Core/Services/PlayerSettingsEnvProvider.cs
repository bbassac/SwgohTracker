// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.PlayerSettingsEnvProvider
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10FD981A-2B33-4DE6-8525-B5BDF64E7AF8
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.Core.dll

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
      return (IList<PlayerSettings>) codes.Select<string, PlayerSettings>((Func<string, PlayerSettings>) (ac => new PlayerSettings()
      {
        AllyCode = ac,
        Name = "",
        DiscordId = tags.ContainsKey(ac) ? tags[ac] : ""
      })).ToList<PlayerSettings>();
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
            long result = 0;
            if (!long.TryParse(str, out result) || str.Length != 9)
              this._logger.Log("Error: ally code `" + strArray[0] + "` should consist of 9 digits.");
            
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
