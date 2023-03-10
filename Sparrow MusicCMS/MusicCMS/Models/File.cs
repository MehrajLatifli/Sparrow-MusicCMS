

using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MusicCMS.Models
{
    [Serializable]
    public class File
    {
        public File()
        {

        }

        public string IdFile { get; set; }
        public string FileName { get; set; }
        public string FileImage { get; set; }
        public string FilePath { get; set; }

        public async Task Serialize(File item, string filepath)
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

        public async Task <File> DeSerialize(string filepath)
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



            return JsonConvert.DeserializeObject<File>(data);
        }
    }
}
