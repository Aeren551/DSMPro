using SportsEvents_FrontEnd.Models;
using MvcApplication1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsEventsGenNHibernate.CEN.SportsEvents;
using SportsEventsGenNHibernate.EN.SportsEvents;
using System.IO;
using SportsEventsGenNHibernate.CAD.SportsEvents;

namespace SportsEvents_FrontEnd.Controllers
{
    public class SoporteController : BasicController
    {
        //
        // GET: /Soporte/

        public ActionResult Index()
        {
            SoporteCEN cen = new SoporteCEN();
            IEnumerable<SoporteEN> list = cen.ReadAll(0, -1).ToList();
            return View(list);
        }

        //
        // GET: /Soporte/Details/5

        public ActionResult Details(int id)
        {
            SessionInitialize();
            SoporteModelo sprt = null;

            SoporteEN sprtEN = new SoporteCAD(session).ReadOIDDefault(id);
            sprt = new AssemblerSoporte().ConvertENToModelUI(sprtEN);


            SessionClose();
            return View(sprt);
        }

        //
        // GET: /Soporte/Create

        public ActionResult Create()
        {
            SoporteModelo sprt = new SoporteModelo();
            return View(sprt);
        }

        //
        // POST: /Soporte/Create

        [HttpPost]
        public ActionResult Create(SoporteModelo sprt)
        {

            var userName2 = System.Web.HttpContext.Current.User.Identity.Name;
                SoporteCEN cen = new SoporteCEN();
                cen.NuevaConsulta(userName2, sprt.titulo, sprt.texto);
                return RedirectToAction("../Home/Index");
            
          
        }

        //
        // GET: /Soporte/Edit/5

        public ActionResult Edit(int id)
        {
            SoporteModelo sprt = null;
            SessionInitialize();
            SoporteEN sprtEN = new SoporteCAD(session).ReadOIDDefault(id);
            sprt = new AssemblerSoporte().ConvertENToModelUI(sprtEN);
            SessionClose();
            return View(sprt);
        }

        //
        // POST: /Soporte/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, SoporteModelo spr, FormCollection collection)
        {
            try
            {
                SoporteCEN sprtCEN = new SoporteCEN();
                sprtCEN.Responder(id, spr.titulo, spr.texto, spr.respuesta);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Soporte/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {

                SessionInitialize();
                SoporteCAD sprtCAD = new SoporteCAD(session);
                SoporteCEN sprtCEN = new SoporteCEN(sprtCAD);
                SoporteEN sprtEN = sprtCEN.ReadOID(id);
                SoporteModelo sprt = new AssemblerSoporte().ConvertENToModelUI(sprtEN);

                SessionClose();
                new SoporteCEN().EliminarConsulta(id);
                return RedirectToAction("Index");
            }
            catch { return View(); }
        }

        //
        // POST: /Soporte/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
