// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.ConsoleDiscordMessenger
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

using Ipd.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Ipd.Core.Services
{
  public class ConsoleDiscordMessenger : IDiscordMessenger
  {
    public Task SendTextMessage(string textMessage)
    {
      Console.WriteLine(textMessage);
      return Task.CompletedTask;
    }

    public Task SendTextTaggedMessage(string userDiscordId, string textMessage) => throw new NotImplementedException();
  }
}
