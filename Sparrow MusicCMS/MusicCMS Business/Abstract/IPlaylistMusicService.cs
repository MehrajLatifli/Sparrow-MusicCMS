using MusicCMS_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicCMS_Business.Abstract
{
    public interface IPlaylistMusicService
    {
        List<PlaylistMusic> GetAll();
        List<PlaylistMusic> GetByPlaylist(int Id);
        List<PlaylistMusic> GetByMusic(int Id);

        void Add(PlaylistMusic item);
        void Update(PlaylistMusic item);
        void Delete(PlaylistMusic item);
        PlaylistMusic GetById(int Id);
    }
}
