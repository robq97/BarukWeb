using Baruk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baruk.Controllers
{
    public class CustomerController : Controller
    {

        // ver todas las facturas de un cliente
        public ActionResult ViewInvoice()
        {
            var invoiceList = new List<Pago>();
            using (CROSSFITBARUKEntities db = new CROSSFITBARUKEntities())
            {
                invoiceList = db.Pagoes.ToList();
            }
            return View(invoiceList);
        }



        // GET: Customer
        public ActionResult NewCustomer()
        {
            return View();
        }

        // GET: Customer
        public ActionResult MyProfile()
        {
            var clienteLista = new List<Persona>();
            using (CROSSFITBARUKEntities db = new CROSSFITBARUKEntities())
            {
                clienteLista = db.Personas.ToList();
            }
                return View(clienteLista);
        }

        // GET: Customer
        public ActionResult AvailableRoutines()
        {
            return View();
        }

        // GET: Customer
        public ActionResult Membership()
        {
            return View();
        }

        // GET: Customer
        public ActionResult NewRoutine()
        {
            return View();
        }

        // GET: Customer
        public ActionResult NewInvoice()
        {
            return View();
        }
    }


}