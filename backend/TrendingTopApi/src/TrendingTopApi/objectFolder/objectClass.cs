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
    public class UserRecord
    {
        public Object _id { get; set; }
        public RegData regRecords { get; set; }
        public BaseData baseRecords { get; set; }
        public ProfileRecord profile { get; set; }
        public Posts[] postList { get; set; }
        public Friend[] friendList { get; set; }
        public Gallery[] galleryList { get; set; }
    }
    
    
    //data format for registration
    public class BaseData
    {

        public string emailAddress { get; set; }
        public DateTime dateRegistred { get; set; }
        public string userName { get; set; }
    }

    //data format for profile record
    public class ProfileRecord
    {
        public string  gender { get; set; }
        public string age { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string  country { get; set; }
    }

    //data format for friend List
    public class Friend
    {
        public Object _id { get; set; }
    }

    //data format for posts
    public class Posts
    {
        public Object   _id { get; set; }
        public string   postText { get; set; }
        public DateTime postDate { get; set; }
        public Media[]  medias { get; set; }
        public Stats    statsData { get; set; }
    }

    //data format for media
    public class Media
    {
        public Object _id { get; set; }
        public string mediaType { get; set; }
        public string mediaLink { get; set; }
    }

    //data format for Stats
    public class Stats
    {
        public Object _id { get; set; }
        public int likeCount { get; set; }
        public int viewCount { get; set; }
        public int follwersCount { get; set; }
    }

    //data format for Gallery
    public class Gallery
    {
        public Object _id { get; set; }
        public Stats statsData { get; set; }
    }

    //data format for response message
    public class returnMSG
    {
        public string message { get; set; }
        public bool value { get; set; }
    }
    
}
