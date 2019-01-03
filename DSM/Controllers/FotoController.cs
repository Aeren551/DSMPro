using SportsEvents_FrontEnd.Models;
using DSMGenNHibernate.CEN.DSM;
using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.CAD.DSM;
using DSMGenNHibernate.CP.DSM;
using DSMF.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsEvents_FrontEnd.Controllers
{
    public class FotoController : BasicController
    {
        //
        // GET: /Foto/

        public ActionResult Index()
        {

            FotoCEN cen = new FotoCEN();
            IEnumerable<FotoEN> list = cen.ReadAll(0, -1).ToList();
            return View(list);
        }

        //
        // GET: /Foto/Details/5

        public ActionResult Details(int id)
        {
            IList<ComentarioEN> lista = new List<ComentarioEN>();
            IList<ComentarioEN> listaevento = new List<ComentarioEN>();
            FotoModelo fom = null;
            SessionInitialize();
            FotoEN repEN = new FotoCAD(session).ReadOIDDefault(id);
            fom = new FotoAssembler().ConvertENToModelUI(repEN);
            ComentarioCEN comentarios = new ComentarioCEN();
            lista = comentarios.ReadAll(0, -1);
            foreach (ComentarioEN item in lista)
            {
                if (item.Foto != null)
                {
                    if (item.Foto.Id == id)
                    {
                        listaevento.Add(item);
                    }
                }
            }
            ViewData["lista"] = listaevento;
            ViewBag.gal = repEN.Pertenece_a.Id;
            ViewBag.Us = repEN.Pertenece_a.Evento.Crea.Nick;
            SessionClose();
            return View(fom);
        }

        //
        // GET: /Foto/Create

        public ActionResult Create()
        {
            FotoModelo fot = new FotoModelo();
            String idr = RouteData.Values["id"].ToString();
            int idref = Int32.Parse(idr);

            fot.idgaleria = idref;
            return View(fot);
        }

        //
        // POST: /Articulo/Create

        [HttpPost]
        public ActionResult Create(FotoModelo fot, HttpPostedFileBase file)
        {
            int gal = fot.idgaleria;
            string fileName ="", path = "";
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                path = Path.Combine(Server.MapPath("~/Images/Uploads"), fileName);
                //string pathDef = path.Replace(@"\\", @"\");

                file.SaveAs(path);
            }

           
                fileName = "/Images/Uploads/" + fileName;
                FotoCP cp = new FotoCP();
                cp.SubirFoto(fot.nombre, "", fot.descripcion, gal, 0, fileName);
                return RedirectToAction("../Galeria/Details/"+gal);
            
           
        }

        //
        // GET: /Foto/Edit/5

        public ActionResult Edit(int id)
        {
            FotoModelo com = null;
            SessionInitialize();
            FotoEN en = new FotoCAD(session).ReadOIDDefault(id);
            com = new FotoAssembler().ConvertENToModelUI(en);
            SessionClose();
            return View(com);
        }

        //
        // POST: /Foto/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FotoModelo fot)
        {
            try
            {
                FotoCEN cen = new FotoCEN();
                FotoEN en = cen.ReadOID(id);
                cen.EditarFoto(id, fot.nombre,en.Usuario, fot.descripcion,en.Likes, en.Ruta);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //MÉTODO DAR LIKE
        public ActionResult Darlike(int id)
        {
            FotoModelo com = null;
            SessionInitialize();
            FotoEN en = new FotoCAD(session).ReadOIDDefault(id);
            com = new FotoAssembler().ConvertENToModelUI(en);
            SessionClose();
            FotoCEN cen = new FotoCEN();
            en.Likes++;
            cen.EditarFoto(id, en.Nombre, en.Usuario, en.Descripcion, en.Likes, en.Ruta);
            return RedirectToAction("Details", "Foto", new { id = id });
                
        }
        //
        // GET: /Foto/Delete/5

        public ActionResult Delete(int id)
        {
            FotoCEN cen = new FotoCEN();
            return View(cen);
        }

        //
        // POST: /Foto/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                FotoCEN cen = new FotoCEN();
                cen.BorrarFoto(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
