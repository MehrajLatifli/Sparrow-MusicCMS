// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using MusicCMS_Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCMS_Entities.Concrete.DatabaseFirst
{
    public partial class UserAccount : IEntity
    {
        public UserAccount()
        {
            NotificationFromUserAccountId_forNotificationNavigation = new HashSet<Notification>();
            NotificationToUserAccountId_forNotificationNavigation = new HashSet<Notification>();
            Playlist = new HashSet<Playlist>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUserAccount { get; set; }
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string UserEmail { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string UserPassword { get; set; }

        public virtual ICollection<Notification> NotificationFromUserAccountId_forNotificationNavigation { get; set; }
        public virtual ICollection<Notification> NotificationToUserAccountId_forNotificationNavigation { get; set; }
        public virtual ICollection<Playlist> Playlist { get; set; }
    }
}