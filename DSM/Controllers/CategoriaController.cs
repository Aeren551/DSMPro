using DSMF.Controllers;
using SportsEvents_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSMGenNHibernate.CEN.DSM;
using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.CAD.DSM;
using System.IO;

namespace SportsEvents_FrontEnd.Controllers
{
    public class CategoriaController : BasicController
    {
        //
        // GET: /Categoria/

        public ActionResult Index()
        {
            CategoriaCEN catCEN = new CategoriaCEN();
            IEnumerable<CategoriaEN> list = catCEN.ReadAll(0, -1).ToList();
            return View(list);
        }

        public ActionResult Details(String id)
        {
            CategoriaModelo cat = null;
            SessionInitialize();
            //CategoriaCAD catCAD = new CategoriaCAD(session);
            CategoriaEN catEN = new CategoriaCAD(session).ReadOIDDefault(id);
            cat = new CategoriaAssembler().ConvertENToModelUI(catEN);
            SessionClose();
            return View(cat);

        }

        public ActionResult Create()
        {
            
            CategoriaModelo cat = new CategoriaModelo();
        
            return View(cat);

        }

        [HttpPost]
        public ActionResult Create(CategoriaModelo catMOD, HttpPostedFileBase file)
        {

            String fileName = "", pathh = "";

            if (file != null && file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                pathh = Path.Combine(Server.MapPath("~/Images/Uploads"), fileName);
                file.SaveAs(pathh);
            }


            try
            {
                // TODO: Add insert logic here
                fileName = "/Images/Uploads" + fileName;
                CategoriaCEN cen = new CategoriaCEN();
                cen.CrearCategoria(catMOD.nombre);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(String id)
        {

            CategoriaModelo cat = null;
            SessionInitialize();
            CategoriaEN catEN = new CategoriaCAD(session).ReadOIDDefault(id);
            cat = new CategoriaAssembler().ConvertENToModelUI(catEN);
            SessionClose();
            return View(cat);
        }

        //
        // POST: /Galeria/Edit/5

        [HttpPost]
        public ActionResult Edit(String id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CategoriaCEN catCEN = new CategoriaCEN();
                // catCEN.Modify(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Delete(String id, FormCollection collection)
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




    }
}