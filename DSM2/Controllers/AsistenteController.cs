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
    public class AsistenteController : BasicController
    {
        // GET: Asistente
        public ActionResult Index()
        {
            AsistenteCEN asisCEN = new AsistenteCEN();
            IList<AsistenteEN> listAsisEN = asisCEN.ReadAll(0, -1);
            IEnumerable<Asistente> listAsis = new AsistenteAssembler().ConvertListENToModel(listAsisEN).ToList();

            return View(listAsis); //Revisar la vista creada
        }

        // GET: Asistente/Details/5
        public ActionResult Details(string id)
        {
            Asistente asis = null;
            SessionInitialize();
            AsistenteEN asisEN = new AsistenteCAD(session).ReadOIDDefault(id);
            asis = new AsistenteAssembler().ConvertENToModelUI(asisEN);
            SessionClose();

            return View(asis); 
        }

        // GET: Asistente/Create
        public ActionResult Create()//aqui pondriamos string email
        {
            //Asistente asis = new Asistente();
            //asis.correo = email;

            return View();//aqui pondriamos asis
        }

        // POST: Asistente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AsistenteEN asistente)
        {
            try
            {
                // TODO: Add insert logic here
                AsistenteCEN asisCEN = new AsistenteCEN();
                asisCEN.CrearUsuario(asistente.Correo, asistente.Nombre, asistente.Contrasenya, asistente.Foto, asistente.Direccion, asistente.Telefono);
                return RedirectToAction("Index"); //aqui a lo mejor hay q poner return RedirectToAction("Create", new { id = asistente.email });
            }
            catch
            {
                return View();
            }
        }

        // GET: Asistente/Edit/5
        public ActionResult Edit(string id)
        {
            Asistente asis = null;
            SessionInitialize();
            AsistenteEN asisEN = new AsistenteCAD(session).ReadOIDDefault(id);
            asis = new AsistenteAssembler().ConvertENToModelUI(asisEN);
            SessionClose();

            return View(); //aqui a lo mejor tenemos q aynadir una vista (asis)
        }

        // POST: Asistente/Edit/5
        [HttpPost]
        public ActionResult Edit(Asistente asis)
        {
            try
            {
                // TODO: Add update logic here
                AsistenteCEN asisCEN = new AsistenteCEN();
                asisCEN.Modify(asis.correo, asis.nombre, asis.contrasenya, asis.foto, asis.direccion, asis.telefono);
                return RedirectToAction("Modifica", new { id = asis.correo });

            }
            catch
            {
                return View();
            }
        }

        // GET: Asistente/Delete/5
        public ActionResult Delete(string email)
        {
            try
            {
                //TODO: Add delete logic here
                SessionInitialize();
                AsistenteCAD asisCAD = new AsistenteCAD(session);
                AsistenteCEN asisCEN = new AsistenteCEN(asisCAD);
                AsistenteEN asisEN = asisCEN.ReadOID(email);
                Asistente asis = new AsistenteAssembler().ConvertENToModelUI(asisEN);
                SessionClose();
                new AsistenteCEN().Destroy(email);

                return RedirectToAction("Modifica", new { id = asis.correo });
            }
            catch
            {
                return View();
            }  
        }

        // POST: Asistente/Delete/5
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
