﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ipd.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleTracker;

namespace RestArena.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RankingController : ControllerBase
    {


        private readonly ILogger<RankingController> _logger;

        public RankingController(ILogger<RankingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public PlayerArenaRank Get()
        {

            Tracker tracker = Tracker.InitTracker();


            PlayerArenaRank result = tracker.Track();
            return result;
        }
    }



}
