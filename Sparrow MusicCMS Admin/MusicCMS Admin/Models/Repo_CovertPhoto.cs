using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_Admin.Models
{
    public class Repo_CovertPhoto
    {
        public List<ImagesforCover> GetAll()
        {

            return new List<ImagesforCover>
            {
                       new ImagesforCover
                       {

                         FilePath1 = "../../Asserts/Images/Images/Logo.gif",
                         FilePath2 = "../../Asserts/Images/Images/Logo2.gif",

                       },
            };
        }
    }
}
