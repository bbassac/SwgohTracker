using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ipd;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestArena.Models;


namespace RestArena.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("roster")]
    public class RosterController : ControllerBase
    {
        
        [HttpGet]
        public async Task<List<Unit>> GetAsync()
        {
            var result = await SwgohRosterConverter.GetSwgohDataAsync();
            return result;
        }
    }



}
