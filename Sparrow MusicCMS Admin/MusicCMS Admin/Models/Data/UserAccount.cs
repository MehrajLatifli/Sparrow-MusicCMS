using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_Admin.Models.Data
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
