// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.DiscordLogger
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10FD981A-2B33-4DE6-8525-B5BDF64E7AF8
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.Core.dll

using Ipd.Core.Interfaces;
using System;

namespace Ipd.Core.Services
{
  public class DiscordLogger : ILog
  {
    private readonly IDiscordMessenger _discordMessenger;
    private readonly ILog _consoleLogger;

    public DiscordLogger(IDiscordMessenger discordMessenger)
    {
      this._discordMessenger = discordMessenger;
      this._consoleLogger = (ILog) new ConsoleLogger();
    }

    public void Log(string message)
    {
      try
      {
        this._discordMessenger.SendTextMessage(message).Wait();
      }
      catch (Exception ex)
      {
        this._consoleLogger.Log("Discord logger fail: " + ex.Message);
      }
      finally
      {
        this._consoleLogger.Log(message);
      }
    }
  }
}
