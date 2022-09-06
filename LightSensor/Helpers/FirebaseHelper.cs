using LightSensor.Models;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Firebase;
using Firebase.Database.Query;

namespace LightSensor.Helpers
{
    public class FirebaseHelper
    {
        
        
        public async Task<List<Esp>> GetAllEsps()
        {
            var val = new List<Esp>();
            try
            {
                 val= (await App.firebasClient
              .Child("Esp") 
              .OnceAsync<Esp>()).Select(item => new Esp
              {
                  Name = item.Object.Name,
                  Id = item.Object.Id,
                  SSID = item.Object.SSID,
                  Password = item.Object.Password,
                  IpAddress = item.Object.IpAddress,
                  IsActive = item.Object.IsActive.ToString(),
                  HasLight=item.Object.HasLight,
                  IsEmptyRoom=item.Object.IsEmptyRoom,
                  Manual=item.Object.Manual
              }).ToList();
            }
            catch (Exception ex) {
            }
            return val;
        }

        public async Task AddPerson()
        {
            try
            {
                await App.firebasClient
                  .Child("Esp")
                  .PostAsync(new Esp()
                  {
                      Id = "1",
                      Name = "MyEsp",
                      SSID = "MyNetwork",
                      IpAddress = "123.123.123.123",
                      IsActive = "1",
                      Password="aa",
                      HasLight="1",
                      IsEmptyRoom="1",
                      Manual="0"
                  }); 
            }
            catch(Exception ex)
            {

            }
            
        }

        public async Task SwitchToManual(string id,Esp contextEsp)
        {
            var toUpdateEsp = (await App.firebasClient
              .Child("Esp")
              .OnceAsync<Esp>()).Where(a => a.Object.Id.Equals(id) ).FirstOrDefault();

            await App.firebasClient
              .Child("Esp")
            .Child(toUpdateEsp.Key)
              .PutAsync(new Esp() 
              {  
                  Id=contextEsp.Id, 
                  Name=contextEsp.Name,
                  SSID=contextEsp.SSID,
                    IpAddress=contextEsp.IpAddress,
                     HasLight = contextEsp.HasLight,
                  IsEmptyRoom=contextEsp.IsEmptyRoom,
                      IsActive = contextEsp.IsActive,
                       Manual = contextEsp.Manual,
                        Password = contextEsp.Password
              });
        }

        public async Task ManualSwitchLight(string id, Esp contextEsp)
        {
            var toUpdateEsp = (await App.firebasClient
              .Child("Esp")
              .OnceAsync<Esp>()).Where(a => a.Object.Id.Equals(id)).FirstOrDefault();

            await App.firebasClient
              .Child("Esp")
            .Child(toUpdateEsp.Key)
              .PutAsync(new Esp() 
              {
                  Id = contextEsp.Id,
                  Name = contextEsp.Name,
                  SSID = contextEsp.SSID,
                  IpAddress = contextEsp.IpAddress,
                  HasLight = contextEsp.HasLight,
                  IsEmptyRoom = contextEsp.IsEmptyRoom,
                  IsActive = contextEsp.IsActive,
                  Manual = contextEsp.Manual,
                  Password = contextEsp.Password
              });
        }
    }
    
}
