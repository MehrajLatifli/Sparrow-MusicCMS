﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using MusicCMS_Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCMS_Entities.Concrete.DatabaseFirst
{
    public partial class ArtistAlbum : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArtistAlbum { get; set; }
        public int ArtistId_forArtistAlbum { get; set; }
        public int AlbumId_forArtistAlbum { get; set; }

        public virtual Album AlbumId_forArtistAlbumNavigation { get; set; }
        public virtual Artist ArtistId_forArtistAlbumNavigation { get; set; }
    }
}