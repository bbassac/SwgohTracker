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
        private static ILog _logger;

        private static void Main(string[] args)
        {
            if (string.IsNullOrEmpty((Environment.GetEnvironmentVariable("DISCORD_WEB_HOOK") ?? "").Trim()))
            {
                _logger.Log("env variable DISCORD_WEB_HOOK not found");
            }
          
                Tracker tracker = Program.InitTracker();
                while (true)
                {
                PlayerArenaRank result = tracker.Track();
                Console.WriteLine("BRUNO TROUVE : " + result.ToString());
                    Thread.Sleep(180000);
                }
            
        }

        private static Tracker InitTracker()
        {
            Environment.SetEnvironmentVariable("ARENA_TYPE", "SQUAD");
            Environment.SetEnvironmentVariable("ALLY_CODES", "386782543");
            string strLogger = (Environment.GetEnvironmentVariable("LOGGER_TYPE") ?? "CONSOLE").Trim();
            string webHookLogger = (Environment.GetEnvironmentVariable("LOGGER_HOOK") ?? "").Trim();
            _logger =
                !strLogger.Equals("DISCORD", StringComparison.InvariantCultureIgnoreCase) || string.IsNullOrEmpty(webHook)
                    ? (ILog)new ConsoleLogger()
                    : (ILog)new DiscordLogger((IDiscordMessenger)new DiscordMessenger(webHook));
            _logger.Log("Logger type: " + strLogger);

            string str = Environment.GetEnvironmentVariable("GAME_CLIENT_VERSION") ?? "99.99.99";
            string url = (Environment.GetEnvironmentVariable("ALLY_CODES_URL") ?? "").Trim();
            ArenaType arenaType = (Environment.GetEnvironmentVariable("ARENA_TYPE") ?? "SQUAD").Trim().Equals("FLEET")
                ? ArenaType.Fleet
                : ArenaType.Squad;
            _logger.Log(string.Format("GAME_CLIENT_VERSION: {0}, Arena type: {1}", (object) str,
                (object) arenaType));
            string webHook = (Environment.GetEnvironmentVariable("DISCORD_WEB_HOOK") ?? "").Trim();
            if (string.IsNullOrEmpty(webHook))
                _logger.Log("ENV variable DISCORD_WEB_HOOK not found");
            IPlayerSettingsProvider playerSettingsProvider;
            if (!string.IsNullOrEmpty(url))
            {
                _logger.Log("Ally codes and tags will be loaded from the provided url");
                playerSettingsProvider = (IPlayerSettingsProvider) new PlayerSettingsUrlProvider(url, _logger);
            }
            else
            {
                playerSettingsProvider = (IPlayerSettingsProvider) new PlayerSettingsEnvProvider(_logger);
                IList<PlayerSettings> result = playerSettingsProvider.GetPlayerSettingAsync().Result;
                List<string> list1 = result
                    .Select<PlayerSettings, string>((Func<PlayerSettings, string>) (ac => ac.AllyCode))
                    .ToList<string>();
                _logger.Log(string.Format("Provided ally codes from environment: #{0}", (object) list1.Count));
                _logger.Log(string.Join<string>(',', (IEnumerable<string>) list1));
                List<string> list2 = result
                    .Select<PlayerSettings, string>((Func<PlayerSettings, string>) (x => x.DiscordId)).ToList<string>();
                _logger.Log(string.Format("Provided discord tags: #{0}", (object) list2.Count));
                _logger.Log(string.Join<string>(',', (IEnumerable<string>) list2));
            }

            return new Tracker((IDiscordMessenger) new DiscordMessenger(webHook), playerSettingsProvider,
                (IArenaRankStorage) new StaticArenaRankStorage(), (IPlayerRankService) new PlayerRankService(
                    (IGameClient) new Ipd.GameClient.GameClient()
                    {
                        GameClientVersion = str
                    }), _logger, (ITagsProvider) new EnvTagsProvider(_logger), arenaType);
        }
    }
}