using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ogłoszenia_Drobne.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime Created = DateTime.Now;
        public string ImgPath { get; set; }
        public int IdAuthor { get; set; }
        public int IdCategory { get; set; }

        public ICollection<Category> Categories { get; set; }

    }
}