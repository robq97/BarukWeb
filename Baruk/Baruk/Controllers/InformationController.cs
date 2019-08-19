using Baruk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Baruk.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        [HttpGet]
        public ActionResult InformationForm()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> InformationForm(FormCollection C)
        {
            string Name = C["name"];
            string Email = C["email"];
            string Message = C["message"];
            if (ModelState.IsValid)
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(Email));  // replace with valid value 
                message.From = new MailAddress("barukcrossfit@gmail.com");  // replace with valid value
                message.Subject = "Infomación de Baruk";
                message.Body = string.Format("Gracias por contactarnos " + Name + ", nos aseguremos de contactarlo por medio de este medio" +
                        " o bien al número ingresado (+506 8326 0333) para brindarle más información del servicio en questión. \n \n" +
                        "Atentamente, Felipe Chacon - Socio.");
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "barukcrossfit@gmail.com",  // replace with valid value
                        Password = "ulacit2019"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";//address webmail
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);

                    return View();
                }
            }
            return View();
        }



        // GET: Information
        public ActionResult Gallery()
        {
            return View();
        }

        // GET: Information
        public ActionResult WhoAreWe()
        {
            return View();
        }

        // GET: Information
        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult _Denied()
        {
            return View();
        }
    }
}