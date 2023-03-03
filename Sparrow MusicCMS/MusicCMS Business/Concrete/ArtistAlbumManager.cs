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
    public class ArtistAlbumManager : IArtistAlbumService
    {
        private IArtistAlbumDAL _artistAlbumDAL;


        public ArtistAlbumManager(IArtistAlbumDAL artistAlbumDAL)
        {
            _artistAlbumDAL = artistAlbumDAL;
        }

        public void Add(ArtistAlbum item)
        {
            _artistAlbumDAL.Add(item);
        }



        public void Delete(ArtistAlbum item)
        {
            _artistAlbumDAL.Delete(item);
        }



        public List<ArtistAlbum> GetAll()
        {
            return _artistAlbumDAL.GetList();
        }


        public ArtistAlbum GetById(int Id)
        {
            return _artistAlbumDAL.Get(p => p.IdArtistAlbum == Id);
        }

        public List<ArtistAlbum> GetByArtist(int Id)
        {
            return _artistAlbumDAL.GetList(p => p.ArtistId_forArtistAlbum == Id || Id == 0);
        }

        public List<ArtistAlbum> GetByAlbum(int Id)
        {
            return _artistAlbumDAL.GetList(p => p.AlbumId_forArtistAlbum == Id || Id == 0);
        }

        public void Update(ArtistAlbum item)
        {
            _artistAlbumDAL.Update(item);
        }


    }
}
