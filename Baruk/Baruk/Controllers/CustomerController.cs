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
        //public ActionResult ViewInvoice()
        //{
        //    var invoiceList = new List<Pago>();
        //    using (CROSSFITBARUKEntities db = new CROSSFITBARUKEntities())
        //    {
        //        invoiceList = db.Pagoes.ToList();
        //    }
        //    return View(invoiceList);
        //}



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

        public ActionResult ViewInvoice()
        {
            CROSSFITBARUKEntities db = new CROSSFITBARUKEntities();
            List<Pago> paymentList = db.Pagoes.ToList();
            MPago modeloPago = new MPago();

            var list = (from p in db.Pagoes
                        join c in db.Clientes
                            on p.PagoID equals c.PagoID
                        join tp in db.TipoPagoes
                            on p.TipoPagoID equals tp.TipoPagoID
                        join s in db.TipoSuscripcions
                            on p.TipoSuscripcion equals s.TipoSuscripcionID
                        join d in db.Descuentoes
                            on p.DescuentoID equals d.DescuentoID into ljd
                        from d in ljd.DefaultIfEmpty()
                        join tm in db.TipoMensualidads
                            on p.TipoMensualidadID equals tm.TipoMensualidadID
                        join m in db.Morosidads
                            on p.MorosidadID equals m.MorosidadID into ljm
                        from m in ljm.DefaultIfEmpty()
                        join tc in db.TipoClientes
                            on p.TipoClinteID equals tc.TipoClienteID
                        join per in db.Personas
                            on c.PersonaID equals per.PersonaID
                        select new MPago
                        {
                            Cedula = per.Cedula,
                            Nombre = per.Nombre,
                            PagoID = p.PagoID,
                            DescTipoSuscripcion = s.DescDetalle,
                            FechaPago = p.FechaPago,
                            DescTipoPago = tp.DescTipoPago,
                            DescTipoDescuento = d.DesDescuento,
                            DescTipoMensualidad = tm.DescMensualidad,
                            DescMorosidad = m.DescMorosidad,
                            DescTipoCliente = tc.DescTipoCliente
                        }).ToList();
            return View(list);
        }
    }
}
    
