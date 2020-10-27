using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ipd.Core.Models;
using Newtonsoft.Json;
using RestArena.Models;

namespace RestArena
{
    public  class SwgohCache
    {
        private static SwgohCache _instance = null;
        private List<Charactercs> chars;
        private List<Charactercs> ships;
        private static HttpClient client;
        private SwgohCache()
        {
            client = new HttpClient();
            
            
        }

        public async Task<dynamic> getRoasterAsync()
        {
            var roster = await client.GetStringAsync("https://swgoh.gg/api/player/" + Environment.GetEnvironmentVariable("ALLY_CODES"));
            dynamic JsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(roster);
            return JsonObject;
        }

        public async Task<List<Charactercs>> GetCharsAsync()
        {
            if (chars == null)
            {
                chars = JsonConvert.DeserializeObject<List<Charactercs>>(await client.GetStringAsync("https://swgoh.gg/api/characters/"));
            }
            return chars;
        }

        public async Task<List<Charactercs>> GetShipsAsync()
        {
            if (ships == null)
            {
                ships = JsonConvert.DeserializeObject<List<Charactercs>>(await client.GetStringAsync("https://swgoh.gg/api/ships/"));
            }
            return ships;
        }

        public static SwgohCache Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SwgohCache();
                }
                return _instance;
            }
        }
    }
}
