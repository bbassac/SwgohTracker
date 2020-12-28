// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.ConsoleLogger
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

using Ipd.Core.Interfaces;
using System;

namespace Ipd.Core.Services
{
  public class ConsoleLogger : ILog
  {
    public void Log(string message) => Console.WriteLine(message);
  }
}
