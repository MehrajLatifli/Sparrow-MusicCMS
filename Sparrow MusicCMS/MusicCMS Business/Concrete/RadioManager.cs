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
    public class RadioManager : IRadioService
    {
        private IRadioDAL _radioDAL;


        public RadioManager(IRadioDAL radioDAL)
        {
            _radioDAL = radioDAL;
        }

        public void Add(Radio item)
        {
            _radioDAL.Add(item);
        }



        public void Delete(Radio item)
        {
            _radioDAL.Delete(item);
        }



        public List<Radio> GetAll()
        {
            return _radioDAL.GetList();
        }

        public Radio GetById(int Id)
        {
            return _radioDAL.Get(p => p.IdRadio == Id);
        }

        public void Update(Radio item)
        {
            _radioDAL.Update(item);
        }



    

 
    }
}
