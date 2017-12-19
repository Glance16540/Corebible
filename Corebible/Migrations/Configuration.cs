namespace Corebible.Migrations
{
    using Corebible.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Corebible.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Corebible.Models.ApplicationDbContext context)
        {
            {
                var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
                if (!context.Roles.Any(r => r.Name == "Admin"))
                {
                    roleManager.Create(new IdentityRole { Name = "Admin" });
                }
                if (!context.Roles.Any(r => r.Name == "Moderator"))
                {
                    roleManager.Create(new IdentityRole { Name = "Moderator" });
                }
                if (!context.Roles.Any(r => r.Name == "User"))
                {
                    roleManager.Create(new IdentityRole { Name = "User" });
                }



                var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
                if (!context.Users.Any(u => u.Email == "glance16540@gmail.com"))
                {
                    userManager.Create(new ApplicationUser
                    {
                        UserName = "glance16540@gmail.com",
                        Email = "glance16540@gmail.com",
                        FirstName = "Garrett",
                        LastName = "Lance",
                    }, "Tuckerandhobbes1");
                }

                var userId = userManager.FindByEmail("glance16540@gmail.com").Id;
                userManager.AddToRole(userId, "Admin");

                if (!context.Users.Any(u => u.Email == "drmsmayhem7@gmail.com"))
                {
                    userManager.Create(new ApplicationUser
                    {
                        UserName = "drmsmayhem7@gmail.com",
                        Email = "drmsmayhem7@gmail.com",
                        FirstName = "Michael",
                        LastName = "Mahan",
                    }, "MichaelMahan");
                }

                var userId1 = userManager.FindByEmail("drmsmayhem7@gmail.com").Id;
                userManager.AddToRole(userId, "Admin");

                //if (!context.fri.Any(p => p.Name == "Completed"))
                //{
                //    var status = new TicketStatus();
                //    status.Name = "Completed";
                //    context.TicketStatuses.Add(status);
                //}
                //if (!context.TicketStatuses.Any(p => p.Name == "In Progress"))
                //{
                //    var status = new TicketStatus();
                //    status.Name = "In Progress";
                //    context.TicketStatuses.Add(status);
                //}
                //if (!context.TicketStatuses.Any(p => p.Name == "Assigned"))
                //{
                //    var status = new TicketStatus();
                //    status.Name = "Assigned";
                //    context.TicketStatuses.Add(status);
                //}
                //if (!context.TicketStatuses.Any(p => p.Name == "Unassigned"))
                //{
                //    var status = new TicketStatus();
                //    status.Name = "Unassigned";
                //    context.TicketStatuses.Add(status);
                //}



            }
        }
    }
}