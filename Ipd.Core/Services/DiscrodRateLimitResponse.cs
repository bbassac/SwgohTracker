﻿// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.DiscrodRateLimitResponse
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10FD981A-2B33-4DE6-8525-B5BDF64E7AF8
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.Core.dll

namespace Ipd.Core.Services
{
  public class DiscrodRateLimitResponse
  {
    public string Message { get; set; } = "";

    public int RetryAfter { get; set; }

    public bool Global { get; set; }
  }
}