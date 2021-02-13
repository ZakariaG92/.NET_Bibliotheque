﻿using ClientApp.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.ViewModel
{
   public class Genre : Ibase
    {
    
        public int Id { get; set; }

        public String Nom { get; set; }

        public static async Task<Genre> getByIdAsync(int id)
        {

            string response = await Api.getRequest($"Genres/id/{id}");

            return null;



        }

        public static async Task<List<Genre>> getAllAsync()
        {
            string response = await Api.getRequest("Genres/all");
            List<Genre> genres = JsonConvert.DeserializeObject<List<Genre>>(response);
            return genres;
        }
    }
}
