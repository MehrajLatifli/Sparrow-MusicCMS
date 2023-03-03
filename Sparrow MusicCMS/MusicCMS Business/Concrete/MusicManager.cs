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
    public class MusicManager : IMusicService
    {
        private IMusicDAL _musicDAL;


        public MusicManager(IMusicDAL musicDAL)
        {
            _musicDAL = musicDAL;
        }

        public void Add(Music item)
        {
            _musicDAL.Add(item);
        }



        public void Delete(Music item)
        {
            _musicDAL.Delete(item);
        }



        public List<Music> GetAll()
        {
            return _musicDAL.GetList();
        }

        public Music GetById(int Id)
        {
            return _musicDAL.Get(p => p.IdMusic == Id);
        }

        public void Update(Music item)
        {
            _musicDAL.Update(item);
        }



    

 
    }
}
