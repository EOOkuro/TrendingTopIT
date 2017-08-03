using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrendingTopApi.objectFolder;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TrendingTopApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        MongoClient client;
        // GET api/values
        [HttpGet]
        public  string[] Get()
        {
            /*client = new MongoClient();
            var db = client.GetDatabase("TrendingDB");
            var col = db.GetCollection<RegData>("userDetails");
            var newReg = new RegData
            {
                emailAddress = "oodebiyi@gmail.com",
                userName = "olu",
                password = "pass",
            };
            await col.InsertOneAsync(newReg);*/
            return new string[] { "value1", "value2" };
        }
       /* [HttpGet]
        public  BsonDocument getUser()
        {
            client = new MongoClient();
            var db = client.GetDatabase("TrendingDB");
            var col = db.GetCollection<BsonDocument>("userDetails");
            var holder = new BsonDocument();
            using (var cursor =  col.Find(new BsonDocument()).ToCursor())
            {
                while ( cursor.MoveNext())
                {
                    foreach (var doc in cursor.Current) {
                        holder = doc;// new object({ doc. });
                    }
                }
            }
            Console.WriteLine(holder);
           // await col.InsertOneAsync(newReg);
            return holder;
        }*/
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
