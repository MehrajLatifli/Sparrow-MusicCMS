using MusicCMS_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicCMS_Business.Abstract
{
    public interface IAlbumService
    {
        List<Album> GetAll();

        void Add(Album item);
        void Update(Album item);
        void Delete(Album item);
        Album GetById(int Id);
    }
}
