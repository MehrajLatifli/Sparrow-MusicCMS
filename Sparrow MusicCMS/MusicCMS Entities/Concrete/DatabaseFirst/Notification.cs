// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using MusicCMS_Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCMS_Entities.Concrete.DatabaseFirst
{
    public partial class Notification : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNotification { get; set; }
        public string Messageactivity { get; set; }
        public string NotificationDatetime { get; set; }
        public int FromUserAccountId_forNotification { get; set; }
        public int ToUserAccountId_forNotification { get; set; }

        public virtual UserAccount FromUserAccountId_forNotificationNavigation { get; set; }
        public virtual UserAccount ToUserAccountId_forNotificationNavigation { get; set; }
    }
}