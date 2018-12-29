using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSM2.Models;
using DSMGenNHibernate.CAD.DSM;
using DSMGenNHibernate.CEN.DSM;
using DSMGenNHibernate.EN.DSM;

namespace DSM2.Controllers
{
    public class GrupoController : Controller
    {
        // GET: Grupo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Grupo/Details/5
        public ActionResult Details(int id)
        {
            GrupoCEN grupo = new GrupoCEN();

            //// TO LIST NUESTRO
            IList<GrupoEN> listEvent = grupo.ReadAll(0, -1).ToList();
            return View();
        }

        // GET: Grupo/Create
        public ActionResult Create()
        { 
            return View();
        }

        // POST: Grupo/Create
        [HttpPost]
        public ActionResult Create(Grupo grupo)
        {
            try
            {
                // TODO: Add insert logic here
                GrupoCEN grp = new GrupoCEN();
                grp.CrearGrupo(grupo.Nombre,grupo.ListaUsu,grupo.ListaUsu.Count);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Grupo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Grupo/Edit/5
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

        // GET: Grupo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Grupo/Delete/5
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
