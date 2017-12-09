using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Corebible.Models
{
    public class Universal:Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (User.Identity.IsAuthenticated)
            {
                var user = db.Users.Find(User.Identity.GetUserId());

                ViewBag.FirstName = user.FirstName;
                ViewBag.LastName = user.LastName;
                ViewBag.FullName = user.FullName;
                ViewBag.ProfilePic = user.ProfilePic;
                ViewBag.Bio = user.Bio;
                var timezones = TimeZoneInfo.GetSystemTimeZones();
                ViewBag.TimeZone = new SelectList(timezones, "Id", "Id");




                //ViewBag.LastComments = user.Comments.Where(p => p.Id.ToString() == user.Id).Take(5);
                //ViewBag.LastComment = user.Comments.OrderByDescending(p => p.Created.UtcDateTime).Take(5);
                //ViewBag.CartItems = db.Car.AsNoTracking().Where(c => c.CustomerID == user.Id).ToList();
                //ViewBag.CartItemsCount = db.Cartitem.AsNoTracking().Where(c => c.CustomerID == user.Id).ToList().Sum(c => c.Count);
                //var myCart = db.Cartitem.AsNoTracking().Where(c => c.CustomerID == user.Id).ToList();
                //ViewBag.carttotal = myCart.Sum(a => a.UnitTotal);

            }
        }
    }
}
