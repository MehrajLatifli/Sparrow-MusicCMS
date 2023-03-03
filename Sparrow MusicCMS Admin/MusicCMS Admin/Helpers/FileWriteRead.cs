using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_Admin.Helpers
{
    public static class FileWriteRead<T>
    {
        public static void WriteToFile(string filepath, ObservableCollection<T> list)
        {
            try
            {
                var serializer = new JsonSerializer();


                using (var sw = new StreamWriter(filepath, true))
                {
                    using (var jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Newtonsoft.Json.Formatting.Indented;


                        serializer.Serialize(jw, list);
                    }
                }
            }
            catch (Exception)
            {


            }


        }

        public static ObservableCollection<T> ReadToFile(string filepath, ObservableCollection<T> list)
        {
            try
            {

                list = null;

                var serializer = new JsonSerializer();

                using (var sr = new StreamReader(filepath))
                {
                    using (var jr = new JsonTextReader(sr))
                    {
                        list = serializer.Deserialize<ObservableCollection<T>>(jr);
                    }

                }
            }
            catch (Exception)
            {

            }
            return list;
        }
    }
}
