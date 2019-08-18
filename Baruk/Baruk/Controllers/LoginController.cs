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
            if (Session["UserType"] != null)
            {
                return RedirectToAction("MyProfile", "Customer");
            }
            return View();
        }

        public ActionResult AdminLogIn()
        {
            if (Session["UserType"] != null)
            {
                return RedirectToAction("NewCustomer", "Customer");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            if (Session["UserType"] != null)
            {
                Session["UserType"] = null;
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ClientAuthentication(Cliente login)
        {
            if (ModelState.IsValid)
            {
                CROSSFITBARUKEntities db = new CROSSFITBARUKEntities();
                List<Cliente> clientList = db.Clientes.ToList();

                var user = (from userlist in clientList
                            where userlist.UsuarioCliente == login.UsuarioCliente && userlist.PasswrdCliente == login.PasswrdCliente
                            select new
                            {
                                userlist.ClienteID,
                                userlist.UsuarioCliente,
                                userlist.TipoClienteID,
                                userlist.PersonaID,
                                userlist.PagoID
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    
                    Session["UserName"] = user.FirstOrDefault().UsuarioCliente.ToString();
                    Session["UserID"] = user.FirstOrDefault().ClienteID.ToString();
                    Session["UserType"] = user.FirstOrDefault().TipoClienteID.ToString();
                    Session["PersonID"] = user.FirstOrDefault().PersonaID.ToString();
                    Session["ClienteID"] = user.FirstOrDefault().ClienteID.ToString();
                    Session["PaymentID"] = user.FirstOrDefault().PagoID.ToString();
                    return RedirectToAction("MyProfile", "Customer");
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }

            }
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult AdminAuthentication(Admin login)
        {
            if (ModelState.IsValid)
            {
                CROSSFITBARUKEntities db = new CROSSFITBARUKEntities();
                List<Admin> adminList = db.Admins.ToList();

                var user = (from userlist in adminList
                            where userlist.UsuarioEspecial == login.UsuarioEspecial && userlist.PasswrdEspecial == login.PasswrdEspecial
                            select new
                            {
                                userlist.AdminID,
                                userlist.PersonaID,
                                userlist.UsuarioEspecial
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {

                    Session["UserName"] = user.FirstOrDefault().UsuarioEspecial;
                    Session["UserID"] = user.FirstOrDefault().AdminID;
                    Session["UserType"] = "Admin";
                    return RedirectToAction("NewCustomer", "Customer");
                }
                else
                {
                    return RedirectToAction("AdminLogin", "Login");
                }

            }
            return new EmptyResult();
        }
    }
}