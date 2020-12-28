using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestArena.Models;

namespace RestArena
{
    public  class SwgohCache
    {
        private static SwgohCache _instance = null;
        private List<SwgohApiItem> chars;
        private List<SwgohApiItem> ships;
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

        public async Task<List<SwgohApiItem>> GetCharsAsync()
        {
            if (chars == null)
            {
                chars = JsonConvert.DeserializeObject<List<SwgohApiItem>>(await client.GetStringAsync("https://swgoh.gg/api/characters/"));
            }
            return chars;
        }

        public async Task<List<SwgohApiItem>> GetShipsAsync()
        {
            if (ships == null)
            {
                ships = JsonConvert.DeserializeObject<List<SwgohApiItem>>(await client.GetStringAsync("https://swgoh.gg/api/ships/"));
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
