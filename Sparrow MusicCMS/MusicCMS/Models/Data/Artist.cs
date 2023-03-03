using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow_MusicCMS.Models.Data
{
    public  class Artist 
    {
        public Artist()
        {
           
        }

        public int IdArtist { get; set; }
        public string ArtistName { get; set; }
        public string ImageArtist { get; set; }

    }
}
