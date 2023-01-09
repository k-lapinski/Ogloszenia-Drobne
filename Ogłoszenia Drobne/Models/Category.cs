﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ogłoszenia_Drobne.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

       
        public ICollection<Announcement> Announcements { get; set; }

    }
}