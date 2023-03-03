using MusicCMS_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicCMS_Business.Abstract
{
    public interface IPlaylistService
    {
        List<Playlist> GetAll();
        List<Playlist> GetByUser(int Id);

        void Add(Playlist item);
        void Update(Playlist item);
        void Delete(Playlist item);
        Playlist GetById(int Id);
    }
}
