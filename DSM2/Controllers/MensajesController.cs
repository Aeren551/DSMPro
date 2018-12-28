using DSMGenNHibernate.CAD.DSM;
using DSMGenNHibernate.CEN.DSM;
using DSMGenNHibernate.EN.DSM;
using DSM2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
//using DotNetOpenAuth.AspNet;
//using Microsoft.Web.WebPages.OAuth;
//using WebMatrix.WebData;
//using DSM2.Filters;

using System.IO;

namespace DSM2.Controllers
{
    public class MensajesController : Controller
    {
        // GET: Mensajes
        public ActionResult Index()
        {
            MensajeCEN mensajeCEN = new MensajeCEN();

            //a -1 para que de todos
            //la interfaz tiene q pasarsele una lsita i enum


            //// TO LIST NUESTRO
            IEnumerable<MensajeEN> listMsg = mensajeCEN.ReadAll(0, -1).ToList();
            return View(listMsg);
        }

        // GET: Mensajes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mensajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mensajes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mensajes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mensajes/Edit/5
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

        // GET: Mensajes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mensajes/Delete/5
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
