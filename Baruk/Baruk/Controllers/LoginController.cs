using Baruk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baruk.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult LogIn()
        {
            if (Session["username"] != null)
            {
                return RedirectToAction("NewCustomer", "Customer");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            if (Session["username"] != null)
            {
                Session["username"] = null;
            }
            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        //public ActionResult Authentication(MPersona login)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        CROSSFITBARUKEntities db = new CROSSFITBARUKEntities();
        //        List<MPersona> personList = db.Personas.ToList();

        //        var user = (from userlist in personList
        //                    where userlist.NumeroCedula == login.NumeroCedula && userlist.Contrasena == login.Contrasena
        //                    select new
        //                    {
        //                        userlist.PersonaID,
        //                        userlist.NumeroCedula
        //                    }).ToList();
        //        if (user.FirstOrDefault() != null)
        //        {
        //            Session["UserName"] = user.FirstOrDefault().NumeroCedula;
        //            Session["UserID"] = user.FirstOrDefault().PersonaID;
        //            Models.Static.PersonaSeccion = user.FirstOrDefault().PersonaID;
        //            return RedirectToAction("NewCustomer", "Customer");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Denied", "Admin");
        //        }

        //    }
        //    return new EmptyResult();
        //}

        //public ActionResult Authentication(MPersona login)
        //{
        //    using (CROSSFITBARUKEntities db = new CROSSFITBARUKEntities())
        //    {
        //        var userDetails = db.Personas.Where(x => x.Cedula == login.NumeroCedula && x.Clientes.Equals(login.Contrasena)).FirstOrDefault();
        //        if (userDetails == null)
        //        {

        //        }
        //        else
        //        {
        //            Session["userID"] = userDetails.PersonaID;
        //            return RedirectToAction("MyProfile", "Customer");
        //        }

        //        return new EmptyResult();
        //    }
        //}
    }
}