using MusicCMS_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicCMS_Business.Abstract
{
    public interface IUserAccountService
    {
        List<UserAccount> GetAll();

        void Add(UserAccount item);
        void Update(UserAccount item);
        void Delete(UserAccount item);
        UserAccount GetById(int Id);
    }
}
