using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrendingTopApi.objectFolder
{
    public class objectClass
    {
    }

    //data format for registration
    public class RegData
    {
       
        public string emailAddress { get; set; }
        public DateTime dateRegistred { get; set; }
        public string userName { get; set; }
        public string passSalt { get; set; }
        public string password { get; set; }
    }

    //data format for userRecords
    public class userRecord
    {
        public Object _id { get; set; }
        public RegData baseRecords { get; set; }
        public profileRecord profile { get; set; }
    }

    public class profileRecord
    {
        public string gender { get; set; }
        public int age { get; set; }
        public decimal height { get; set; }
        public decimal weight { get; set; }
        public string country { get; set; }
    }

    public class returnMSG
    {
        public string message { get; set; }
        public bool value { get; set; }
    }

}
