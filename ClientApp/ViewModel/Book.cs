using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.ViewModel
{
    public class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

  
        public int Id { get; set; }

  
        public String Title { get; set; }

      
        public String Contenu { get; set; }

     
        public float Prix { get; set; }

        public List<Genre> Genre { get; set; }


     

        public static async Task<Book> getByIdAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await client.GetAsync($"https://localhost:44310/api/Books/id/{id}"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode) return default;
                    String json = await httpResponseMessage.Content.ReadAsStringAsync();
                    List<Book> book = JsonConvert.DeserializeObject<List<Book>>(json);
                    return book[0];
                }
            }

            return null;
        }
    }
}
