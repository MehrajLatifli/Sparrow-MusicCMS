using MusicCMS_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicCMS_Business.Abstract
{
    public interface IMusicAlbumService
    {
        List<MusicAlbum> GetAll();
        List<MusicAlbum> GetByMusic(int Id);
        List<MusicAlbum> GetByAlbum(int Id);

        void Add(MusicAlbum item);
        void Update(MusicAlbum item);
        void Delete(MusicAlbum item);
        MusicAlbum GetById(int Id);
    }
}
