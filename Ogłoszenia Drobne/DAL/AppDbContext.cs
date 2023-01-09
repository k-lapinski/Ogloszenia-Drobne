using Ogłoszenia_Drobne.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ogłoszenia_Drobne.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }


    }
}