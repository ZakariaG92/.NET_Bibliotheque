using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.Model
{
    public class Genre
    {

        [BsonElement("_id")]
        public string Id { get; set; }


        [BsonElement("nom")]
        public  string Nom { get; set; }

    }
}
