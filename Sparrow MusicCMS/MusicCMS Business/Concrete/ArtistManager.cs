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
    public class ArtistManager : IArtistService
    {
        private IArtistDAL _artistDAL;


        public ArtistManager(IArtistDAL artistDAL)
        {
            _artistDAL = artistDAL;
        }

        public void Add(Artist item)
        {
            _artistDAL.Add(item);
        }

        public void Delete(Artist item)
        {
            _artistDAL.Delete(item);
        }

        public List<Artist> GetAll()
        {
            return _artistDAL.GetList();
        }

        public Artist GetById(int Id)
        {
            return _artistDAL.Get(p => p.IdArtist == Id);
        }

        public void Update(Artist item)
        {
            _artistDAL.Update(item);
        }
    }
}
