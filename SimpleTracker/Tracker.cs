// Decompiled with JetBrains decompiler
// Type: SimpleTracker.Tracker
// Assembly: SimpleTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D0ABE11D-B397-4D3E-B71F-B80A8D542387
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\SimpleTracker.dll

using Ipd.Core.Extensions;
using Ipd.Core.Interfaces;
using Ipd.Core.Models;
using Ipd.Core.Utils;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

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

    private IStatsService StatService { get; set; }

    public Tracker(
      IDiscordMessenger messenger,
      IPlayerSettingsProvider playerSettingsProvider,
      IArenaRankStorage arenaRankStorage,
      IPlayerRankService playerRankService,
      ILog logger,
      ITagsProvider tagProvider,
      ArenaType arenaType,
      IStatsService statService)
    {
      this.Messenger = messenger;
      this.PlayerSettingsProvider = playerSettingsProvider;
      this.ArenaRankStorage = arenaRankStorage;
      this.PlayerRankService = playerRankService;
      this.Logger = logger;
      this.ArenaType = arenaType;
      this.TagProvider = tagProvider;
      this.StatService = statService;
    }

    public void PostStats()
    {
      try
      {
        IList<PlayerSettings> result = this.PlayerSettingsProvider.GetPlayerSettingAsync().Result;
        List<string> list = result.Select<PlayerSettings, string>((Func<PlayerSettings, string>) (ps => ps.AllyCode.NormalizeAllyCode())).ToList<string>();
        this.StatService.PostStats(this.ArenaType.ToString(), result.Count, list);
      }
      catch (Exception ex)
      {
      }
    }

    public void Track() => this.PlayerSettingsProvider.GetPlayerSettingAsync().Result.ForEach<PlayerSettings>((Action<PlayerSettings>) (settings =>
    {
      if (settings.Skip)
        return;
      ExecutionThrottle.ThrottleSync(2000, (Action) (() => this.TrackOneAllyCode(settings, new AuthResponse())));
    }));

    private string GetTagidOnDrop(PlayerSettings setting)
    {
      if (!string.IsNullOrEmpty(setting.TagIdOnDrop))
        return setting.TagIdOnDrop.Trim();
      return !string.IsNullOrEmpty(setting.DiscordId) ? setting.DiscordId.Trim() : "";
    }

    public void TrackOneAllyCode(PlayerSettings setting, AuthResponse auth)
    {
      try
      {
        PlayerArenaRank result = this.PlayerRankService.GetPlayerRank(setting.AllyCode, auth).Result;
        int rank1 = this.ArenaType == ArenaType.Fleet ? result.FleetArenaRank : result.SquadArenaRank;
        int? rank2 = this.ArenaRankStorage.GetRank(setting.AllyCode);
        this.ArenaRankStorage.SaveRank(setting.AllyCode, rank1);
        string payoutString = PoUtils.GetPoTime(result.PayoutOffsetMinutes, this.ArenaType).ToPayoutString();
        if (!rank2.HasValue)
        {
          this.Messenger.SendTextMessage(string.Format("{0}`{1}` is at {2}. payout in `{3}`", (object) (setting.UserIcon ?? ""), (object) result.PlayerName, (object) rank1, (object) payoutString)).Wait();
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
          {
            if (!string.IsNullOrEmpty(setting.TagIdOnClimb))
              this.Messenger.SendTextTaggedMessage(setting.TagIdOnClimb, string.Format("{0}`{1}` climbed from  {2} to {3}, Payout in `{4}`", (object) (setting.UserIcon ?? ""), (object) result.PlayerName, (object) rank2, (object) rank1, (object) payoutString)).Wait();
            else
              this.Messenger.SendTextMessage(string.Format("{0}`{1}` climbed from  {2} to {3}, Payout in `{4}`", (object) (setting.UserIcon ?? ""), (object) result.PlayerName, (object) rank2, (object) rank1, (object) payoutString)).Wait();
          }
          else
          {
            string tagidOnDrop = this.GetTagidOnDrop(setting);
            if (!string.IsNullOrEmpty(tagidOnDrop))
              this.Messenger.SendTextTaggedMessage(tagidOnDrop, string.Format("{0}`({1})` dropped from {2} to {3}, Payout in `{4}`", (object) (setting.UserIcon ?? ""), (object) result.PlayerName, (object) rank2, (object) rank1, (object) payoutString)).Wait();
            else
              this.Messenger.SendTextMessage(string.Format("{0}`{1}` dropped from {2} to {3}, Payout in `{4}`", (object) (setting.UserIcon ?? ""), (object) result.PlayerName, (object) rank2, (object) rank1, (object) payoutString)).Wait();
          }
        }
      }
      catch (Exception ex)
      {
        this.Logger.Log("Error processing allyCode:[" + setting.AllyCode + "]:" + ex.Message);
      }
    }
  }
}
