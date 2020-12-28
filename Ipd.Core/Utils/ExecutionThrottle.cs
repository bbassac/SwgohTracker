// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Utils.ExecutionThrottle
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Ipd.Core.Utils
{
  public class ExecutionThrottle
  {
    public static void ThrottleSync(int timeLimitMs, Action action)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      action();
      stopwatch.Stop();
      long num = (long) timeLimitMs - stopwatch.ElapsedMilliseconds;
      if (num <= 0L)
        return;
      Thread.Sleep((int) num);
    }

    public static T ThrottleSync<T>(int timeLimitMs, Func<T> action)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      T obj = action();
      stopwatch.Stop();
      long num = (long) timeLimitMs - stopwatch.ElapsedMilliseconds;
      if (num <= 0L)
        return obj;
      Thread.Sleep((int) num);
      return obj;
    }

    public static async Task ThrottleAsync(int timeLimitMs, Func<Task> task)
    {
      Stopwatch watcher = new Stopwatch();
      watcher.Start();
      await Task.Run(task);
      watcher.Stop();
      long num = (long) timeLimitMs - watcher.ElapsedMilliseconds;
      if (num <= 0L)
      {
        watcher = (Stopwatch) null;
      }
      else
      {
        await Task.Delay((int) num);
        watcher = (Stopwatch) null;
      }
    }
  }
}
