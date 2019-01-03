using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SportsEventsGenNHibernate.EN.SportsEvents;

namespace SportsEvents_FrontEnd.Models
{
    public class GaleriaModelo
    {
        [ScaffoldColumn(false)]
        public string NombreGaleria { get; set; }
        [ScaffoldColumn(false)]
        public int Evento { get; set; }
        [ScaffoldColumn(false)]
        public int id { get; set; }

    }
}