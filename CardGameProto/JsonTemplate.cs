using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CardGameProto
{
    [JsonObject("card")]
    class CardTemplate
    {
        [JsonProperty("id")] public int Id;
        [JsonProperty("name")] public string Name;
        [JsonProperty("description")] public string Description;
        [JsonProperty("cost")] public int Cost;
        [JsonProperty("duration")] public int Duration;
        [JsonProperty("card_type")] public CardType CardType;
        [JsonProperty("effects")] public IEnumerable<EffectTemplate> Effects;
        [JsonProperty("image_path")] public string ImagePath;
    }

    [JsonObject("effect")]
    class EffectTemplate
    {
        [JsonProperty("power")] public int Power;
        [JsonProperty("target_types")] public List<TargetType> TargetTypes;
    }


}