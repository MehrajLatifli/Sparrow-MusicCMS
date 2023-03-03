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
    public class AlbumManager : IAlbumService
    {
        private IAlbumDAL _albumDAL;

        public AlbumManager(IAlbumDAL albumDAL)
        {
            _albumDAL = albumDAL;
        }

        public void Add(Album item)
        {
            _albumDAL.Add(item);
        }

        public void Delete(Album item)
        {
            _albumDAL.Delete(item);
        }

        public List<Album> GetAll()
        {
            return _albumDAL.GetList();
        }

        public Album GetById(int Id)
        {
            return _albumDAL.Get(p => p.IdAlbum == Id);
        }

        public void Update(Album item)
        {
            _albumDAL.Update(item);
        }
    }
}
