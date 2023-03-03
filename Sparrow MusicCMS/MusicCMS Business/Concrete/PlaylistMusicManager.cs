using MusicCMS_Business.Abstract;
using MusicCMS_DataAccess.Abstract;
using MusicCMS_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_Business.Concrete
{
    public class PlaylistMusicManager : IPlaylistMusicService
    {
        private IPlaylistMusicDAL _playlistMusicDAL;


        public PlaylistMusicManager(IPlaylistMusicDAL playlistMusicnDAL)
        {
            _playlistMusicDAL = playlistMusicnDAL;
        }

        public void Add(PlaylistMusic item)
        {
            _playlistMusicDAL.Add(item);
        }



        public void Delete(PlaylistMusic item)
        {
            _playlistMusicDAL.Delete(item);
        }



        public List<PlaylistMusic> GetAll()
        {
            return _playlistMusicDAL.GetList();
        }

        public PlaylistMusic GetById(int Id)
        {
            return _playlistMusicDAL.Get(p => p.IdPlaylistMusic == Id);
        }

        public List<PlaylistMusic> GetByMusic(int Id)
        {
            return _playlistMusicDAL.GetList(p => p.MusicId_forPlaylistMusic == Id || Id == 0);
        }

        public List<PlaylistMusic> GetByPlaylist(int Id)
        {
            return _playlistMusicDAL.GetList(p => p.PlaylistId_forPlaylistMusic == Id || Id == 0);
        }

        public void Update(PlaylistMusic item)
        {
            _playlistMusicDAL.Update(item);
        }



    

 
    }
}
