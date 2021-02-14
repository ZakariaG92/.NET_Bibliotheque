using ClientApp.Utilities;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.ViewModel
{
    public class Book : Ibase ,  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

  
        public int Id { get; set; }

  
        public String Title { get; set; }

      
        public String Contenu { get; set; }

     
        public float Prix { get; set; }

        public List<Genre> Genre { get; set; }


     

        public static async Task<Book> getByIdAsync(int id)
        {

            string response = await Api.getRequest($"Books/id/{id}");

                    return null;
   
            

        }

        public static async Task<List<Book>> getAllAsync(int pSeize = 0)
        {  
            string response = await Api.getRequest("Books/all");
            List<Book> book = JsonConvert.DeserializeObject<List<Book>>(response);
            if (pSeize==0)
            {
                return book;
            }
            else
            {
                var sorted = book.Take(pSeize);
                List<Book> sortedBook = new List<Book>();
                foreach (Book b in sorted)
                {
                    sortedBook.Add(b);
                }
                return sortedBook;
            }
          
        }

        public static async Task<List<Book>> getByGenreId(int id)
        {

            string response = await Api.getRequest($"Books/genre/{id}");

            List<Book> book = JsonConvert.DeserializeObject<List<Book>>(response);
            return book;



        }
    }
}
