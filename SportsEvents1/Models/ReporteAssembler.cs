using SportsEventsGenNHibernate.EN.SportsEvents;
using SportsEventsGenNHibernate.Enumerated.SportsEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsEvents_FrontEnd.Models
{
    public class ReporteAssembler
    {
        public ReporteModelo ConvertENToModelUI(ReporteEN en)
        {
            ReporteModelo cat = new ReporteModelo();
            cat.idusu = en.Usuario.Nick;
            cat.texto = en.Texto;
            cat.motivo = en.Motivo;
            cat.tipo = en.Tipo;
       


            return cat;
        }



        public IList<ReporteModelo> ConvertListENToModel(IList<ReporteEN> repens)
        {
            IList<ReporteModelo> repmod = new List<ReporteModelo>();
            foreach (ReporteEN repen in repens)
            {
                repmod.Add(ConvertENToModelUI(repen));
            }

            return repmod;
        }
    }
}