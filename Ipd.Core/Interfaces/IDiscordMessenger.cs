// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Interfaces.IDiscordMessenger
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

using System.Threading.Tasks;

namespace Ipd.Core.Interfaces
{
  public interface IDiscordMessenger
  {
    Task SendTextMessage(string textMessage);

    Task SendTextTaggedMessage(string userDiscordId, string textMessage);
  }
}
