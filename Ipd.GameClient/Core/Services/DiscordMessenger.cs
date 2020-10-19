// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.DiscordMessenger
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10FD981A-2B33-4DE6-8525-B5BDF64E7AF8
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.Core.dll

using Ipd.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Polly;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ipd.Core.Services
{
  public class DiscordMessenger : IDiscordMessenger
  {
    public string DiscordWebHook { get; private set; }

    public DiscordMessenger(string webHook) => this.DiscordWebHook = webHook;

    private async Task SendMessage(string textMessage)
    {
      
        Console.WriteLine(textMessage);
    }

    public async Task SendTextMessage(string textMessage)
    {
      try
      {
        await this.SendMessage(textMessage);
      }
      catch (Exception ex)
      {
        Console.WriteLine("[DiscordMessenger]:Request failed with Exception:[" + ex.Message + "].");
      }
    }

    public async Task SendTextTaggedMessage(string userDiscordId, string textMessage)
    {
      try
      {
        await this.SendMessage("<@" + userDiscordId + ">" + textMessage);
      }
      catch (Exception ex)
      {
        Console.WriteLine("[DiscordMessenger]:Request failed with Exception:[" + ex.Message + "].");
      }
    }
  }
}
