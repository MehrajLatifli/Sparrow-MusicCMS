using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow_MusicCMS.Models.Data
{
    public  class ArtistAlbum 
    {
      
        public int IdArtistAlbum { get; set; }
        public int ArtistId_forArtistAlbum { get; set; }
        public int AlbumId_forArtistAlbum { get; set; }


    }
}
