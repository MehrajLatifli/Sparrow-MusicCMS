using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_Admin.Models.Data
{
    public class MusicAlbum
    {

        public int IdMusicAlbum { get; set; }
        public int MusicId_forMusicAlbum { get; set; }
        public int AlbumId_forMusicAlbum { get; set; }

    }
}
