// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Extensions.TimeExtension
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

using NodaTime;

namespace Ipd.Core.Extensions
{
  public static class TimeExtension
  {
    public static string ToPayoutString(this Duration value) => string.Format("{0:D2}:{1:D2}", (object) value.Hours, (object) value.Minutes);
  }
}
