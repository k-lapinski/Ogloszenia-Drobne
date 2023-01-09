using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ogłoszenia_Drobne.Models
{
    public class Announcement
    {   [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        public DateTime Created = DateTime.Now;
        public string ImgPath { get; set; }
        public int NumberOfEntries { get; set; }

        public string IdAuthor { get; set; }

        public ICollection<Category> Categories { get; set; }

    }
}