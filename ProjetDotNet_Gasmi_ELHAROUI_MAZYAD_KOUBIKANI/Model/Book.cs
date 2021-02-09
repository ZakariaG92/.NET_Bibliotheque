using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.Model
{
    public class Book
    {
        // Mapper l’objet CLR à la collection MongoDB.
        // Annoté avec[BsonId] pour désigner cette propriété comme clé primaire du document.
        // Annoté   avec [BsonRepresentation(BsonType.ObjectId)] pour permettre la transmission du paramètre en tant que type string au lieu d’une structure ObjectID .
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        String Id { get; set; }

        [BsonElement("title")]
        String Title { get; set; }
        
        [BsonElement("contenu")]
        String Contenu { get; set; }

        [BsonElement("prix")]
        float Prix { get; set; }

        [BsonElement("genre")]
        List<Genre> Genre { get; set; }

    }
}
