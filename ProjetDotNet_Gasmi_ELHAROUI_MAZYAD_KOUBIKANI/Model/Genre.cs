using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.Model
{
    public class Genre
    {
        [JsonProperty("id")]
        String Id { get; set; }

        [JsonProperty("nom")]
        String Nom { get; set; }

    }
}
