using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ogłoszenia_Drobne.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }

        public DateTime Created = DateTime.Now;
        public string ImgPath { get; set; }
        public int IdAuthor { get; set; }
        public int IdCategory { get; set; }

        public ICollection<Category> Categories { get; set; }

    }
}