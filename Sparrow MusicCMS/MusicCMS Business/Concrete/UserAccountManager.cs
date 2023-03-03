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
    public class UserAccountManager : IUserAccountService
    {
        private IUserAccountDAL _userAccountDAL;


        public UserAccountManager(IUserAccountDAL userAccountDAL)
        {
            _userAccountDAL = userAccountDAL;
        }

        public void Add(UserAccount item)
        {
            _userAccountDAL.Add(item);
        }



        public void Delete(UserAccount item)
        {
            _userAccountDAL.Delete(item);
        }



        public List<UserAccount> GetAll()
        {
            return _userAccountDAL.GetList();
        }

        public UserAccount GetById(int Id)
        {
            return _userAccountDAL.Get(p => p.IdUserAccount == Id);
        }

        public void Update(UserAccount item)
        {
            _userAccountDAL.Update(item);
        }



    

 
    }
}
