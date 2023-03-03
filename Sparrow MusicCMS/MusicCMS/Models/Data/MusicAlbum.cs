using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow_MusicCMS.Models.Data
{
    public class MusicAlbum 
    {

        public int IdMusicAlbum { get; set; }
        public int MusicId_forMusicAlbum { get; set; }
        public int AlbumId_forMusicAlbum { get; set; }

    }
}
