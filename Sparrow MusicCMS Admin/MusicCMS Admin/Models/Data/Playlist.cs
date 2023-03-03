using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_Admin.Models.Data
{
    public class Playlist
    {

        public Playlist()
        {

        }

        public int IdPlaylist { get; set; }

        [JsonProperty(PropertyName = "playlistName")]
        public string PlaylistName { get; set; }
        [JsonProperty(PropertyName = "playlistDescription")]
        public string PlaylistDescription { get; set; }
        [JsonProperty(PropertyName = "playlistDatetime")]
        public string PlaylistDatetime { get; set; }
        [JsonProperty(PropertyName = "imagePlaylist")]
        public string ImagePlaylist { get; set; }
        [JsonProperty(PropertyName = "userAccountId_forPlaylist")]
        public int UserAccountId_forPlaylist { get; set; }


        public async Task Serialize(Playlist item, string filepath)
        {
            try
            {

                var f = Newtonsoft.Json.Formatting.Indented;
                string data = JsonConvert.SerializeObject(item, f);


                using (var swriter = new StreamWriter(filepath, false))
                {
                    await swriter.WriteAsync(data);
                }

            }
            catch (Exception)
            {

            }

        }

        public async Task<Playlist> DeSerialize(string filepath)
        {
            string data = string.Empty;
            try
            {

                if (System.IO.File.Exists(filepath))
                {
                    data = System.IO.File.ReadAllTextAsync(filepath).Result;




                }
                if (!System.IO.File.Exists(filepath))
                {
                    System.IO.File.Create(filepath).Close();
                }
            }
            catch (Exception)
            {

            }

            return JsonConvert.DeserializeObject<Playlist>(data);
        }

    }
}
