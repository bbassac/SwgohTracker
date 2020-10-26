using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestArena.Models
{
    public class SwgohRosterConverter
    {
        public static List<Unit> convert(String input)
        {
            var toReturn = new List<Unit>();

            dynamic JsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(input);
            foreach (var item in JsonObject["units"])
            {
                var swgohUnit = item["data"];
                Unit unit = new Unit();

                unit.Name = swgohUnit["name"];
             
                unit.Stars = swgohUnit["rarity"];
                unit.Gear = swgohUnit["gear_level"];
                unit.Level = swgohUnit["level"];
                unit.Gp = swgohUnit["power"];
                unit.Zetas = swgohUnit["zeta_abilities"] != null ? swgohUnit["zeta_abilities"].Count : 0;
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
                unit.Relic = swgohUnit["relic_tier"] > 1 ? swgohUnit["relic_tier"] - 2 : 0;
                unit.Type = swgohUnit["combat_type"] == 1 ? Unit.UnitType.CHAR.ToString() : Unit.UnitType.SHIP.ToString();
                //TODO différencier les toons des ships
                //TODO gérer le side
                unit.Url = "https://menfin-swgoh.herokuapp.com/toon/" + swgohUnit["base_id"] + "?gear=" + unit.Gear +
                           "&stars=" + unit.Stars + "&zetas=" + unit.Zetas + "&speed=" + unit.Speed + "&relics=" +
                           unit.Relic + "&side=L";
                toReturn.Add(unit);
            }
            return toReturn;
        }
    }
}
