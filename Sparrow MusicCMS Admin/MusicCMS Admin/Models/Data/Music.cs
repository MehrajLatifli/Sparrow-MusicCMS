using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_Admin.Models.Data
{
    public class Music
    {
        public Music()
        {

        }

        public int IdMusic { get; set; }
        public string MusicName { get; set; }
        public bool IsPopularMusic { get; set; }
        public string ImageMusic { get; set; }
        public string MusicFile { get; set; }


        public async Task Serialize(Music item, string filepath)
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

        public async Task<Music> DeSerialize(string filepath)
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

            return JsonConvert.DeserializeObject<Music>(data);
        }

    }
}
