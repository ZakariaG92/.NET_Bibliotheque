using ClientApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static ClientApp.Utilities.Enum;

namespace ClientApp.Utilities
{
   public static class Api
    {
        private static readonly string BASE_URL = "https://localhost:5001/api/";
        public static async Task<string> getRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await client.GetAsync(BASE_URL+url))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode) return null;
                    String json = await httpResponseMessage.Content.ReadAsStringAsync();
                    return json; 

                }
            }

            return null;
        }

  
    }
}
