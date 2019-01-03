using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SportsEventsGenNHibernate.EN.SportsEvents;
using SportsEvents_FrontEnd.Models;

namespace SportsEvents_FrontEnd.Models
{
    public class GaleriaAssembler
    {
        //
        // GET: /GaleriaAssembler/

        public GaleriaModelo ConvertENToModelUI(GaleriaEN en)
        {
            GaleriaModelo gal = new GaleriaModelo();

            gal.id = en.Id;
            gal.NombreGaleria = en.NombreGaleria;
            gal.Evento = en.Evento.Id;

            return gal;
        }



        public IList<GaleriaModelo> ConvertListENToModel(IList<GaleriaEN> catens)
        {
            IList<GaleriaModelo> catmod = new List<GaleriaModelo>();
            foreach (GaleriaEN caten in catens)
            {
                catmod.Add(ConvertENToModelUI(caten));
            }

            return catmod;
        }
    }
}