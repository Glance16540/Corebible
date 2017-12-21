using Corebible.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

using static Corebible.Controllers.ManageController;
using System.Web.Services.Description;

namespace Corebible.Controllers
{
    [Authorize]
    public class HomeController : Universal
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Chat()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var body = "<p>Email From: <bold>{0}</bold>({1})</p><p>Message: </p><p>{2}</p>";
                    var from = "TheCoreBible<thecorebible@gmail.com>";
                    model.Body = model.Body;
                var email = new MailMessage(from,ConfigurationManager.AppSettings["emailto"])
                {
                 Subject = "Contact From CoreBible",
                 Body = string.Format(body, model.FromName, model.FromEmail,model.Body),
                 IsBodyHtml = true
                };
                    var svc = new PersonalEmail();
                    await svc.SendAsync(email);
                    return RedirectToAction("Contact");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }
            }
            return View(model);
        }
    }
}