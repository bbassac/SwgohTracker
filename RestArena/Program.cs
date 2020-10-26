using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ipd;
using Ipd.Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RestArena
{
    public class Program
    {



        public static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("ARENA_TYPE", "SQUAD");
            Environment.SetEnvironmentVariable("ALLY_CODES", "386782543");
            Environment.SetEnvironmentVariable("DISCORD_WEB_HOOK", @"https://discord.com/api/webhooks/768119564373327902/dlZTabRJaublShq4cDVdNSi6EECw9xvYtwxLZzpgWfOq_xncymobXvqyToT4-PKAN91H");
            Environment.SetEnvironmentVariable("DISCORD_TAGS", "386782543|128793207038410752");


            Thread thread1 = new Thread(TreadWork.DoWork);
            thread1.Start();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class TreadWork
    {
        public static void DoWork()
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
