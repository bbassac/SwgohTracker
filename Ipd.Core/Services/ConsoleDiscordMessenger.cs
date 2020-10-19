// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.ConsoleDiscordMessenger
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10FD981A-2B33-4DE6-8525-B5BDF64E7AF8
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.Core.dll

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
