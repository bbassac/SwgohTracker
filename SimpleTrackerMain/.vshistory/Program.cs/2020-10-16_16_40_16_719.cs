// Decompiled with JetBrains decompiler
// Type: SimpleTracker.Program
// Assembly: SimpleTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0396F7-C081-4CFF-8F0B-03C9C1ACABC0
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\SimpleTracker.dll

using Ipd.Core.Interfaces;
using Ipd.Core.Models;
using Ipd.Core.Services;
using Ipd.GameClient;
using SimpleTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SimpleTracker
{
    internal class Program
    {
        private static readonly ILog Logger;

        static Program()
        {
            Environment.SetEnvironmentVariable("ARENA_TYPE", "SQUAD");
            Environment.SetEnvironmentVariable("ALLY_CODE", "386782543");
            string str = (Environment.GetEnvironmentVariable("LOGGER_TYPE") ?? "CONSOLE").Trim();
            string webHook = (Environment.GetEnvironmentVariable("LOGGER_HOOK") ?? "").Trim();
            Program.Logger =
                !str.Equals("DISCORD", StringComparison.InvariantCultureIgnoreCase) || string.IsNullOrEmpty(webHook)
                    ? (ILog) new ConsoleLogger()
                    : (ILog) new DiscordLogger((IDiscordMessenger) new DiscordMessenger(webHook));
            Program.Logger.Log("Logger type: " + str);
        }

        private static void Main(string[] args)
        {
            if (string.IsNullOrEmpty((Environment.GetEnvironmentVariable("DISCORD_WEB_HOOK") ?? "").Trim()))
            {
                Program.Logger.Log("env variable DISCORD_WEB_HOOK not found");
            }
          
                Tracker tracker = Program.InitTracker();
                while (true)
                {
                    tracker.Track();
                    Thread.Sleep(180000);
                }
            
        }

        private static Tracker InitTracker()
        {
            string str = Environment.GetEnvironmentVariable("GAME_CLIENT_VERSION") ?? "99.99.99";
            string url = (Environment.GetEnvironmentVariable("ALLY_CODES_URL") ?? "").Trim();
            ArenaType arenaType = (Environment.GetEnvironmentVariable("ARENA_TYPE") ?? "SQUAD").Trim().Equals("FLEET")
                ? ArenaType.Fleet
                : ArenaType.Squad;
            Program.Logger.Log(string.Format("GAME_CLIENT_VERSION: {0}, Arena type: {1}", (object) str,
                (object) arenaType));
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
                List<string> list1 = result
                    .Select<PlayerSettings, string>((Func<PlayerSettings, string>) (ac => ac.AllyCode))
                    .ToList<string>();
                Program.Logger.Log(string.Format("Provided ally codes from environment: #{0}", (object) list1.Count));
                Program.Logger.Log(string.Join<string>(',', (IEnumerable<string>) list1));
                List<string> list2 = result
                    .Select<PlayerSettings, string>((Func<PlayerSettings, string>) (x => x.DiscordId)).ToList<string>();
                Program.Logger.Log(string.Format("Provided discord tags: #{0}", (object) list2.Count));
                Program.Logger.Log(string.Join<string>(',', (IEnumerable<string>) list2));
            }

            return new Tracker((IDiscordMessenger) new DiscordMessenger(webHook), playerSettingsProvider,
                (IArenaRankStorage) new StaticArenaRankStorage(), (IPlayerRankService) new PlayerRankService(
                    (IGameClient) new Ipd.GameClient.GameClient()
                    {
                        GameClientVersion = str
                    }), Program.Logger, (ITagsProvider) new EnvTagsProvider(Program.Logger), arenaType);
        }
    }
}