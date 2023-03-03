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
    public class NotificationManager : INotificationService
    {
        private INotificationDAL _notificationDAL;


        public NotificationManager(INotificationDAL notificationDAL)
        {
            _notificationDAL = notificationDAL;
        }

        public void Add(Notification item)
        {
            _notificationDAL.Add(item);
        }



        public void Delete(Notification item)
        {
            _notificationDAL.Delete(item);
        }



        public List<Notification> GetAll()
        {
            return _notificationDAL.GetList();
        }

        public Notification GetById(int Id)
        {
            return _notificationDAL.Get(p => p.IdNotification == Id);
        }

        public void Update(Notification item)
        {
            _notificationDAL.Update(item);
        }



    

 
    }
}
