using DSM2.Models;
using DSMGenNHibernate.CAD.DSM;
using DSMGenNHibernate.CEN.DSM;
using DSMGenNHibernate.EN.DSM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using NHibernate;
using DSMGenNHibernate.CP.DSM;

namespace DSM2.Controllers
{
    public class EventoController : BasicController
    {
        // GET: Evento
        public ActionResult Index()
        {
            //que no se olvide mirar el basic controller del petstore porque hace falta lo de inicializar sesion
            // hay que heredar de ahi, se copia y se pega en la carpeta controller el bascicontroller
            EventoCEN evento = new EventoCEN();
            
            //// TO LIST NUESTRO
            IList<EventoEN> listEvent = evento.ReadAll(0, -1).ToList();

           // IEnumerable<EventoEN> list = new AssemblerEvento().ConvertListENToModel(listEvent).ToList();
            return View(listEvent);

        }




        // GET: Evento/Details/5
        public ActionResult Details(int id)
        {
            Evento reg = null;
            SessionInitialize();
            EventoEN podEN = new EventoCAD(session).ReadOIDDefault(id);
            reg = new EventoAssembler().ConvertENToModelUI(podEN);
            SessionClose();
            return View(reg);
        }

        // GET: Evento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evento/Create
        [HttpPost]
        //cambio
        //public ActionResult Create(EventoEN evento)
        public ActionResult Create(Evento evento)

        {
            try
            {
                // TODO: Add insert logic here
                EventoCP cen = new EventoCP();
                EventoGratisCEN gra = new EventoGratisCEN();
                EventoPagoCEN pag = new EventoPagoCEN();

                cen.CrearEvento(evento.Lugar, evento.Fecha, evento.Tipo, evento.Descripcion, evento.Nombre, evento.Genero);


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
            Evento art = null;
            SessionInitialize();
            EventoEN artEN = new EventoCAD(session).ReadOIDDefault(id);

            art = new EventoAssembler().ConvertENToModelUI(artEN);
            SessionClose();
            return View(art);
        }

        // POST: Evento/Edit/5
        [HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        public ActionResult Edit(Evento art)

        {
            try
            {
                // TODO: Add delete logic here
                EventoCEN cen = new EventoCEN();
                cen.ModificarEvento(art.id, art.Lugar, art.Fecha, art.Tipo, art.Descripcion,  art.Nombre, art.Genero);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Evento/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            EventoCAD artCAD = new EventoCAD(session);
            EventoCEN cen = new EventoCEN(artCAD);
            EventoEN artEN = cen.ReadOID(id);
            Evento art = new EventoAssembler().ConvertENToModelUI(artEN);
            //idCategoria = art.IdCategoria;
            SessionClose();

            new EventoCEN().BorrarEvento(id);


            return RedirectToAction("Index", "Home");
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
