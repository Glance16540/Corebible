using System;

using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Corebible.Models;
using Corebible.Models.CodeFirst;
using Microsoft.AspNet.Identity;

namespace Corebible.Controllers
{
    public class OtherUsersController : Universal
    {
       

        // GET: OtherUsers
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: OtherUsers/Details/5
        public ActionResult PersonProfile( string id,OtherUsers otherusers)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            var user = db.Users.Find(id);
            if (user.Id != null)
            {
                var timezones = TimeZoneInfo.GetSystemTimeZones();
                ViewBag.TimeZone = new SelectList(timezones, "Id", "Id");
                var Profile = db.Users.Find(user.Id);
                return View(Profile);
            }
          
                        
            //if (otherusers == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // GET: OtherUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OtherUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] OtherUsers otherUsers)
        {
            if (ModelState.IsValid)
            {
                db.otherusers.Add(otherUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(otherUsers);
        }

        // GET: OtherUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherUsers otherUsers = db.otherusers.Find(id);
            if (otherUsers == null)
            {
                return HttpNotFound();
            }
            return View(otherUsers);
        }

        // POST: OtherUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] OtherUsers otherUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otherUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(otherUsers);
        }

        // GET: OtherUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherUsers otherUsers = db.otherusers.Find(id);
            if (otherUsers == null)
            {
                return HttpNotFound();
            }
            return View(otherUsers);
        }

        // POST: OtherUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OtherUsers otherUsers = db.otherusers.Find(id);
            db.otherusers.Remove(otherUsers);
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
