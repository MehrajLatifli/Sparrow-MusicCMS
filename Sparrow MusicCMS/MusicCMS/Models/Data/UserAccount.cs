// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MusicCMS.Models.Data
{
    public class UserAccount
    {
        public UserAccount()
        {

        }

        public int IdUserAccount { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string UserEmail { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string UserPassword { get; set; }


    }
}