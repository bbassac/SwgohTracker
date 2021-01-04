// Decompiled with JetBrains decompiler
// Type: SimpleTracker.Program
// Assembly: SimpleTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D0ABE11D-B397-4D3E-B71F-B80A8D542387
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\SimpleTracker.dll

using Ipd.Core.Interfaces;
using Ipd.Core.Models;
using Ipd.Core.Services;
using Ipd.GameClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTracker.Infrastructure;
using SimpleTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTracker
{
  internal class Program
  {
    private static readonly ILog Logger;

    static Program()
    {


            //Environment.SetEnvironmentVariable("ALLY_CODES", Environment.GetEnvironmentVariable("ALLY_CODES", EnvironmentVariableTarget.User));
            //Environment.SetEnvironmentVariable("ARENA_TYPE", Environment.GetEnvironmentVariable("ARENA_TYPE", EnvironmentVariableTarget.User));
           // Environment.SetEnvironmentVariable("DISCORD_TAGS", Environment.GetEnvironmentVariable("DISCORD_TAGS", EnvironmentVariableTarget.User));
           // Environment.SetEnvironmentVariable("DISCORD_WEB_HOOK", Environment.GetEnvironmentVariable("DISCORD_WEB_HOOK", EnvironmentVariableTarget.User));
           // Program.Logger.Log("ALLY_CODES: " + Environment.GetEnvironmentVariable("ALLY_CODES"));
           // Program.Logger.Log("ARENA_TYPE: " + Environment.GetEnvironmentVariable("ARENA_TYPE"));
          //  Program.Logger.Log("DISCORD_TAGS: " + Environment.GetEnvironmentVariable("DISCORD_TAGS" ));
          //  Program.Logger.Log("DISCORD_WEB_HOOK: " + Environment.GetEnvironmentVariable("DISCORD_WEB_HOOK" ));


            string str = (Environment.GetEnvironmentVariable("LOGGER_TYPE") ?? "CONSOLE").Trim();
      string webHook = (Environment.GetEnvironmentVariable("LOGGER_HOOK") ?? "").Trim();
      Program.Logger = !str.Equals("DISCORD", StringComparison.InvariantCultureIgnoreCase) || string.IsNullOrEmpty(webHook) ? (ILog) new ConsoleLogger() : (ILog) new DiscordLogger((IDiscordMessenger) new DiscordMessenger(webHook));
      Program.Logger.Log("Logger type: " + str);
      Program.Logger.Log("Tracker version:" + StatsService.ClientVersion);
    }

    public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureServices((Action<HostBuilderContext, IServiceCollection>) ((hostContext, services) => ServiceCollectionServiceExtensions.AddSingleton<IHostedService>(services, (Func<IServiceProvider, IHostedService>) (serviceProvider =>
    {
      Tracker tracker = Program.InitTracker();
      tracker.PostStats();
        return (IHostedService)new TrackerJob(tracker, Program.Logger);
    }))));

    private static void Main(string[] args)
    {
      if (string.IsNullOrEmpty((Environment.GetEnvironmentVariable("DISCORD_WEB_HOOK") ?? "").Trim()))
        Program.Logger.Log("env variable DISCORD_WEB_HOOK not found");
      else
        HostingAbstractionsHostExtensions.Run(Program.CreateHostBuilder(args).Build());
    }

    private static Tracker InitTracker()
    {
      string str = Environment.GetEnvironmentVariable("GAME_CLIENT_VERSION") ?? "99.99.99";
      string url = (Environment.GetEnvironmentVariable("ALLY_CODES_URL") ?? "").Trim();
      ArenaType arenaType = (Environment.GetEnvironmentVariable("ARENA_TYPE") ?? "SQUAD").Trim().Equals("FLEET") ? ArenaType.Fleet : ArenaType.Squad;
      Program.Logger.Log(string.Format("Arena type: {0}", (object) arenaType));
      string webHook = (Environment.GetEnvironmentVariable("DISCORD_WEB_HOOK") ?? "").Trim();
      if (string.IsNullOrEmpty(webHook))
        Program.Logger.Log("ENV variable DISCORD_WEB_HOOK not found");
      IPlayerSettingsProvider playerSettingsProvider;
      if (!string.IsNullOrEmpty(url))
      {
        Program.Logger.Log("Ally codes and tags will be loaded from the provided url");
        playerSettingsProvider = (IPlayerSettingsProvider) new PlayerSettingsUrlProvider(url, Program.Logger);
      }
      else
      {
        playerSettingsProvider = (IPlayerSettingsProvider) new PlayerSettingsEnvProvider(Program.Logger);
        IList<PlayerSettings> result = playerSettingsProvider.GetPlayerSettingAsync().Result;
        List<string> list1 = result.Select<PlayerSettings, string>((Func<PlayerSettings, string>) (ac => ac.AllyCode)).ToList<string>();
        Program.Logger.Log(string.Format("Provided ally codes from environment: #{0}", (object) list1.Count));
        Program.Logger.Log(string.Join<string>(',', (IEnumerable<string>) list1));
        List<string> list2 = result.Select<PlayerSettings, string>((Func<PlayerSettings, string>) (x => x.DiscordId)).ToList<string>();
        Program.Logger.Log(string.Format("Provided discord tags: #{0}", (object) list2.Count));
        Program.Logger.Log(string.Join<string>(',', (IEnumerable<string>) list2));
      }
      return new Tracker((IDiscordMessenger) new DiscordMessenger(webHook), playerSettingsProvider, (IArenaRankStorage) new StaticArenaRankStorage(), (IPlayerRankService) new PlayerRankService((IGameClient) new Ipd.GameClient.GameClient("ipd-arena-tracker:" + StatsService.ClientVersion)
      {
        GameClientVersion = str
      }), Program.Logger, (ITagsProvider) new EnvTagsProvider(Program.Logger), arenaType, (IStatsService) new StatsService());
    }
  }
}
