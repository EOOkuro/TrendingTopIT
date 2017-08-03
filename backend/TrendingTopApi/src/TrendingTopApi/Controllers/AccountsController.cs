using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TrendingTopApi.dbConfig;
using TrendingTopApi.objectFolder;


namespace AccountsController.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        MongoClient client;
        
        [HttpGet]
        public JsonResult GetUser(string userId,string pass)
        {
            client = new MongoClient();
            RegData validRegRec = new RegData();
            profileRecord validProfile = new profileRecord();
            var db = client.GetDatabase(dbSet.DB_NAME);
            var col = db.GetCollection<userRecord>("userDetails");
            var holder =  col.Find(x => x.baseRecords.userName == userId).FirstOrDefault();
            if (holder != null)
            {
                validRegRec = new RegData()
                {
                    emailAddress = holder.baseRecords.emailAddress,
                   // passSalt = holder.baseRecords.passSalt,
                    userName = holder.baseRecords.userName,
                   // password = holder.baseRecords.password,
                };
                if (holder.profile != null)
                {
                    validProfile = new profileRecord()
                    {
                        gender = holder.profile.gender,
                        age = holder.profile.age,
                        height = holder.profile.height,
                        weight = holder.profile.weight,
                        country = holder.profile.country
                    };
                }
                pass = Util.getHash(pass, holder.baseRecords.passSalt);
                if (pass == holder.baseRecords.password)
                {
                    return new JsonResult(new userRecord {

                        _id = holder._id,
                        baseRecords = validRegRec,
                       
                    });
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

            /* var holder = col.Find(new BsonDocument()).ToList();
               json = new RegData[holder.Count];
               var x = 0;
               if (holder.Count> 0)
               {
                   while (x < holder.Count)
                   {
                       var detail =
                           new RegData()
                           {
                               _id = holder[x]._id,
                               emailAddress = holder[x].emailAddress,
                               userName = holder[x].userName,
                               password = holder[x].password,
                           };
                       json[x] = detail;
                       x++;
                   }
               }
              using (var cursor = col.Find(new BsonDocument()).ToCursor())
               {
                   while (cursor.MoveNext())
                   {
                       foreach (var doc in cursor.Current)
                       {
                            json = JArray.Parse(doc.ToJson());
                           //holder.(doc);// new object({ doc. });
                       }
                   }
               }*/
            // Console.WriteLine(col);
            // await col.InsertOneAsync(newReg);
           // return new JsonResult(json);
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
            db.DropCollection("userDetails");
            var col = db.GetCollection<userRecord>("userDetails");
            #endregion
            
            #region check if user name or email exist
            var existingUserName = col.Find(new BsonDocument("baseRecords.userName", data.userName)).FirstOrDefault();
            if (data.userName == null | data.userName == "")
            {
                msg = new returnMSG
                {
                    message = "username Cannot be null or empty",
                    value = false,
                };
                return msg;
            }
            if (existingUserName != null)
            {
                msg = new returnMSG
                {
                    message = "username already exist please select another name",
                    value = false,
                };
                return msg;
            }
            var existingEmail = col.Find(new BsonDocument("baseRecords.emailAddress", data.emailAddress)).FirstOrDefault();
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
            var newReg = new userRecord
            {
                _id = Guid.NewGuid(),
                baseRecords = new RegData
                {
                    emailAddress = data.emailAddress,
                    userName = data.userName,
                    dateRegistred = DateTime.Now,
                    passSalt = salt,
                    password = Util.getHash(data.password, salt)
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
        public returnMSG UpdateUser(profileRecord profile,string Userid)
        {
            client = new MongoClient();
            RegData validRegRec = new RegData();
            profileRecord validProfile = new profileRecord();
            var db = client.GetDatabase(dbSet.DB_NAME);
            var col = db.GetCollection<userRecord>("userDetails");
            var msg = new returnMSG();
            var holder = col.Find(x => x._id == Userid).FirstOrDefault();



            return msg;
        }
    }
}
