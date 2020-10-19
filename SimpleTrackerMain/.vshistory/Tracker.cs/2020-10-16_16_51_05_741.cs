// Decompiled with JetBrains decompiler
// Type: SimpleTracker.Tracker
// Assembly: SimpleTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0396F7-C081-4CFF-8F0B-03C9C1ACABC0
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\SimpleTracker.dll

using Ipd.Core.Interfaces;
using Ipd.Core.Models;
using Ipd.Core.Utils;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleTracker
{
  public class Tracker
  {
    private const int THROTTLE_DELAY = 2000;
    private ITagsProvider TagProvider;

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
      this.TagProvider = tagProvider;
    }

    public void Track()
    {
      IList<PlayerSettings> result = this.PlayerSettingsProvider.GetPlayerSettingAsync().Result;
      AuthResponse auth = ExecutionThrottle.ThrottleSync<Task<AuthResponse>>(2000, (Func<Task<AuthResponse>>) (() => this.PlayerRankService.Login())).Result;
      Action<PlayerSettings> action = (Action<PlayerSettings>) (settings => ExecutionThrottle.ThrottleSync(2000, (Action) (() => this.TrackOneAllyCode(settings, auth))));
      result.ForEach<PlayerSettings>(action);
    }

    public void TrackOneAllyCode(PlayerSettings setting, AuthResponse auth)
    {
      try
      {
        PlayerArenaRank result = this.PlayerRankService.GetPlayerRank(setting.AllyCode, auth).Result;
        int rank1 = this.ArenaType == ArenaType.Fleet ? result.FleetArenaRank : result.SquadArenaRank;
        int? rank2 = this.ArenaRankStorage.GetRank(setting.AllyCode);
        Console.WriteLine(DateTime.Now + " ### "+ result.PlayerName + " Arena #" + result.SquadArenaRank + " Fleet #" + result.FleetArenaRank);
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
            return;
          int? nullable2 = rank2;
          int num2 = rank1;
          if (nullable2.GetValueOrDefault() > num2 & nullable2.HasValue)
            this.Messenger.SendTextMessage(string.Format("`{0}` climbed from  {1} to {2}", (object) result.PlayerName, (object) rank2, (object) rank1)).Wait();
          else if (!string.IsNullOrEmpty(setting.DiscordId))
            this.Messenger.SendTextTaggedMessage(setting.DiscordId, string.Format("`({0})` dropped from {1} to {2}", (object) result.PlayerName, (object) rank2, (object) rank1)).Wait();
          else
            this.Messenger.SendTextMessage(string.Format("`{0}` dropped from {1} to {2}", (object) result.PlayerName, (object) rank2, (object) rank1)).Wait();
        }
      }
      catch (Exception ex)
      {
        this.Logger.Log("Error: " + ex.Message);
      }
    }
  }
}
