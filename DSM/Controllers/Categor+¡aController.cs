using DSMF.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsEvents1.Controllers
{
    public class CategoríaController : BasicController
    {
        //
        // GET: /Categoría/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Categoría/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Categoría/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Categoría/Create

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

        //
        // GET: /Categoría/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Categoría/Edit/5

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

        //
        // GET: /Categoría/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Categoría/Delete/5

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
