using DSMGenNHibernate.CAD.DSM;
using DSMGenNHibernate.CEN.DSM;
using DSMGenNHibernate.EN.DSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSM.Controllers
{
    public class EventoController : BasicController
    {
        // GET: Evento
        public ActionResult Index()
        {
            //que no se olvide mirar el basic controller del petstore porque hace falta lo de inicializar sesion
            // hay que heredar de ahi, se copia y se pega en la carpeta controller el bascicontroller
            EventoCEN eventoCEN = new EventoCEN();
            
            //a -1 para que de todos
            //la interfaz tiene q pasarsele una lsita i enum

            IEnumerable<DSMGenNHibernate.EN.DSM.EventoEN> listEvent= eventoCEN.ReadAll(0, -1);
            return View(listEvent);
        }

        // GET: Evento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Evento/Create
        public ActionResult Create()
        {
            //EventoEN eventoEN = new EventoEN();
            EventoEN eventoEN = new EventoEN();
            return View(eventoEN);
        }

        // POST: Evento/Create
        [HttpPost]
        public ActionResult Create(EventoEN eventoEN)
        {
            //se puede cambiar a lo q trngo pu esto Create(FormCollection collection)
            try
            {
                // TODO: Add insert logic here
                SessionInitialize();
                EventoCAD eventoCAD = new EventoCAD(session);
                //crear evento??? el ha puesto New_
                eventoCAD.CrearEvento(eventoEN);
                SessionClose();
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Evento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Evento/Edit/5
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

        // GET: Evento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Evento/Delete/5
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
