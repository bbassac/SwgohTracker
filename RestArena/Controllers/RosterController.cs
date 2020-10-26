using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ipd;
using Ipd.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestArena.Models;
using SimpleTracker;

namespace RestArena.Controllers
{
    [ApiController]
    [Route("roster")]
    public class RosterController : ControllerBase
    {

        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<List<Unit>> GetAsync()
        {
            var result =  await client.GetStringAsync("https://swgoh.gg/api/player/" + Environment.GetEnvironmentVariable("ALLY_CODES"));
            return SwgohRosterConverter.convert(result);
        }
    }



}
