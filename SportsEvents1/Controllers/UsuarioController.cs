
using SportsEvents_FrontEnd.Models;
using SportsEventsGenNHibernate.CAD.SportsEvents;
using SportsEventsGenNHibernate.CEN.SportsEvents;
using SportsEventsGenNHibernate.EN.SportsEvents;
using MvcApplication1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SportsEvents_FrontEnd.Controllers
{
    public class UsuarioController : BasicController
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            UsuarioCEN cen = new UsuarioCEN();
            IEnumerable<UsuarioEN> list = cen.ReadAll(0, -1).ToList();
            return View(list);
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(string id)
        {

            SessionInitialize();
            UsuarioModelo ev = null;
            UsuarioEN evEN = new UsuarioCAD(session).ReadOIDDefault(id);
            ev = new UsuarioAssembler().ConvertENToModelUI(evEN);
            SessionClose();
            return View(ev);


        }


        public ActionResult Administrar()
        {
            UsuarioCEN cen = new UsuarioCEN();
            return View(cen);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create(String mail)
        {
            UsuarioModelo usr = new UsuarioModelo();
            usr.email = mail;
            return View(usr);
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(UsuarioModelo usr, HttpPostedFileBase file)
        {

            UsuarioCEN usrCEN = new UsuarioCEN();
            usrCEN.CrearUsuario(usr.email, usr.password, false, usr.tipo, usr.nombre, usr.apellidos, usr.telefono, usr.localidad, usr.provincia, usr.direccion);


            return RedirectToAction("Create", new { id = usr.email });
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(string id)
        {

            UsuarioModelo usr = null;
            SessionInitialize();
            UsuarioEN usrEN = new UsuarioCAD(session).ReadOIDDefault(id);
            usr = new UsuarioAssembler().ConvertENToModelUI(usrEN);
            SessionClose();
            return View();
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        public ActionResult Edit(UsuarioModelo usr)
        {
            try
            {
                UsuarioCEN usrCEN = new UsuarioCEN();
                usrCEN.ModificarPerfil(usr.id, usr.password, usr.bloqueado, usr.tipo, usr.nombre, usr.apellidos, usr.telefono, usr.localidad, usr.provincia, usr.email);

                return RedirectToAction("Modifica", new { id = usr.email });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(string id)
        {

            try
            {

                SessionInitialize();
                UsuarioCAD usrCAD = new UsuarioCAD(session);
                UsuarioCEN usrCEN = new UsuarioCEN(usrCAD);
                UsuarioEN usrEN = usrCEN.ReadOID(id);
                UsuarioModelo usr = new UsuarioAssembler().ConvertENToModelUI(usrEN);

                SessionClose();
                new UsuarioCEN().DarDeBaja(id);
                return RedirectToAction("Modifica", new { id = usr.email });
            }
            catch { return View(); }

        }

        //
        // POST: /Usuario/Delete/5

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


