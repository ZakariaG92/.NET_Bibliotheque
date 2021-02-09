using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.Model
{
    public static class Routes
    {
        public readonly static string CONNEXION_STR = "mongodb+srv://DotNetUser:DotNetUser0@cluster0.wu4c5.mongodb.net/DbDotNetProject?retryWrites=true&w=majority";
        public readonly static string DBNAME = "DbDotNetProject";
        public readonly static string COLLECTION_BOOK = "livres";
        public readonly static string COLLECTION_GENRE = "genres";
    }
}
