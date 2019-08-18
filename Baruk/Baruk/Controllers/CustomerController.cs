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
        public ActionResult NewInvoice(/*Pago pago*/)
        {
            //List<TipoSuscripcion> listSuscripcion = null;
            //using (CROSSFITBARUKEntities db = new CROSSFITBARUKEntities())
            //{
            //    listSuscripcion = (from x in db.TipoSuscripcions 
            //                       select new TipoSuscripcion
            //                       {
            //                           TipoSuscripcionID = x.TipoSuscripcionID,
            //                           DescDetalle = x.DescDetalle
            //                       }).ToList();
            //    List<SelectListItem> suscripciones = listSuscripcion.ConvertAll(x =>
            //    {
            //        return new SelectListItem()
            //        {
            //            Text = x.DescDetalle.ToString(),
            //            Value = x.TipoSuscripcionID.ToString(),
            //            Disabled = true
            //        };
            //    });
            //db.Pagoes.Add(pago);
            //db.SaveChanges();
            return View();

        }
                //ViewBag.suscripciones = suscripciones;
            }
        }

    //    public List<SelectListItem> ObtenerSubscripciones()
    //    {
    //        return new List<SelectListItem>() {
    //            new SelectListItem()
    //                {
    //                    Text = "",
    //                    Value = "",
    //                    Disabled = true
    //                },
    //                new SelectListItem()
    //                {
    //                    Text = "Mensual",
    //                    Value = "1",
    //                    Selected = false
    //                },
    //                new SelectListItem()
    //                {
    //                    Text = "Trimestral",
    //                    Value = "2",
    //                    Selected = false
    //                },
    //                new SelectListItem()
    //                {
    //                    Text = "Anual",
    //                    Value = "3",
    //                    Selected = false
    //                }

    //            };
    //} 
    
