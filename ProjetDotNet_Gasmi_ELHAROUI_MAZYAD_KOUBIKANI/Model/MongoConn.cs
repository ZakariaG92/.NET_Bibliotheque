using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.Model
{
    public static class MongoConn
    {

        private static IMongoDatabase connexion()
        {
            MongoClient client = new MongoClient(Routes.CONNEXION_STR);
            //IMongoDatabase database = client.GetDatabase(Routes.CONNEXION_STR);
            return client.GetDatabase(Routes.DBNAME);
        }

        public static IMongoCollection<Book> getCollectionBooks()
        {
            IMongoDatabase database = connexion();
           return database.GetCollection<Book>(Routes.COLLECTION_BOOK);

        }

        public static IMongoCollection<Genre> getCollectionGenres()
        {
            IMongoDatabase database = connexion();
            return database.GetCollection<Genre>(Routes.COLLECTION_GENRE);

        }



      
            
        
 
    }
}
