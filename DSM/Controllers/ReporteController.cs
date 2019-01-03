using SportsEvents_FrontEnd.Models;
using SportsEventsGenNHibernate.CAD.SportsEvents;
using SportsEventsGenNHibernate.CEN.SportsEvents;
using SportsEventsGenNHibernate.CP.SportsEvents;
using SportsEventsGenNHibernate.EN.SportsEvents;
using SportsEventsGenNHibernate.Enumerated.SportsEvents;
using MvcApplication1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsEvents_FrontEnd.Controllers
{
    public class ReporteController : BasicController
    {
        //
        // GET: /Reporte/

        public ActionResult Index()
        {
            ReporteCEN repCEN = new ReporteCEN();
            IEnumerable<ReporteEN> list = repCEN.ReadAll(0, -1).ToList();
            return View(list);
        }

        //
        // GET: /Reporte/Details/5

        public ActionResult Details(int id)
        {
            ReporteModelo rem = null;
            SessionInitialize();
            ReporteEN repEN = new ReporteCAD(session).ReadOIDDefault(id);
            rem = new ReporteAssembler().ConvertENToModelUI(repEN);
            SessionClose();
            return View(rem);
        }

        //
        // GET: /Reporte/Create

        public ActionResult Create()
        {
            ReporteModelo rep = new ReporteModelo();
            String idr = RouteData.Values["id"].ToString();
            String tip = RouteData.Values["var"].ToString();
            int idref = Int32.Parse(idr);
            int tipo = Int32.Parse(tip);
            rep.id = idref;
            if (tipo == 1)
                rep.tipo = TipoReporteEnum.foto;
            else if (tipo == 2)
                rep.tipo = TipoReporteEnum.comentario;
            else if (tipo == 3)
                rep.tipo = TipoReporteEnum.evento;
           
            return View(rep);
        }

        //
        // POST: /Reporte/Create

        [HttpPost]
        public ActionResult Create(ReporteModelo repMod)
        {
            
                ReporteCP repCP = new ReporteCP();
                ComentarioCEN cen = new ComentarioCEN();
                EventoCEN cen2 = new EventoCEN();
                
                var userName = System.Web.HttpContext.Current.User.Identity.Name;
                repCP.NuevoReporte(repMod.texto, repMod.motivo, userName, repMod.id, repMod.tipo);
                if (repMod.tipo == TipoReporteEnum.foto)
                {
                    return RedirectToAction("Details", "Foto", new { id = repMod.id });
                }
                if (repMod.tipo == TipoReporteEnum.evento)
                {
                    return RedirectToAction("Details", "Evento", new { id = repMod.id });
                }
                if (repMod.tipo == TipoReporteEnum.comentario)
                {
                    ComentarioEN en = cen.ReadOID(repMod.id);
                    if (cen2.ReadOID(en.Evento.Id) != null)
                    {
                        return RedirectToAction("Details", "Evento", new { id = en.Evento.Id });
                    }
                    else
                    {
                        return RedirectToAction("Details", "Foto", new { id = en.Foto.Id});
                    }
                }
                return RedirectToAction("Index");
            
        }

        //
        // GET: /Reporte/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Reporte/Edit/5

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
        // GET: /Reporte/Delete/5

        public ActionResult Delete(int id)
        {
            ReporteCEN cen = new ReporteCEN();
            return View(cen);
        }

        //
        // POST: /Reporte/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ReporteCEN cen = new ReporteCEN();
                cen.EliminarReporte(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
