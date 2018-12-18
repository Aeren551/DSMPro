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

namespace DSM2.Controllers
{
    public class ComentarioController : Controller
    {
        // GET: Comentario
        public ActionResult Index()
        {
            ComentarioCEN comentarioCEN = new ComentarioCEN();
            IEnumerable<DSMGenNHibernate.EN.DSM.ComentarioEN> listComent = comentarioCEN.ReadAll(0, -1).ToList();
            return View(listComent);
            
        }

        // GET: Comentario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comentario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comentario/Create
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

        // GET: Comentario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comentario/Edit/5
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

        // GET: Comentario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comentario/Delete/5
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
