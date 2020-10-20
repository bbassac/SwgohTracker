// Decompiled with JetBrains decompiler
// Type: SimpleTracker.Program
// Assembly: SimpleTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0396F7-C081-4CFF-8F0B-03C9C1ACABC0
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\SimpleTracker.dll

using Ipd.Core.Interfaces;
using Ipd.Core.Models;
using Ipd.Core.Services;
using Ipd.GameClient;
using SimpleTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
                PlayerArenaRank result = tracker.Track();
                Console.WriteLine("BRUNO TROUVE : " + result.ToString());
                Thread.Sleep(180000);
            }

        }

    }
}