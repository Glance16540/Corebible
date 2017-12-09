using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using Corebible.Models.CodeFirst;
using System.Web.Mvc;
using System;

namespace Corebible.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePic { get; set; }
        public string TimeZone { get; set; }
        [AllowHtml]
        public string Bio { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }


        }

        public ApplicationUser()
        {
            Groupcomment = new HashSet<Groupcomments>();
            PlanReviews = new HashSet<PlanReview>();
         
        }

        public virtual ICollection<Groupcomments> Groupcomment { get; set; }
        public virtual ICollection<PlanReview> PlanReviews { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Groups>Group { get; set; }
        public DbSet<Groupcomments> GroupComment { get; set; }
        public DbSet<Plans> Plan { get; set; }
        public DbSet<PlanReview> PlanReviews { get; set; }
        public DbSet<Notification>Notifications { get; set; }

      
    }

}