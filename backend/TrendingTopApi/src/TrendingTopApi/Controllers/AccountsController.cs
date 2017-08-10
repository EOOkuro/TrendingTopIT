using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using TrendingTopApi.dbConfig;
using TrendingTopApi.objectFolder;

namespace AccountsController.Controllers
{

    [Route("api/[controller]")]
    //[EnableCors(o:"")]
    public class AccountsController : Controller
    {
        MongoClient client;
        
        [HttpGet]
        [ActionName("getUser")]
        public JsonResult GetUser(string userId,string pass)
        {
            client = new MongoClient();
            var db = client.GetDatabase(dbSet.DB_NAME);
            var col = db.GetCollection<UserRecord>("userDetails");
            var holder =  col.Find(x => x.baseRecords.userName == userId).FirstOrDefault();
            if (holder != null)
            {
                BaseData baseRec = new BaseData();
                ProfileRecord validProfile = new ProfileRecord();
                Posts[] postRecords = null;
                Friend[] friends = null;
                Gallery[] galleryItems = null;
                pass = Util.getHash(pass, holder.regRecords.passSalt);
                if (pass == holder.regRecords.password)
                {

                    #region get base records
                    if (holder.baseRecords != null)
                    {
                        baseRec = new BaseData()
                        {
                            emailAddress = holder.baseRecords.emailAddress,
                            userName = holder.baseRecords.userName,
                            dateRegistred = holder.baseRecords.dateRegistred,
                        };
                    }
                    #endregion

                    #region get profile records
                    if (holder.profile != null)
                    {
                        validProfile = new ProfileRecord()
                        {
                            gender = holder.profile.gender,
                            age = holder.profile.age,
                            height = holder.profile.height,
                            weight = holder.profile.weight,
                            country = holder.profile.country
                        };
                    }
                    #endregion

                    #region get all post
                    if (holder.postList != null)
                    {
                        var x = 0;
                        postRecords = new Posts[holder.postList.Length];
                        while (x < holder.postList.Length)
                        {
                            var postdetails =
                                new Posts()
                                {
                                    _id = holder.postList[x]._id,
                                    postText = holder.postList[x].postText,
                                    postDate = holder.postList[x].postDate,
                                    medias = holder.postList[x].medias,
                                    statsData = holder.postList[x].statsData,
                                    };
                            postRecords[x] = postdetails;
                            x++;
                        }
                    }
                    #endregion

                    #region get all friends
                    if (holder.friendList != null)
                    {
                        var x = 0;
                        friends = new Friend[holder.friendList.Length];
                        while (x < holder.friendList.Length)
                        {
                            var friendDetails =
                                new Friend()
                                {
                                    _id = holder.friendList[x]._id,
                                };
                            friends[x] = friendDetails;
                            x++;
                        }
                    }
                    #endregion

                    #region get gallery items
                    if (holder.galleryList != null)
                    {
                        var x = 0;
                        galleryItems = new Gallery[holder.galleryList.Length];
                        while (x < holder.galleryList.Length)
                        {
                            var galleryDetails =
                                new Gallery()
                                {
                                    _id = holder.galleryList[x]._id,
                                    statsData = holder.galleryList[x].statsData
                                };
                            galleryItems[x] = galleryDetails;
                            x++;
                        }
                    }
                    #endregion

                    #region populate and send return value
                    return new JsonResult(new UserRecord
                    {

                        _id = holder._id,
                        baseRecords = baseRec,
                        profile = validProfile,
                        postList = postRecords,
                        friendList = friends,
                        galleryList = galleryItems
                    });
                    #endregion

                }
                else
                {
                    return new JsonResult(new returnMSG
                    {
                        message = "invalid password",
                        value = false,
                    });
                }
            }
            else
            {
                return new JsonResult(new returnMSG
                {
                    message = "User record does not exist",
                    value = false,
                });
            }
        }

        //register new user account
        [HttpPost( Name = "userReg")]
        public returnMSG UserReg(RegData data) {
            
            #region validate that username and password was supplied

            returnMSG msg = null;
            if (data.password == null | data.password == "")
            {
                msg = new returnMSG
                {
                    message = "Password Cannot be null or empty",
                    value = false,
                };
                return msg;
            }
            
            if (data.userName == null | data.userName == "")
            {
                msg = new returnMSG
                {
                    message = "emailAddress Cannot be null or empty",
                    value = false,
                };
                return msg;
            }
            #endregion

            #region establsh connection to mongoDB
            client = new MongoClient();
            var db = client.GetDatabase(dbSet.DB_NAME);
            var col = db.GetCollection<UserRecord>("userDetails");
            #endregion

            #region check if user name or email exist
            if (data.userName == null | data.userName == "")
            {
                msg = new returnMSG
                {
                    message = "username Cannot be null or empty",
                    value = false,
                };
                return msg;
            }
            var existingUserName = col.Find(x => x.baseRecords.userName == data.userName).FirstOrDefault();
           
            if (existingUserName != null)
            {
                msg = new returnMSG
                {
                    message = "username already exist please select another name",
                    value = false,
                };
                return msg;
            }
            var existingEmail = col.Find(x => x.baseRecords.emailAddress == data.emailAddress).FirstOrDefault();
            if (existingEmail != null)
            {
                msg = new returnMSG
                {
                    message = "a user with this email already exist",
                    value = false,
                };
                return msg;
            }
            #endregion
            
            string salt = Util.getSalt();
            DateTime today = DateTime.Now;
            var newReg = new UserRecord
            {
                _id = Guid.NewGuid(),
                regRecords = new RegData
                {
                    dateRegistred = today,
                    passSalt = salt,
                    password = Util.getHash(data.password, salt)
                },
                baseRecords = new BaseData
                {
                    emailAddress = data.emailAddress,
                    userName = data.userName,
                }
            };
             col.InsertOneAsync(newReg);
             msg = new returnMSG
             {
                 message = "Registration Successful",
                 value = true,
             };
            return msg;
        }

        [HttpPut]
        public returnMSG updateUser(ProfileRecord rec,string userId)
        {
            Guid idObject = Guid.Parse(userId);
            client = new MongoClient();
            RegData validRegRec = new RegData();
            ProfileRecord validProfile = new ProfileRecord();
            var db = client.GetDatabase(dbSet.DB_NAME);
            var col = db.GetCollection<UserRecord>("userDetails");
            var msg = new returnMSG();
            var update = Builders<UserRecord>.Update.Set(x => x.profile, rec);
            var result = col.UpdateOne(user => user._id == idObject, update);
            return new returnMSG
            {
                message = "Record updated successful",
                value = true
            };
        }
    }
}
