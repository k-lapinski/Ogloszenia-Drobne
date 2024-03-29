﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Ogłoszenia_Drobne.Models;

namespace Ogłoszenia_Drobne
{
    public class AnnouncementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Announcements
        public ActionResult Index(string search)
        {
            if (search == null)
            {
                return View(db.Announcements.ToList());
            }
            //return View(db.Announcements.ToList());
            else {
                return View(db.Announcements.Where(x => x.Title.Contains(search)).ToList());
            }

        }

        public ActionResult My(string search)
        {
            if (search == null)
            {
                return View(db.Announcements.ToList());
            }
            //return View(db.Announcements.ToList());
            else
            {
                return View(db.Announcements.Where(x => x.Title.Contains(search)).ToList());
            }

        }


        // GET: Announcements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcements.Find(id);
            var numOfEntries = announcement.NumberOfEntries++;
            db.Database.ExecuteSqlCommand("UPDATE Announcements SET NumberOfEntries = " + numOfEntries + "WHERE Id= {0}" , id);
            db.SaveChanges();

            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // GET: Announcements/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Address,ImgPath,NumberOfEntries,IdAuthor")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                List<Dictionary> listDictionary = db.Dictionaries.ToList();

                foreach(Dictionary dictionary in listDictionary)
                {
                    if (announcement.Title.Contains(dictionary.Name)) { 
                    string[] subs = announcement.Title.Split(' ');
                    announcement.Title = " ";
                    for (int i = 0; i < subs.Length; i++) {
                        if (subs[i].Contains(dictionary.Name))  {
                            subs[i] = " *** ";
                        } }
                        for (int i = 0; i < subs.Length; i++) { 
                        announcement.Title += subs[i];
                        }

                    }

                    if (announcement.Description.Contains(dictionary.Name))
                    {
                        string[] subs = announcement.Title.Split(' ');
                        announcement.Description = " ";
                        for (int i = 0; i < subs.Length; i++)
                        {
                            if (subs[i].Contains(dictionary.Name))
                            {
                                subs[i] = " *** ";
                            }
                        }
                        for (int i = 0; i < subs.Length; i++)
                        {
                            announcement.Description += subs[i];
                        }

                    }

                    if (announcement.Address.Contains(dictionary.Name))
                    {
                        string[] subs = announcement.Title.Split(' ');
                        announcement.Address = " ";
                        for (int i = 0; i < subs.Length; i++)
                        {
                            if (subs[i].Contains(dictionary.Name))
                            {
                                subs[i] = " *** ";
                            }
                        }
                        for (int i = 0; i < subs.Length; i++)
                        {
                            announcement.Address += subs[i];
                        }

                    }

                }

                var userId = User.Identity.GetUserId();
                announcement.IdAuthor = userId;
                db.Announcements.Add(announcement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName", announcement.Categories);
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Address,ImgPath,NumberOfEntries,IdAuthor")] Announcement announcement)
        {
            List<Dictionary> listDictionary = db.Dictionaries.ToList();

            foreach (Dictionary dictionary in listDictionary)
            {
                if (announcement.Title.Contains(dictionary.Name))
                {
                    string[] subs = announcement.Title.Split(' ');
                    announcement.Title = " ";
                    for (int i = 0; i < subs.Length; i++)
                    {
                        if (subs[i].Contains(dictionary.Name))
                        {
                            subs[i] = " *** ";
                        }
                    }
                    for (int i = 0; i < subs.Length; i++)
                    {
                        announcement.Title += subs[i];
                    }

                }

                if (announcement.Description.Contains(dictionary.Name))
                {
                    string[] subs = announcement.Title.Split(' ');
                    announcement.Description = " ";
                    for (int i = 0; i < subs.Length; i++)
                    {
                        if (subs[i].Contains(dictionary.Name))
                        {
                            subs[i] = " *** ";
                        }
                    }
                    for (int i = 0; i < subs.Length; i++)
                    {
                        announcement.Description += subs[i];
                    }

                }

                if (announcement.Address.Contains(dictionary.Name))
                {
                    string[] subs = announcement.Title.Split(' ');
                    announcement.Address = " ";
                    for (int i = 0; i < subs.Length; i++)
                    {
                        if (subs[i].Contains(dictionary.Name))
                        {
                            subs[i] = " *** ";
                        }
                    }
                    for (int i = 0; i < subs.Length; i++)
                    {
                        announcement.Address += subs[i];
                    }

                }

            }


            if (ModelState.IsValid)
            {  
                announcement.IdAuthor = User.Identity.GetUserId();
                db.Entry(announcement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

     
        // GET: Announcements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Announcement announcement = db.Announcements.Find(id);
            db.Announcements.Remove(announcement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
