﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using MusicCMS_Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCMS_Entities.Concrete.DatabaseFirst
{
    public partial class Radio : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRadio { get; set; }
        public string RadioName { get; set; }
        public string ImageRadio { get; set; }
        public string RadioFile { get; set; }
        public string RadioDescription { get; set; }
        public string RadioCountry { get; set; }
    }
}