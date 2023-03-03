using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_Admin.Models.Data
{
    public class PlaylistMusic
    {
        public PlaylistMusic()
        {

        }

        public int IdPlaylistMusic { get; set; }

        [JsonProperty(PropertyName = "playlistId_forPlaylistMusic")]
        public int PlaylistId_forPlaylistMusic { get; set; }

        [JsonProperty(PropertyName = "musicId_forPlaylistMusic")]
        public int MusicId_forPlaylistMusic { get; set; }



    }
}
