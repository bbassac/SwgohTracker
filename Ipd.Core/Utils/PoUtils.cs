// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Utils.PoUtils
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

using Ipd.Core.Models;
using NodaTime;
using System;

namespace Ipd.Core.Utils
{
  public static class PoUtils
  {
    public static Duration GetPoTime(
      int offsetMinutes,
      ArenaType arenaType,
      Instant? utcNow = null)
    {
      Instant other = utcNow.HasValue ? utcNow.Value : SystemClock.Instance.GetCurrentInstant();
      DateTime dateTimeUtc = other.ToDateTimeUtc();
      int hourOfDay = arenaType == ArenaType.Squad ? 18 : 19;
      Instant instant = Instant.FromUtc(dateTimeUtc.Year, dateTimeUtc.Month, dateTimeUtc.Day, hourOfDay, 0, 0).Minus(Duration.FromMinutes((long) offsetMinutes));
      return instant >= other ? instant.Minus(other) : instant.Plus(Duration.FromHours(24)).Minus(other);
    }
  }
}
