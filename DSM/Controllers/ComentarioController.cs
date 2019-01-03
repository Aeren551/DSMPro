using SportsEvents_FrontEnd.Models;
using DSMGenNHibernate.CEN.DSM;
using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.CAD.DSM;
using DSMGenNHibernate.CP.DSM;
using DSMGenNHibernate.Enumerated.DSM;
using DSMF.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SportsEvents_FrontEnd.Controllers
{
    public class ComentarioController : BasicController
    {
        //
        // GET: /Comentario/

        public ActionResult Index()
        {
            ComentarioCEN cen = new ComentarioCEN();
            IEnumerable<ComentarioEN> list = cen.ReadAll(0, -1).ToList();
            return View(list);
        }

        //
        // GET: /Comentario/Details/5

        public ActionResult Details(int id)
        {
            ComentarioModelo rem = null;
            SessionInitialize();
            ComentarioEN comEN = new ComentarioCAD(session).ReadOIDDefault(id);
            rem = new ComentarioAssembler().ConvertENToModelUI(comEN);
            SessionClose();
            return View(rem);
        }

        //
        // GET: /Comentario/Create

        public ActionResult Create()
        {
            ComentarioModelo com = new ComentarioModelo();
            String idr = RouteData.Values["id"].ToString();
            String tip = RouteData.Values["var"].ToString();
            int tipo = Int32.Parse(tip);
            int idref = Int32.Parse(idr);
            com.idre = idref;
            if (tipo == 1)
                com.tipo = TipoComentarioEnum.Evento;
            else if (tipo == 2)
                com.tipo = TipoComentarioEnum.Foto;

            return View(com);
        }

        //
        // POST: /Comentario/Create

        [HttpPost]
        public ActionResult Create(ComentarioModelo com)
        {
           
                ComentarioCP cp = new ComentarioCP();
                var userName = System.Web.HttpContext.Current.User.Identity.Name;
                cp.PublicarComentario(com.titulo, com.texto, com.idre, com.tipo, userName);
                if (com.tipo == TipoComentarioEnum.Foto)
                {
                    return RedirectToAction("Details", "Foto", new { id = com.idre});
                }
                else if (com.tipo == TipoComentarioEnum.Evento)
                {
                    return RedirectToAction("Details", "Evento", new { id = com.idre});
                }
                return View();
            
           
            
        }

        //
        // GET: /Comentario/Edit/5

        public ActionResult Edit(int id)
        {
            ComentarioModelo com = null;
            SessionInitialize();
            ComentarioEN en = new ComentarioCAD(session).ReadOIDDefault(id);
            com = new ComentarioAssembler().ConvertENToModelUI(en);
            SessionClose();
            return View(com);
        }

        //
        // POST: /Comentario/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, ComentarioModelo mod)
        {
            String tip = RouteData.Values["var"].ToString();
            int tipo = Int32.Parse(tip);
                ComentarioCEN cen = new ComentarioCEN();
                ComentarioEN en = cen.ReadOID(id);
                if (tipo == 2)
                    en.Tipocom = TipoComentarioEnum.Evento;
                else
                    en.Tipocom = TipoComentarioEnum.Foto;
                cen.EditarComentario(id, "", mod.texto, en.Likes, en.Tipocom);
                if (en.Tipocom == TipoComentarioEnum.Foto)
                {
                    return RedirectToAction("Details", "Foto", new { id = en.Foto.Id});
                }
                else if (en.Tipocom == TipoComentarioEnum.Evento)
                {
                    return RedirectToAction("Details", "Evento", new { id = en.Evento.Id });
                }
                return View();

            
        
        
        }

        //MÉTODO DAR LIKE
        public ActionResult Darlike(int id)
        {
            String tip = RouteData.Values["var"].ToString();
            int tipo = Int32.Parse(tip);
            ComentarioModelo com = null;
            SessionInitialize();
            ComentarioEN en = new ComentarioCAD(session).ReadOIDDefault(id);
            com = new ComentarioAssembler().ConvertENToModelUI(en);
            SessionClose();
            ComentarioCEN cen = new ComentarioCEN();
            en.Likes++;
            if (tipo == 2)
                en.Tipocom = TipoComentarioEnum.Evento;
            else
                en.Tipocom = TipoComentarioEnum.Foto;
            cen.EditarComentario(id, com.titulo, com.texto, en.Likes, en.Tipocom);

            if (en.Tipocom == TipoComentarioEnum.Foto)
            {
                return RedirectToAction("Details", "Foto", new { id = en.Foto.Id });
            }
            if (en.Tipocom == TipoComentarioEnum.Evento)
            {
                return RedirectToAction("Details", "Evento", new { id = en.Evento.Id });
            }
            return View();
        }

      
        //
        // GET: /Comentario/Delete/5

        public ActionResult Delete(int id)
        {
            ComentarioCEN cen = new ComentarioCEN();
            return View(cen);
        }

        //
        // POST: /Comentario/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                String tip = RouteData.Values["var"].ToString();
                int tipo = Int32.Parse(tip);
                ComentarioCEN cen = new ComentarioCEN();
                ComentarioEN en=cen.ReadOID(id);
                int refe = 0;
                try{
                    refe=en.Evento.Id;
                }
                catch{
                    refe=en.Foto.Id;
                }
                cen.BorrarComentario(id);
                if (tipo == 2)
                    return RedirectToAction("Details", "Evento", new { id = refe });
                else
                    return RedirectToAction("Details", "Foto", new { id = refe });
              

            }
            catch
            {
                ComentarioCEN cen = new ComentarioCEN();
                cen.BorrarComentario(id);
                return RedirectToAction("Index");
            }
        }
    }
}
