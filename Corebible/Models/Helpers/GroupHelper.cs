using Corebible.Models.CodeFirst;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corebible.Models.Helpers
{
    public class GroupHelper
    {
        private UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        private ApplicationDbContext db = new ApplicationDbContext();

        
        // CHECK TO SEE IF USER IS IN GROUP
        public bool IsUserInGroup (string userId, int groupId)
        {
            var group = db.Group.Find(groupId);
            var userBool = group.Members.Any(u => u.Id == userId);

            return userBool;
        }

        // ADD USER TO GROUP
        public void AddUserToGroup (string userId, int groupId)
        {
            var user = db.Users.Find(userId);
            var group = db.Group.Find(groupId);
            group.Members.Add(user);

            db.SaveChanges();
        }

        // REMOVE USER FROM GROUP
        public void RemoveUserFromGroup (string userId, int groupId)
        {
            var user = db.Users.Find(userId);
            var group = db.Group.Find(groupId);
            group.Members.Remove(user);

            db.SaveChanges();
        }

        // LIST USERS IN GROUP
        public List<ApplicationUser> UsersInGroup (int groupId)
        {
            var group = db.Group.Find(groupId);
            return group.Members.ToList();
        }

        // LIST USERS NOT IN GROUP
        public List<ApplicationUser> UsersNotOnGroup (int groupId)
        {
            return db.Users.Where(u => u.Groups.All(g => g.Id != groupId)).ToList();
        }

        // LIST USERS GROUPS
        public List<Groups> ListUsersGroups(string userId)
        {
            var user = db.Users.Find(userId);
            return user.Groups.ToList();
        }

    }
}