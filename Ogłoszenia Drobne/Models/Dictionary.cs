using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ogłoszenia_Drobne.Models
{
    public class Dictionary
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}