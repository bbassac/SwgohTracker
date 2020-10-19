// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Utils.ExecutionThrottle
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10FD981A-2B33-4DE6-8525-B5BDF64E7AF8
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.Core.dll

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
        return;
      await Task.Delay((int) num);
    }
  }
}
