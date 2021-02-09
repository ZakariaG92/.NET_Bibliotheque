using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.Model
{
    public class Book
    {
        [JsonProperty("id")]
        String Id { get; set; }

        [JsonProperty("title")]
        String Title { get; set; }
        
        [JsonProperty("contenu")]
        String Contenu { get; set; }

        [JsonProperty("prix")]
        float Prix { get; set; }

        [JsonProperty("genre")]
        List<Genre> Genre { get; set; }

    }
}
