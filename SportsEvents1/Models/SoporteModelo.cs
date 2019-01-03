using SportsEventsGenNHibernate.EN.SportsEvents;
using MvcApplication1.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsEvents_FrontEnd.Models
{
    public class SoporteModelo
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public String titulo { get; set; }

        [ScaffoldColumn(false)]
        public String texto { get; set; }

        [ScaffoldColumn(false)]
        public String respuesta { get; set; }

        [ScaffoldColumn(false)]
        public String nomUsuario { get; set; }

      // [ScaffoldColumn(false)]
       // public AdminEN admin { get; set; }

    }
}
