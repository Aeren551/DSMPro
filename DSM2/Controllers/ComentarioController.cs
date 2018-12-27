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
    public class ComentarioController : BasicController
    {
        // GET: Comentario
        public ActionResult Index()
        {
            ComentarioCEN comentarioCEN = new ComentarioCEN();
            IEnumerable<ComentarioEN> listComent = comentarioCEN.ReadAll(0, -1).ToList();
            return View(listComent);
            
        }

        // GET: Comentario/Details/5
        public ActionResult Details(int id)
        {
            ComentarioModel com = null;
            SessionInitialize();
            ComentarioEN comEN = new ComentarioCAD(session).ReadOIDDefault(id);
            com = new ComentarioAssembler().ConvierteObjInterfaz(comEN);

            SessionClose();

            return View(com);
        }

        // GET: Comentario/Create
        public ActionResult Create()
        {

            ComentarioModel comEN = new ComentarioModel();
            String idd = RouteData.Values["id"].ToString();
            //ES POSIBLE Q HAGA FALTAHACER UN ID AUX
            int refid = Int32.Parse(idd);
            comEN.id = refid;

            return View(comEN);
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
            ComentarioModel comen = null;
            SessionInitialize();
            ComentarioEN comEN = new ComentarioCAD(session).ReadOIDDefault(id);
            comen = new ComentarioAssembler().ConvierteObjInterfaz(comEN);
            SessionClose();

            return View(comen);
        }

        // POST: Comentario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ComentarioModel com)
        {
            ComentarioCEN comCEN = new ComentarioCEN();
            ComentarioEN comEN = comCEN.ReadOID(id);
            comCEN.EditarComentario(id, " ", com.texto, com.likes);

            return RedirectToAction("Details", "Evento", new { id = comEN.Evento.Id });

            //return View();
        }

        // GET: Comentario/Delete/5
        public ActionResult Delete(int id)
        {
            ComentarioCEN comenCEN = new ComentarioCEN();

            return View(comenCEN);
        }

        // POST: Comentario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ComentarioCEN comenCEN = new ComentarioCEN();
                ComentarioEN comenEN = comenCEN.ReadOID(id);
                comenCEN.BorrarComentario(id);

                return RedirectToAction("Details", "Evento", new { id = comenEN.Evento.Id });
            }
            catch
            {
                ComentarioCEN coCEN = new ComentarioCEN();
                coCEN.BorrarComentario(id);
                return RedirectToAction("Index");
            }
        }

        public ActionResult likes(int id)
        {

            ComentarioModel como = null;
            SessionInitialize();
            ComentarioEN comEN = new ComentarioCAD(session).ReadOIDDefault(id);
            como = new ComentarioAssembler().ConvierteObjInterfaz(comEN);
            SessionClose();

            ComentarioCEN comCEN = new ComentarioCEN();
            comEN.Likes++;

            comCEN.EditarComentario(id, como.titulo, como.texto, comEN.Likes);

            return RedirectToAction("Details", "Evento", new { id = comEN.Evento.Id });
            //return View();

        }
    }
}
