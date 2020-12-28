// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.PlayerSettingsUrlProvider
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

using Ipd.Core.Interfaces;
using Ipd.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ipd.Core.Services
{
  public class PlayerSettingsUrlProvider : IPlayerSettingsProvider
  {
    private ILog _logger;
    private string _url;

    public PlayerSettingsUrlProvider(string url, ILog logger)
    {
      this._url = url;
      this._logger = logger;
    }

    public async Task<IList<PlayerSettings>> GetPlayerSettingAsync()
    {
      using (HttpClient httpClient = new HttpClient())
      {
        HttpResponseMessage async = await httpClient.GetAsync(this._url);
        if (!async.IsSuccessStatusCode)
        {
          this._logger.Log(string.Format("[PlayerSettingsProvider]:Failed to load player settings. Status code ({0}).", (object) async.StatusCode));
          return (IList<PlayerSettings>) new List<PlayerSettings>();
        }
        try
        {
          List<PlayerSettings> playerSettingsList = JsonConvert.DeserializeObject<List<PlayerSettings>>(await async.Content.ReadAsStringAsync());
          playerSettingsList.ForEach((Action<PlayerSettings>) (s => s.DiscordId = (s.DiscordId ?? "").Trim()));
          return (IList<PlayerSettings>) playerSettingsList;
        }
        catch (Exception ex)
        {
          this._logger.Log("[PlayerSettingsProvider]:Failed to deserialize player settings: " + ex.Message);
          return (IList<PlayerSettings>) new List<PlayerSettings>();
        }
      }
    }
  }
}
