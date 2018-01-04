using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Corebible.Models;
using Corebible.Models.CodeFirst;
using Microsoft.AspNet.Identity;
using System.IO;

namespace Corebible.Controllers
{
    [Authorize]
    public class GroupsController : Universal
    {
        // GET: Groups
        public ActionResult Index(int? id)
        {
            var user = db.Users.Find(User.Identity.GetUserId());

            return View(user.Groups.ToList());
        }

        // GET: Groups/AllGroups
        public ActionResult Featured()
        {
            return View(db.Group.ToList());
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = db.Group.Find(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Active,OwnerId,Created,Image")] Groups groups, HttpPostedFileBase image)
        {
            var pPic = "/Assets/images/Profile_avatar_placeholder_large.png";

            if (image != null && image.ContentLength > 0)
            {
                var ext = Path.GetExtension(image.FileName).ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".bmp")
                    ModelState.AddModelError("image", "Invalid Format.");
            }

            if (ModelState.IsValid)
            {
                var user = db.Users.Find(User.Identity.GetUserId());

                if (image != null)
                {
                    //Counter
                    var num = 0;
                    //Gets Filename without the extension
                    var fileName = Path.GetFileNameWithoutExtension(image.FileName);
                    pPic = Path.Combine("/Assets/GroupImages/", fileName + Path.GetExtension(image.FileName));
                    //Checks if pPic matches any of the current attachments, 
                    //if so it will loop and add a (number) to the end of the filename
                    while (db.Group.AsNoTracking().Any(g => g.Image == pPic))
                    {
                        //Sets "filename" back to the default value
                        fileName = Path.GetFileNameWithoutExtension(image.FileName);
                        //Add's parentheses after the name with a number ex. filename(4)
                        fileName = string.Format(fileName + "(" + ++num + ")");
                        //Makes sure pPic gets updated with the new filename so it could check
                        pPic = Path.Combine("/Assets/GroupImages/", fileName + Path.GetExtension(image.FileName));
                    }
                    image.SaveAs(Path.Combine(Server.MapPath("~/Assets/GroupImages/"), fileName + Path.GetExtension(image.FileName)));
                }
                var defaultProfilePic = "~/Assets/images/Profile_avatar_placeholder_large.png";
                if (String.IsNullOrWhiteSpace(pPic))
                {
                    pPic = defaultProfilePic;
                }

                groups.Created = DateTime.UtcNow;
                groups.OwnerId = User.Identity.GetUserId();
                groups.Active = true;
                groups.Image = pPic;

                user.Groups.Add(groups);

                db.Group.Add(groups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groups);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = db.Group.Find(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberCount,Name,Description,Active,OwnerId,Created")] Groups groups, HttpPostedFileBase image)
        {
            var pPic = "/Assets/images/Profile_avatar_placeholder_large.png";

            if (image != null && image.ContentLength > 0)
            {
                var ext = Path.GetExtension(image.FileName).ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".bmp")
                    ModelState.AddModelError("image", "Invalid Format.");
            }

            if (ModelState.IsValid)
            {
                var user = db.Users.Find(User.Identity.GetUserId());

                if (image != null)
                {
                    //Counter
                    var num = 0;
                    //Gets Filename without the extension
                    var fileName = Path.GetFileNameWithoutExtension(image.FileName);
                    pPic = Path.Combine("/Assets/GroupImages/", fileName + Path.GetExtension(image.FileName));
                    //Checks if pPic matches any of the current attachments, 
                    //if so it will loop and add a (number) to the end of the filename
                    while (db.Group.AsNoTracking().Any(g => g.Image == pPic))
                    {
                        //Sets "filename" back to the default value
                        fileName = Path.GetFileNameWithoutExtension(image.FileName);
                        //Add's parentheses after the name with a number ex. filename(4)
                        fileName = string.Format(fileName + "(" + ++num + ")");
                        //Makes sure pPic gets updated with the new filename so it could check
                        pPic = Path.Combine("/Assets/GroupImages/", fileName + Path.GetExtension(image.FileName));
                    }
                    image.SaveAs(Path.Combine(Server.MapPath("~/Assets/GroupImages/"), fileName + Path.GetExtension(image.FileName)));
                }
                var defaultProfilePic = "~/Assets/images/Profile_avatar_placeholder_large.png";
                if (String.IsNullOrWhiteSpace(pPic))
                {
                    pPic = defaultProfilePic;
                }
                groups.Image = pPic;

                db.Entry(groups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groups);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = db.Group.Find(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Groups groups = db.Group.Find(id);
            db.Group.Remove(groups);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ////////////////////////////////////////////////////////////////////

        // POST: Groups/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment([Bind(Include = "Id,Body,Created,GroupId,AuthorId")] Groupcomments groupComments)
        {
            if (ModelState.IsValid)
            {
                groupComments.Created = DateTime.UtcNow;
                groupComments.AuthorId = User.Identity.GetUserId();


                db.GroupComment.Add(groupComments);
                db.SaveChanges();
                return RedirectToAction("Details", "Groups", new { id = groupComments.GroupId });
            }

            return RedirectToAction("Details", "Groups", new { id = groupComments.GroupId });
        }

        // POST: Groups/Join
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult JoinGroup([Bind(Include = "Id,MemberCount,Name,Description,Active,OwnerId,Created")] Groups groups)
        {
            var user = db.Users.Find(User.Identity.GetUserId());

            user.Groups.Add(groups);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = groups.Id });
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
