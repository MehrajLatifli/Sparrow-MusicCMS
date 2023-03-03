using MusicCMS_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicCMS_Business.Abstract
{
    public interface IMusicService
    {
        List<Music> GetAll();

        void Add(Music item);
        void Update(Music item);
        void Delete(Music item);
        Music GetById(int Id);
    }
}
