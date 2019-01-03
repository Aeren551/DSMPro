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
    public class EventoController : BasicController
    {
        //
        // GET: /Evento/

        public ActionResult Index()
        {
            EventoCEN cen = new EventoCEN();
            IEnumerable<EventoEN> list = cen.ReadAll(0, -1).ToList();
            return View(list);
        }

        //
        // GET: /Evento/Details/5

        public ActionResult Details(int id)
        {
            IList<ComentarioEN> lista = new List<ComentarioEN>();
            IList<ComentarioEN> listaevento = new List<ComentarioEN>();

            IList<GaleriaEN> lista2 = new List<GaleriaEN>();
            IList<GaleriaEN> listagal = new List<GaleriaEN>();
            EventoModelo ev = null;
            SessionInitialize();
            EventoEN evEN = new EventoCAD(session).ReadOIDDefault(id);
            ev = new EventoAssembler().ConvertENToModelUI(evEN);
            ComentarioCEN comentarios = new ComentarioCEN();
            lista = comentarios.ReadAll(0, -1);
            foreach (ComentarioEN item in lista)
            {
                if (item.Evento != null)
                {
                    if (item.Evento.Id == id)
                    {
                        listaevento.Add(item);
                    }
                }
            }
            ViewData["lista"] = listaevento;
            //galeria
            GaleriaCEN galeria = new GaleriaCEN();
            lista2 = galeria.ReadAll(0, -1);
            foreach (GaleriaEN item in lista2)
            {
                if (item.Evento != null)
                {
                    if (item.Evento.Id == id)
                    {
                        listagal.Add(item);
                    }
                }
            }
            ViewData["lista2"] = listagal;
            SessionClose();
            if (RouteData.Values["var"] != null)
            {
                String tip = RouteData.Values["var"].ToString();

                int tipo = Int32.Parse(tip);
                if (tipo == 1)
                    @ViewBag.err = "Error";
            }
            return View(ev);
        }

        // GET: /Evento/BusquedaAvanzada

        public ActionResult BusquedaAvanzada(string id)
        {
            EventoCEN cen = new EventoCEN();
            IList<EventoEN> list = cen.ReadAll(0, 10).ToList();
            IList<EventoEN> listaeventos = new List<EventoEN>();
            IList<String[]> listafiltros = new List<String[]>();
            string nombre = null;
            string localidad = null;
            string categoria = null;
            //DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            string desde = null;
            string hasta = null;
            if (id != null)
            {
                string[] aux = id.Split('ç');


                foreach (string item2 in aux)
                {
                    listafiltros.Add(item2.Split('_'));
                }
                foreach (String[] item in listafiltros)
                {
                    if (item[0].Equals("Caregoria"))
                    {
                        categoria = item[1];
                    }
                    if (item[0].Equals("Nombre"))
                    {
                        nombre = item[1];
                    }
                    if (item[0].Equals("Loc"))
                    {
                        localidad = item[1];
                    }
                    if (item[0].Equals("Desde"))
                    {
                        desde = item[1];
                        // String[] auxx= item[1].Split('/');
                        // desde = new DateTime(Convert.ToInt32(auxx[2]), Convert.ToInt32(auxx[1]), Convert.ToInt32(auxx[0]));
                    }
                    if (item[0].Equals("Hasta"))
                    {
                        hasta = item[1];
                        //String[] auxx2= item[1].Split('/');
                        // hasta = new DateTime(Convert.ToInt32(auxx2[2]), Convert.ToInt32(auxx2[1]), Convert.ToInt32(auxx2[0]));
                    }
                }
            }
            bool entro;
            if (nombre == null && localidad == null && categoria == null && desde == null && hasta == null)
            {
                entro = false;
            }
            else
            {
                entro = true;
            }

            foreach (EventoEN item in list)
            {
                if (nombre != null && !item.Nombre.Contains(nombre))
                {
                    entro = false;
                }
                if (entro == true && categoria != null && !item.Categoria.Nombre.Equals(categoria))
                {
                    entro = false;
                }
                if (entro == true && localidad != null && !item.Localizacion.Equals(localidad))
                {
                    entro = false;
                }
                String day = (item.Fecha.HasValue ? item.Fecha.Value.ToString("yyyy-MM-dd") : "[N/A]"); ;
                ViewBag.ggg = day;
                ViewBag.fff = desde;
                ViewBag.ddd = day.CompareTo(desde);
                if (entro == true && desde != null && day.CompareTo(desde) < 0)
                {
                    entro = false;
                }
                if (entro == true && hasta != null && day.CompareTo(hasta) > 0)
                {
                    entro = false;
                }
                if (entro)
                {
                    listaeventos.Add(item);
                }
            }
            CategoriaCEN cenn = new CategoriaCEN();
            IEnumerable<CategoriaEN> listt = cenn.ReadAll(0, -1).ToList();
            List<string> lista = new List<string>();
            lista.Add("Categorias");
            foreach (CategoriaEN auxa in listt)
            {
                lista.Add(auxa.Nombre);
            }
            ViewBag.Categorias = lista;
            return View(listaeventos);
        }




        //
        // GET: /Evento/Create

        public ActionResult Create()
        {
            EventoModelo art = new EventoModelo();
            CategoriaCEN cen = new CategoriaCEN();

            IEnumerable<CategoriaEN> list = cen.ReadAll(0, -1).ToList();
            List<string> lista = new List<string>();
            foreach (CategoriaEN aux in list)
            {
                lista.Add(aux.Nombre);
            }
            ViewBag.Categorias = lista;
            return View(art);
        }

        //
        // POST: /Evento/Create

        [HttpPost]
        public ActionResult Create(EventoModelo art)
        {
            EventoCEN cen = new EventoCEN();
            var userName = System.Web.HttpContext.Current.User.Identity.Name;
            art.Crea = userName;
            int n = cen.CrearEvento(art.Nombre, art.Crea, art.Categoria, art.Descripcion, art.tipo, art.numPart, art.numPartMax, art.Fecha, art.Localizacion, art.Latitud, art.Longitud);
            return RedirectToAction("Details", new { id = n });
        }

        //
        // GET: /Evento/Edit/5

        public ActionResult Edit(int id)
        {
            EventoModelo art = null;
            SessionInitialize();
            EventoEN artEN = new EventoCAD(session).ReadOIDDefault(id);
            art = new EventoAssembler().ConvertENToModelUI(artEN);
            SessionClose();
            CategoriaCEN cen = new CategoriaCEN();
            IEnumerable<CategoriaEN> list = cen.ReadAll(0, -1).ToList();
            List<string> lista = new List<string>();
            foreach (CategoriaEN aux in list)
            {
                lista.Add(aux.Nombre);
            }
            ViewBag.Categorias = lista;
            return View(art);
        }

        //
        // POST: /Evento/Edit/5

        [HttpPost]
        public ActionResult Edit(EventoModelo art)
        {
            try
            {
                EventoCEN cen = new EventoCEN();
                cen.ModificarEvento(art.id, art.Nombre, art.Descripcion, art.tipo, art.numPart, art.numPartMax, art.Fecha, art.Localizacion, art.Latitud, art.Longitud);
                return RedirectToAction("Details", new { id = art.id });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Evento/Delete/5

        public ActionResult Delete(int id)
        {
            EventoCEN cen = new EventoCEN();

            return View(cen);
        }

        //
        // POST: /Evento/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            EventoCEN cen = new EventoCEN();
            EventoEN en = new EventoEN();
            GaleriaCEN cen2 = new GaleriaCEN();
            en = cen.ReadOID(id);
            if (en.Galeria != null)
            {
                cen2.EliminarGaleria(en.Galeria.Id);
            }
            try
            {
                cen.BorrarEvento(id);
                return RedirectToAction("../Home/Index");
            }
            catch
            {

                return RedirectToAction("Details", new { id = id, var = 1 });
            }

        }
        //
        // GET: /Usuario/

        public ActionResult EventosUsr(string id)
        {
            EventoCEN cen = new EventoCEN();
            IList<EventoEN> list = cen.ReadAll(0, -1).ToList();
            IList<EventoEN> listaeventos = new List<EventoEN>();
            foreach (EventoEN item in list)
            {
                if (item.Crea.Nick.Equals(id))
                {
                    listaeventos.Add(item);
                }
            }
            return View(listaeventos);
        }
        //
        // GET: /Usuario/

        public ActionResult Busqueda(string id)
        {
            EventoCEN cen = new EventoCEN();
            IList<EventoEN> list = cen.ReadAll(0, -1).ToList();
            IList<EventoEN> listaeventos = new List<EventoEN>();
            foreach (EventoEN item in list)
            {

                if (item.Nombre.Contains(id))
                {
                    listaeventos.Add(item);
                }

            }
            return View(listaeventos);
        }

        public ActionResult Inscribirse()
        {
            String idr = RouteData.Values["id"].ToString();
            String tip = RouteData.Values["var"].ToString();
            int idref = Int32.Parse(idr);
            EventoModelo com = null;
            EventoCEN cen = new EventoCEN();
            SessionInitialize();
            EventoEN en = new EventoCAD(session).ReadOIDDefault(idref);
            com = new EventoAssembler().ConvertENToModelUI(en);
            IList<String> usu = new List<String>();
            usu.Add(tip);
            if (en.NumeroParticipantes < en.MaxParticipantes)
            {
                cen.AnyadirParticipante(idref, usu);

                en.NumeroParticipantes++;
                cen.ModificarEvento(en.Id, en.Nombre, en.Descripcion, en.Tipo, en.NumeroParticipantes, en.MaxParticipantes, en.Fecha, en.Localizacion, en.Latitud, en.Longitud);
            }
            else
            {
                SessionClose();
                @ViewBag.err = "Error";
                return View(en);
            }
            SessionClose();

            @ViewBag.ev = idref;
            return View(en);
        }

    }
}


