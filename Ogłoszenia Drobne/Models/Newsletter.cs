using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ogłoszenia_Drobne.Models
{
    public class Newsletter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        public string Author { get; set; }
    }
}