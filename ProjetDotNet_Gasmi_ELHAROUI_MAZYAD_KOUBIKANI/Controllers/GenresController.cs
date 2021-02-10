using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.Model;
using System;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using System.Text.Json;


namespace ProjetDotNet_Gasmi_ELHAROUI_MAZYAD_KOUBIKANI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GenresController>/test
        [HttpGet("id/{id}")]
        public string GetById(string id)
        {
            IMongoCollection<Genre> collection = MongoConn.getCollectionGenres();

            var query =
            from e in collection.AsQueryable<Genre>()
            where e.Id == Int32.Parse(id)
            select e;

            string jsonString = JsonSerializer.Serialize(query);

            return jsonString;
        }


        // GET api/<GenresController>/test
        [HttpGet("names/{nom}")]
        public string GetByName(string nom)
        {
            IMongoCollection<Genre> collection = MongoConn.getCollectionGenres();

            var query =
            from e in collection.AsQueryable<Genre>()
            where e.Nom == nom
            select e;

            List<Genre> listGenres = new List<Genre>();
            foreach (var genres in query)
            {
                listGenres.Add(genres);
            }

            string jsonString = JsonSerializer.Serialize(listGenres);

            return jsonString;
        }


        // POST api/<GenresController>
        [HttpPost]
        public void Post([FromBody] Genre genre)
        {
            IMongoCollection<Genre> collection = MongoConn.getCollectionGenres();
            collection.InsertOne(genre);

        }

        // PUT api/<GenresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        

    }
}
