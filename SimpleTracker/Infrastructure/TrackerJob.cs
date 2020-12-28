// Decompiled with JetBrains decompiler
// Type: SimpleTracker.Infrastructure.TrackerJob
// Assembly: SimpleTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D0ABE11D-B397-4D3E-B71F-B80A8D542387
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\SimpleTracker.dll

using Ipd.Core.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleTracker.Infrastructure
{
  public class TrackerJob : BackgroundService
  {
    private readonly Tracker _tracker;
    private readonly ILog _logger;

    public TrackerJob(Tracker tracker, ILog logger)
    { 
        this._tracker = tracker;
        this._logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      while (!stoppingToken.IsCancellationRequested)
      {
        try
        {
          this._tracker.Track();
        }
        catch (Exception ex)
        {
          this._logger.Log("ERROR:" + ex.Message);
          this._logger.Log("2 seconds sleep to retry");
        }
        await Task.Delay(2000, stoppingToken);
      }
    }
  }
}
