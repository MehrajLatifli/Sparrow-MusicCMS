using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_Admin.Models.Data
{
    public class Radio
    {
        public int IdRadio { get; set; }
        public string RadioName { get; set; }
        public string ImageRadio { get; set; }
        public string RadioFile { get; set; }
        public string RadioDescription { get; set; }
        public string RadioCountry { get; set; }
    }
}
