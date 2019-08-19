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
            using (CROSSFITBARUKEntities db = new CROSSFITBARUKEntities())
            {

                List<Genero> Gen = db.Generoes.ToList();
                ViewBag.Genero = new SelectList(Gen, "GeneroID", "DescGenero");
                return View();
            }

        }

        [HttpPost]
        public ActionResult NewCustomer(Persona person, Cliente clientes)
        {
            using (CROSSFITBARUKEntities db = new CROSSFITBARUKEntities())
            {
                List<Genero> Gen = db.Generoes.ToList();
                ViewBag.Genero = new SelectList(Gen, "GeneroID", "DescGenero");

                Persona persona = new Persona();
                var personaID = persona.PersonaID;
                persona.Cedula = person.Cedula;
                persona.Nombre = person.Nombre;
                persona.PrimerApellido = person.PrimerApellido;
                persona.SegundoApellido = person.SegundoApellido;
                persona.GeneroID = person.GeneroID;
                persona.FechaInicio = person.FechaInicio;
                persona.Email = person.Email;

                db.Personas.Add(persona);


                Cliente customer = new Cliente();
                customer.PersonaID = personaID;
                customer.UsuarioCliente = clientes.UsuarioCliente;
                customer.PasswrdCliente = clientes.PasswrdCliente;
                db.Clientes.Add(customer);

                db.SaveChanges();
                return View(person);
            }
        }

        // GET: Customer
        public ActionResult MyProfile()
        {

            CROSSFITBARUKEntities db = new CROSSFITBARUKEntities();
            List<Cliente> clientList = db.Clientes.ToList();
            MCliente clientModel = new MCliente();

            var list = (from p in db.Personas
                        join c in db.Clientes
                            on p.PersonaID equals c.PersonaID
                        join tc in db.TipoClientes
                            on c.TipoClienteID equals tc.TipoClienteID
                        select new MCliente
                        {
                            Nombre = p.Nombre + " " + p.PrimerApellido,
                            Cedula = p.Cedula,
                            DescTipoClienteID = tc.DescTipoCliente,
                            UsuarioCliente = c.UsuarioCliente,
                            FechaInicio = p.FechaInicio,
                            Email = p.Email
                        }).ToList();
            return View(list);
            
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

        [HttpPost]
        public ActionResult Membership(int cedula, string Box)
        {
            using (CROSSFITBARUKEntities db = new CROSSFITBARUKEntities())
            {
                List<Persona> personas = db.Personas.ToList();
                List<Cliente> cliente = db.Clientes.ToList();
                foreach (var x in personas)
                {
                    if (x.Cedula == cedula)
                    {
                        if (Box == "Regular")
                        {
                            var tipoCliente = db.Clientes.Where(j => j.PersonaID == x.PersonaID).FirstOrDefault();
                            tipoCliente.TipoClienteID = 1;
                        }
                        else
                        {
                            var tipoCliente = db.Clientes.Where(j => j.PersonaID == x.PersonaID).FirstOrDefault();
                            tipoCliente.TipoClienteID = 2;
                        }
                    }
                }
                db.SaveChanges();
                return View();
            }
        }

        // GET: Customer
        public ActionResult NewRoutine()
        {
            using (CROSSFITBARUKEntities db = new CROSSFITBARUKEntities())
            {
                List<TipoRutinaAvanzada> RutinaAvanzada = db.TipoRutinaAvanzadas.ToList();
                ViewBag.TipoRutinaID = new SelectList(RutinaAvanzada, "TipoRutinaID", "DescRutina");
                return View();
            }
        }

        [HttpPost]
        public ActionResult NewRoutine(RutinasClientesAvanzado rutina, Persona person, string Instructor)
        {
            using (CROSSFITBARUKEntities db = new CROSSFITBARUKEntities())
            {
                List<TipoRutinaAvanzada> RutinaAvanzada = db.TipoRutinaAvanzadas.ToList();
                ViewBag.TipoRutinaID = new SelectList(RutinaAvanzada, "TipoRutinaID", "DescRutina");
                RutinasClientesAvanzado laRutina = new RutinasClientesAvanzado();
                var rutinaID = laRutina.RutinaClienteID; 
                laRutina.TipoRutinaID = rutina.TipoRutinaID;
                //var DescripcionRutina = "El Instructor asignado es: " + Instructor + "\n El Wod Aignado es: \n" + rutina.DescRutina;
                laRutina.DescRutina = rutina.DescRutina;
                db.RutinasClientesAvanzados.Add(laRutina);

                List<Persona> personas = db.Personas.ToList();
                List<Cliente> cliente = db.Clientes.ToList();
                foreach (var x in personas)
                {
                    if (x.Cedula == person.Cedula)
                    {
                        var cambiorutina = db.Clientes.Where(j => j.PersonaID == x.PersonaID).FirstOrDefault();
                        cambiorutina.RutinaClienteID = rutinaID;

                    }
                }
                db.SaveChanges();
                return View(rutina);
            }
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
        public ActionResult NewInvoice(Pago pago, Persona persona)
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
                var pagoID = elPago.PagoID;
                elPago.TipoSuscripcion = pago.TipoSuscripcion;
                elPago.FechaPago = pago.FechaPago;
                elPago.DescuentoID = pago.DescuentoID;
                elPago.TipoMensualidadID = pago.TipoMensualidadID;
                elPago.TipoClinteID = pago.TipoClinteID;
                elPago.TipoPagoID = pago.TipoPagoID;
                elPago.MorosidadID = pago.MorosidadID;

                db.Pagoes.Add(elPago);


                List<Persona> personas = db.Personas.ToList();
                List<Cliente> cliente = db.Clientes.ToList();
                foreach (var x in personas)
                {
                    if (x.Cedula == persona.Cedula)
                    {
                        var cambioPago = db.Clientes.Where(j => j.PersonaID == x.PersonaID).FirstOrDefault();
                        cambioPago.PagoID = pagoID;

                    }
                }
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

        //[HttpPost]
        //public ActionResult SearchInvoice(string cedula)
        //{
        //    Session["Search"] = cedula;
        //    return new EmptyResult();
        //}
        
    }
}
    
