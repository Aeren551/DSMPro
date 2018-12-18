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


            //// TO LIST NUESTRO
            IEnumerable<DSMGenNHibernate.EN.DSM.EventoEN> listEvent = eventoCEN.ReadAll(0, -1).ToList();
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
            Evento evento = new Evento();
           
            return View(evento);
           // EventoEN eventoEN = new EventoEN();
            //return View(eventoEN);
        }

        // POST: Evento/Create
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
