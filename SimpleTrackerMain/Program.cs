// Decompiled with JetBrains decompiler
// Type: SimpleTracker.Program
// Assembly: SimpleTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0396F7-C081-4CFF-8F0B-03C9C1ACABC0
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\SimpleTracker.dll

using Ipd.Core.Models;
using System;
using System.Threading;
using Ipd;

namespace SimpleTracker
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Tracker tracker = Tracker.InitTracker();


            while (true)
            {
                PlayerArenaRank result = tracker.Track(true);
                Console.WriteLine(DateTime.Now + " ### " + result.PlayerName + " Arena #" + result.SquadArenaRank + " Fleet #" + result.FleetArenaRank);
                //Thread.Sleep(180000);
                Thread.Sleep(120000);
            }

        }

    }
}