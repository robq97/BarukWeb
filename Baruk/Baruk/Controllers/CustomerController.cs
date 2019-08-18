﻿using Baruk.Models;
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
            using (CROSSFITBARUKEntities db = new CROSSFITBARUKEntities())
            {
                List<TipoSuscripcion> suscripciones = db.TipoSuscripcions.ToList();
                ViewBag.TipoSuscripcion = new SelectList(suscripciones, "TipoSuscripcionID", "DescDetalle");
                List<Descuento> descuentos = db.Descuentoes.ToList();
                ViewBag.Descuentos = new SelectList(descuentos, "DescuentoID", "DesDescuento");
                List<TipoPago> pagos = db.TipoPagoes.ToList();
                ViewBag.TipoPago = new SelectList(pagos, "TipoPagoID", "DescTipoPago");
                List<TipoMensualidad> mensualidad = db.TipoMensualidads.ToList();
                ViewBag.TipoMensualidad = new SelectList(mensualidad, "TipoMensualidadID", "DescMensualidad");
                List<TipoCliente> Tcliente = db.TipoClientes.ToList();
                ViewBag.Tclientes = new SelectList(Tcliente, "TipoClienteID", "DescTipoCliente");
                List<Morosidad> morosidad = db.Morosidads.ToList();
                ViewBag.Morosidad = new SelectList(morosidad, "MorosidadID", "DescMorosidad");
                return View();
            }

        }

        [HttpPost]
        public ActionResult NewInvoice(Pago pago)
        {
            using (CROSSFITBARUKEntities db = new CROSSFITBARUKEntities())
            {
                List<TipoSuscripcion> suscripciones = db.TipoSuscripcions.ToList();
                ViewBag.TipoSuscripcion = new SelectList(suscripciones, "TipoSuscripcionID", "DescDetalle");
                List<Descuento> descuentos = db.Descuentoes.ToList();
                ViewBag.Descuentos = new SelectList(descuentos, "DescuentoID", "DesDescuento");
                List<TipoPago> pagos = db.TipoPagoes.ToList();
                ViewBag.TipoPago = new SelectList(pagos, "TipoPagoID", "DescTipoPago");
                List<TipoMensualidad> mensualidad = db.TipoMensualidads.ToList();
                ViewBag.TipoMensualidad = new SelectList(mensualidad, "TipoMensualidadID", "DescMensualidad");
                List<TipoCliente> Tcliente = db.TipoClientes.ToList();
                ViewBag.Tclientes = new SelectList(Tcliente, "TipoClienteID", "DescTipoCliente");
                List<Morosidad> morosidad = db.Morosidads.ToList();
                ViewBag.Morosidad = new SelectList(morosidad, "MorosidadID", "DescMorosidad");

                Pago elPago = new Pago();
                elPago.TipoSuscripcion = pago.TipoSuscripcion;
                elPago.FechaPago = pago.FechaPago;
                elPago.DescuentoID = pago.DescuentoID;
                elPago.TipoMensualidadID = pago.TipoMensualidadID;
                elPago.TipoClinteID = pago.TipoClinteID;
                elPago.TipoPagoID = pago.TipoPagoID;
                elPago.MorosidadID = pago.MorosidadID;

                db.Pagoes.Add(elPago);
                db.SaveChanges();

                return View(pago);

            }

        }
    }
}
    
