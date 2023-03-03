using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_Admin.Models.Data
{
    public class ArtistAlbum
    {

        public int IdArtistAlbum { get; set; }
        public int ArtistId_forArtistAlbum { get; set; }
        public int AlbumId_forArtistAlbum { get; set; }


    }
}
