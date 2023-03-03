using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow_MusicCMS.Models.Data
{
    public class Album 
    {
        public Album()
        {
  
        }

        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public string ImageAlbum { get; set; }

    }
}
