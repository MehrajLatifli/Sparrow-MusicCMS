using MusicCMS_Business.Abstract;
using MusicCMS_DataAccess.Abstract;
using MusicCMS_DataAccess.Concrete;
using MusicCMS_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_Business.Concrete
{
    public class PlaylistManager : IPlaylistService
    {
        private IPlaylistDAL _playlistDAL;


        public PlaylistManager(IPlaylistDAL playlistDAL)
        {
            _playlistDAL = playlistDAL;
        }

        public void Add(Playlist item)
        {
            _playlistDAL.Add(item);
        }



        public void Delete(Playlist item)
        {
            _playlistDAL.Delete(item);
        }



        public List<Playlist> GetAll()
        {
            return _playlistDAL.GetList();
        }

        public Playlist GetById(int Id)
        {
            return _playlistDAL.Get(p => p.IdPlaylist == Id);
        }

        public List<Playlist> GetByUser(int Id)
        {
            return _playlistDAL.GetList(p => p.UserAccountId_forPlaylist == Id || Id == 0);
        }

        public void Update(Playlist item)
        {
            _playlistDAL.Update(item);
        }



    

 
    }
}
