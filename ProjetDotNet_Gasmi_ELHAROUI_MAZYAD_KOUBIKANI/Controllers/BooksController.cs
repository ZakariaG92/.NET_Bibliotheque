using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.Model;
using System;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using System.Text.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET: api/<BooksController>
        // GET: api/<BooksController>

        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        


        // GET api/<BooksController>/all books
        [HttpGet("all")]
        public string GetAllBooks()
        {
            IMongoCollection<Book> collection = MongoConn.getCollectionBooks();

            var query =
            from e in collection.AsQueryable<Book>()
            select e;

            string jsonString = JsonSerializer.Serialize(query);

            return jsonString;
        }


        // GET api/<BooksController>/test
        [HttpGet("id/{id}")]
        public string GetById(string id)
        {
            IMongoCollection<Book> collection = MongoConn.getCollectionBooks();

            var query =
            from e in collection.AsQueryable<Book>()
            where e.Id == Int32.Parse(id)
            select e;

            string jsonString = JsonSerializer.Serialize(query);

            return jsonString;
        }




        // GET api/<BooksController>/test
        [HttpGet("titles/{title}")]
        public string GetByTitle(string title)
        {
           IMongoCollection<Book> collection = MongoConn.getCollectionBooks();

            var query =
            from e in collection.AsQueryable<Book>()
            where e.Title == title
            select e;

            List<Book> listBooks = new List<Book>();
            foreach (var books in query)
            {
                listBooks.Add(books);
            }

            string jsonString = JsonSerializer.Serialize(listBooks);

            return jsonString;
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            IMongoCollection<Book> collection = MongoConn.getCollectionBooks();
            collection.InsertOne(book);
        }




        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            IMongoCollection<Book> collection = MongoConn.getCollectionBooks();

            FilterDefinition<Book> filter = new BsonDocument("_id", id);

            collection.ReplaceOne(filter, book);
        }



        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            IMongoCollection<Book> collection = MongoConn.getCollectionBooks();

            FilterDefinition<Book> filter = new BsonDocument("_id", Int32.Parse(id));
            collection.DeleteOne(filter);
        }
    }
}
