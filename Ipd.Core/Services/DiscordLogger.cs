// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.DiscordLogger
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

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
