using DSM2.Models;
using DSMGenNHibernate.CAD.DSM;
using DSMGenNHibernate.CEN.DSM;
using DSMGenNHibernate.EN.DSM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using NHibernate;

namespace DSM2.Controllers
{
    public class PremioController : Controller
    {
        // GET: Premio
        public ActionResult Index()
        {
            PremioCEN premio = new PremioCEN();

            //// TO LIST NUESTRO
            IList<PremioEN> listEvent = premio.ReadAll(0, -1).ToList();
            return View();
        }

        // GET: Premio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Premio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Premio/Create
        [HttpPost]
        public ActionResult Create(Premio pre)
        {
            try
            {
                // TODO: Add insert logic here
                PremioCEN gra = new PremioCEN();

                gra.CrearPremio(pre.Descripcion,pre.Evento,pre.Nombre,null,0);//ID de grupo null = 0?

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Premio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Premio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Premio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Premio/Delete/5
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
