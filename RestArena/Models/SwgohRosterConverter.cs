using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestArena.Models
{
    public class SwgohRosterConverter
    {

        public static async Task<List<Unit>> GetSwgohDataAsync()
        {
            var toReturn = new List<Unit>();

            dynamic jsonObject = await SwgohCache.Instance.getRoasterAsync();
            List<Charactercs> chars = await SwgohCache.Instance.GetCharsAsync();
            List<Charactercs> ships = await SwgohCache.Instance.GetShipsAsync();

            foreach (var item in jsonObject["units"])
            {
                Unit unit = new Unit();

                var swgohUnit = item["data"];
                unit.Name = swgohUnit["name"];
                unit.Stars = swgohUnit["rarity"];
                unit.Gear = swgohUnit["gear_level"];
                unit.Level = swgohUnit["level"];
                unit.Gp = swgohUnit["power"];
                unit.BaseId = swgohUnit["base_id"];
                unit.Zetas = swgohUnit["zeta_abilities"] != null ? swgohUnit["zeta_abilities"].Count : 0;
                unit.Relic = swgohUnit["relic_tier"] > 1 ? swgohUnit["relic_tier"] - 2 : 0;
                unit.Type = swgohUnit["combat_type"] == 1 ? Unit.UnitType.CHAR.ToString() : Unit.UnitType.SHIP.ToString();

                var stats = swgohUnit["stats"];
                unit.Health = stats["1"];
                unit.Speed = stats["5"];
                unit.PhysicalDamage = stats["6"];
                unit.CriticalChance = stats["14"];
                unit.CriticalDamage = stats["16"];
                unit.Potency = stats["17"];
                unit.Tenacity = stats["18"];
                unit.HealSteal = stats["27"];
                unit.Protection = stats["28"];

                if (unit.Type.Equals(Unit.UnitType.CHAR.ToString()))
                {
                    unit.Alignment = chars.SingleOrDefault(ch => ch.BaseId == unit.BaseId)?.Alignment;
                    unit.Categories = (from c in chars where c.BaseId == unit.BaseId select c.Categories).FirstOrDefault();
                    var menfinSide = (unit.Alignment != null && unit.Alignment.Equals("Light Side")) ? "L" : "D";
                    unit.Url = "https://menfin-swgoh.herokuapp.com/toon/" + unit.BaseId +
                               "?gear=" + unit.Gear +
                               "&stars=" + unit.Stars +
                               "&zetas=" + unit.Zetas +
                               "&speed=" + unit.Speed +
                               "&relics=" + unit.Relic +
                               "&side=" + menfinSide;


                    unit.ShipBaseId = chars.SingleOrDefault(ch => ch.BaseId==unit.BaseId)?.ship;
                    unit.ShipName = ships.SingleOrDefault(sh =>sh.BaseId==unit.ShipBaseId)?.Name;
                }
                else
                {
                    unit.Alignment = ships.SingleOrDefault(shipc => shipc.BaseId == unit.BaseId)?.Alignment;
                    unit.Categories = (from c in ships where c.BaseId == unit.BaseId select c.Categories).FirstOrDefault();
                    unit.Url = "https://menfin-swgoh.herokuapp.com/ship/" + unit.BaseId +
                               "?stars=" + unit.Stars +
                               "&speed=" + unit.Speed;
                }
                toReturn.Add(unit);
            }
            return toReturn;
        }
    }
} 
