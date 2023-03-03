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
    public class MusicAlbumManager : IMusicAlbumService
    {
        private IMusicAlbumDAL _musicAlbumDAL;


        public MusicAlbumManager(IMusicAlbumDAL musicAlbumDAL)
        {
            _musicAlbumDAL = musicAlbumDAL;
        }

        public void Add(MusicAlbum item)
        {
            _musicAlbumDAL.Add(item);
        }



        public void Delete(MusicAlbum item)
        {
            _musicAlbumDAL.Delete(item);
        }



        public List<MusicAlbum> GetAll()
        {
            return _musicAlbumDAL.GetList();
        }

        public List<MusicAlbum> GetByAlbum(int Id)
        {
            return _musicAlbumDAL.GetList(p => p.AlbumId_forMusicAlbum == Id || Id == 0);
        }

        public MusicAlbum GetById(int Id)
        {
            return _musicAlbumDAL.Get(p => p.IdMusicAlbum == Id);
        }

        public List<MusicAlbum> GetByMusic(int Id)
        {
            return _musicAlbumDAL.GetList(p => p.MusicId_forMusicAlbum == Id || Id == 0);
        }

        public void Update(MusicAlbum item)
        {
            _musicAlbumDAL.Update(item);
        }

    }
}
