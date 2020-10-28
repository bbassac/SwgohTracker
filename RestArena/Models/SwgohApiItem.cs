using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace RestArena.Models
{
    public class SwgohApiItem

    {
        public String ship { get; set; }
        public String Name { get; set; }
        [JsonProperty("base_id")]
        public String BaseId { get; set; }
        public List<String> Categories { get; set; }
        public String Alignment { get; set; }
    }
}
