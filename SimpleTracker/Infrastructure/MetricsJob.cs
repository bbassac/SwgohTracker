// Decompiled with JetBrains decompiler
// Type: SimpleTracker.Infrastructure.MetricsJob
// Assembly: SimpleTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D0ABE11D-B397-4D3E-B71F-B80A8D542387
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\SimpleTracker.dll

using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleTracker.Infrastructure
{
  public class MetricsJob : BackgroundService
  {
    private readonly string _name;

    public MetricsJob(string name)
    {
        this._name = name;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      while (!stoppingToken.IsCancellationRequested)
      {
        TcpConnectionInformation[] activeTcpConnections = IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections();
        int workerThreads = 0;
        int completionPortThreads = 0;
        ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
        Console.WriteLine("---------------------");
        foreach (IGrouping<IPEndPoint, TcpConnectionInformation> grouping in ((IEnumerable<TcpConnectionInformation>) activeTcpConnections).ToList<TcpConnectionInformation>().GroupBy<TcpConnectionInformation, IPEndPoint>((Func<TcpConnectionInformation, IPEndPoint>) (x => x.RemoteEndPoint)))
        {
          IGrouping<IPEndPoint, TcpConnectionInformation> group = grouping;
          group.ToList<TcpConnectionInformation>().GroupBy<TcpConnectionInformation, TcpState>((Func<TcpConnectionInformation, TcpState>) (c => c.State)).ToList<IGrouping<TcpState, TcpConnectionInformation>>().ForEach((Action<IGrouping<TcpState, TcpConnectionInformation>>) (g => Console.WriteLine(string.Format("{0}:{1}:{2}", (object) group.Key, (object) g.Key, (object) g.Count<TcpConnectionInformation>()))));
        }
        await Task.Delay(3000, stoppingToken);
      }
    }

    }
}
