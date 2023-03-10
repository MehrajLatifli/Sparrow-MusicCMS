using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS.Models
{
    public class LogIn
    {
        public LogIn()
        {

        }

        public int IdUserAccount { get; set; }

        public string Username { get; set; }

        public string UserPassword { get; set; }

        public async Task Serialize(LogIn item, string filepath)
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

        public async Task <LogIn> DeSerialize(string filepath)
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

            return JsonConvert.DeserializeObject<LogIn>(data);
        }

    }
}
