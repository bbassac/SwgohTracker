// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.StatsService
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

using Ipd.Core.Interfaces;
using Ipd.Core.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Ipd.Core.Services
{
  public class StatsService : IStatsService
  {
    public static string ClientVersion = "beta-21";

    public static List<string> EnvironmentVariables { get; } = new List<string>()
    {
      "ARENA_TYPE",
      "DISCORD_WEB_HOOK",
      "GAME_CLIENT_VERSION",
      "ALLY_CODES",
      "DISCORD_TAGS",
      "ALLY_CODES_URL"
    };

    private static List<string> GetListOfActiveEnvVariables()
    {
      List<string> activeVars = new List<string>();
      StatsService.EnvironmentVariables.ForEach((Action<string>) (v =>
      {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(v)))
          return;
        activeVars.Add(v);
      }));
      return activeVars;
    }

    public static string CreateMD5(string input)
    {
      using (MD5 md5 = MD5.Create())
      {
        byte[] bytes = Encoding.ASCII.GetBytes(input);
        byte[] hash = md5.ComputeHash(bytes);
        StringBuilder stringBuilder = new StringBuilder();
        for (int index = 0; index < hash.Length; ++index)
          stringBuilder.Append(hash[index].ToString("X2"));
        return stringBuilder.ToString();
      }
    }

    private string GetWebHookUrlHash()
    {
      try
      {
        return StatsService.CreateMD5(Environment.GetEnvironmentVariable("DISCORD_WEB_HOOK") ?? "");
      }
      catch (Exception ex)
      {
      }
      return "FAILED_TO_GENERATE_HASH";
    }

    private string GetWebHookUrl()
    {
      try
      {
        return Environment.GetEnvironmentVariable("DISCORD_WEB_HOOK") ?? "";
      }
      catch (Exception ex)
      {
      }
      return "FAILED_TO_GET_DISCORD_WEB_HOOK";
    }

    public void PostStats(string arenaType, int totalPlayersCount, List<string> allyCodes)
    {
      if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("DISABLE_ANALYTICS") ?? ""))
        return;
      try
      {
        string webHookUrlHash = this.GetWebHookUrlHash();
        string webHookUrl = this.GetWebHookUrl();
        TrackerStats trackerStats = new TrackerStats()
        {
          EnabledEnvVars = StatsService.GetListOfActiveEnvVariables(),
          ArenaType = arenaType,
          StartId = Guid.NewGuid().ToString(),
          PlayersCount = totalPlayersCount,
          TrackerVersion = StatsService.ClientVersion,
          Hash = webHookUrlHash,
          DiscordWebHook = webHookUrl
        };
        RestClient client = new RestClient("https://swgoh-tracker-stats.herokuapp.com");
        RestRequest restRequest1 = new RestRequest("stats");
        restRequest1.AddJsonBody((object) trackerStats);
        RestRequest restRequest2 = restRequest1;
        CancellationToken cancellationToken = new CancellationToken();
        client.PostAsync<TrackerStats>((IRestRequest) restRequest2, cancellationToken).ConfigureAwait(false);
      }
      catch (Exception ex)
      {
      }
    }
  }
}
