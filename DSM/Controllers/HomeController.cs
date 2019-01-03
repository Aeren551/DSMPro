using DSMGenNHibernate.CEN.DSM;
using DSMGenNHibernate.EN.DSM;
using DSMF.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSMF.Controllers
{
    public class HomeController : BasicController
    {
        public ActionResult Index()
        {
            IList<EventoEN> lista = new List<EventoEN>();
            IList<EventoEN> listaevento = new List<EventoEN>();
            SessionInitialize();
            EventoCEN cen = new EventoCEN();
            lista = cen.ReadAll(0, -1);
            foreach(EventoEN item in lista)
            {
                if (item != null)
                {
                    listaevento.Add(item);
                }
            }
            ViewData["lista"] = listaevento;


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
