using MusicCMS_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicCMS_Business.Abstract
{
    public interface INotificationService
    {
        List<Notification> GetAll();

        void Add(Notification item);
        void Update(Notification item);
        void Delete(Notification item);
        Notification GetById(int Id);
    }
}
