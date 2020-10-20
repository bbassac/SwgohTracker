// Decompiled with JetBrains decompiler
// Type: SimpleTracker.Tracker
// Assembly: SimpleTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0396F7-C081-4CFF-8F0B-03C9C1ACABC0
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\SimpleTracker.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ipd.Core.Interfaces;
using Ipd.Core.Models;
using Ipd.Core.Services;
using Ipd.Core.Utils;
using Ipd.GameClient;
using Ipd.Services;
using StaticArenaRankStorage = SimpleTracker.Services.StaticArenaRankStorage;

namespace Ipd
{
  public class Tracker
  {

      private IDiscordMessenger Messenger { get; set; }

    private IPlayerSettingsProvider PlayerSettingsProvider { get; set; }

    private IArenaRankStorage ArenaRankStorage { get; set; }

    private IPlayerRankService PlayerRankService { get; set; }

    private ILog Logger { get; set; }

    private ArenaType ArenaType { get; set; }

    public Tracker(
      IDiscordMessenger messenger,
      IPlayerSettingsProvider playerSettingsProvider,
      IArenaRankStorage arenaRankStorage,
      IPlayerRankService playerRankService,
      ILog logger,
      ITagsProvider tagProvider,
      ArenaType arenaType)
    {
      this.Messenger = messenger;
      this.PlayerSettingsProvider = playerSettingsProvider;
      this.ArenaRankStorage = arenaRankStorage;
      this.PlayerRankService = playerRankService;
      this.Logger = logger;
      this.ArenaType = arenaType;
    }

    public PlayerArenaRank Track()
    {
      IList<PlayerSettings> result = this.PlayerSettingsProvider.GetPlayerSettingAsync().Result;
      AuthResponse auth = AuthProvider.Instance.GetAuthentication(playerRankService);
  
      return TrackOneAllyCode(result[0], auth);
    }

    public PlayerArenaRank TrackOneAllyCode(PlayerSettings setting, AuthResponse auth)
    {
      try
      {
        PlayerArenaRank result = this.PlayerRankService.GetPlayerRank(setting.AllyCode, auth).Result;
        int rank1 = this.ArenaType == ArenaType.Fleet ? result.FleetArenaRank : result.SquadArenaRank;
        int? rank2 = this.ArenaRankStorage.GetRank(setting.AllyCode);
        this.ArenaRankStorage.SaveRank(setting.AllyCode, rank1);
        if (!rank2.HasValue)
        {
          this.Messenger.SendTextMessage(string.Format("`{0}` is at {1}", (object) result.PlayerName, (object) rank1)).Wait();
        }
        else
        {
          int? nullable1 = rank2;
          int num1 = rank1;
          if (nullable1.GetValueOrDefault() == num1 & nullable1.HasValue)
            return result;
          int? nullable2 = rank2;
          int num2 = rank1;
          if (nullable2.GetValueOrDefault() > num2 & nullable2.HasValue)
            this.Messenger.SendTextMessage(string.Format("`{0}` climbed from  {1} to {2}", (object) result.PlayerName, (object) rank2, (object) rank1)).Wait();
          else if (!string.IsNullOrEmpty(setting.DiscordId))
            this.Messenger.SendTextTaggedMessage(setting.DiscordId, string.Format("`({0})` dropped from {1} to {2}", (object) result.PlayerName, (object) rank2, (object) rank1)).Wait();
          else
            this.Messenger.SendTextMessage(string.Format("`{0}` dropped from {1} to {2}", (object) result.PlayerName, (object) rank2, (object) rank1)).Wait();
        }

        return result;
      }
      catch (Exception ex)
      {
        this.Logger.Log("Error: " + ex.Message);
        return new PlayerArenaRank();
      }
     
    }


        public static Tracker InitTracker()
        {
            ILog _logger;
            Environment.SetEnvironmentVariable("ARENA_TYPE", "SQUAD");
            Environment.SetEnvironmentVariable("ALLY_CODES", "386782543");
            string strLogger = (Environment.GetEnvironmentVariable("LOGGER_TYPE") ?? "CONSOLE").Trim();
            string webHookLogger = (Environment.GetEnvironmentVariable("LOGGER_HOOK") ?? "").Trim();
            _logger =
                !strLogger.Equals("DISCORD", StringComparison.InvariantCultureIgnoreCase) || string.IsNullOrEmpty(webHookLogger)
                    ? (ILog)new ConsoleLogger()
                    : (ILog)new DiscordLogger((IDiscordMessenger)new DiscordMessenger(webHookLogger));
            _logger.Log("Logger type: " + strLogger);

            string str = Environment.GetEnvironmentVariable("GAME_CLIENT_VERSION") ?? "99.99.99";
            string url = (Environment.GetEnvironmentVariable("ALLY_CODES_URL") ?? "").Trim();
            ArenaType arenaType = (Environment.GetEnvironmentVariable("ARENA_TYPE") ?? "SQUAD").Trim().Equals("FLEET")
                ? ArenaType.Fleet
                : ArenaType.Squad;
            _logger.Log(string.Format("GAME_CLIENT_VERSION: {0}, Arena type: {1}", (object)str,
                (object)arenaType));
            string webHook = (Environment.GetEnvironmentVariable("DISCORD_WEB_HOOK") ?? "").Trim();
            if (string.IsNullOrEmpty(webHook))
                _logger.Log("ENV variable DISCORD_WEB_HOOK not found");
            IPlayerSettingsProvider playerSettingsProvider;
            if (!string.IsNullOrEmpty(url))
            {
                _logger.Log("Ally codes and tags will be loaded from the provided url");
                playerSettingsProvider = (IPlayerSettingsProvider)new PlayerSettingsUrlProvider(url, _logger);
            }
            else
            {
                playerSettingsProvider = (IPlayerSettingsProvider)new PlayerSettingsEnvProvider(_logger);
                IList<PlayerSettings> result = playerSettingsProvider.GetPlayerSettingAsync().Result;
                List<string> list1 = result
                    .Select<PlayerSettings, string>((Func<PlayerSettings, string>)(ac => ac.AllyCode))
                    .ToList<string>();
                _logger.Log(string.Format("Provided ally codes from environment: #{0}", (object)list1.Count));
                _logger.Log(string.Join<string>(',', (IEnumerable<string>)list1));
                List<string> list2 = result
                    .Select<PlayerSettings, string>((Func<PlayerSettings, string>)(x => x.DiscordId)).ToList<string>();
                _logger.Log(string.Format("Provided discord tags: #{0}", (object)list2.Count));
                _logger.Log(string.Join<string>(',', (IEnumerable<string>)list2));
            }

            return new Tracker((IDiscordMessenger)new DiscordMessenger(webHook), playerSettingsProvider,
                (IArenaRankStorage)new StaticArenaRankStorage(), (IPlayerRankService)new PlayerRankService(
                    (IGameClient)new Ipd.GameClient.GameClient()
                    {
                        GameClientVersion = str
                    }), _logger, (ITagsProvider)new EnvTagsProvider(_logger), arenaType);
        }
    }
}
