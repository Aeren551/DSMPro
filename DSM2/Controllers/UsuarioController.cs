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

namespace DSM2.Controllers
{
    public class UsuarioController : Controller
    {
        protected ISession session;
        // GET: Usuario
        public ActionResult Index()
        {
            UsuarioCEN cen = new UsuarioCEN();
            IList<UsuarioEN> listArtEn = cen.ReadAll(0, -1);

            IEnumerable<Usuario> list = new AssemblerUsuario().ConvertListENToModel(listArtEn).ToList();
            return View(list);

        }
        // para la sesion ?
        protected void SessionInitialize()
        {
            if (session == null)
            {
                session = NHibernateHelper.OpenSession();
            }
        }
        protected void SessionClose()
        {
            if (session != null && session.IsOpen)
            {
                session.Close();
                session.Dispose();
                session = null;
            }
        }

        // GET: Usuario/Details/5
        //LE HE CAMBIADO INT ID A STRING ID NO SE SI ESTO ES MUY SANO AIUDA
        public ActionResult Details(String id)
        {
            Usuario reg = null;
            SessionInitialize();
            UsuarioEN podEN = new UsuarioCAD(session).ReadOIDDefault(id);
            reg = new AssemblerUsuario().ConvertENToModelUI(podEN);
            SessionClose();
            return View(reg);
            
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //AQUI CAMBIO FormCollection collection por Usuario usuario
        public ActionResult Create(UsuarioEN usuario)
        {
            try
            {
                // TODO: Add insert logic here
                UsuarioCEN cen = new UsuarioCEN();
                cen.CrearUsuario(usuario.Correo,usuario.Nombre, usuario.Contrasenya,usuario.Foto, usuario.Direccion,usuario.Telefono);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        //quito el int y pongo el String
        public ActionResult Edit(String id)
        {
            Usuario enc = null;
            SessionInitialize();
            UsuarioEN encEN = new UsuarioCAD(session).ReadOIDDefault(id);
            enc = new AssemblerUsuario().ConvertENToModelUI(encEN);
            SessionClose();
            return View(enc);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        //quito int id, FormCollection collection y pongo lo q hay
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                // TODO: Add update logic here

                UsuarioCEN cen = new UsuarioCEN();
                cen.Modify(usuario.correo, usuario.nombre, usuario.contrasenya, usuario.foto, usuario.direccion, usuario.telefono);
                return RedirectToAction("Details", new { id = usuario.correo });
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        //borro int id pongo string correo
        public ActionResult Delete(String correo)
        {
            try
            {
                // TODO: Add delete logic here

                SessionInitialize();
                UsuarioCAD artCAD = new UsuarioCAD(session);
                UsuarioCEN cen = new UsuarioCEN(artCAD);
                UsuarioEN encEN = cen.ReadOID(correo);
                Usuario enc = new AssemblerUsuario().ConvertENToModelUI(encEN);

                SessionClose();

                new UsuarioCEN().Destroy(correo);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        //mas de lo mismo int id y form collection por el objeto
        public ActionResult Delete(int id)
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
