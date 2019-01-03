using SportsEventsGenNHibernate.Enumerated.SportsEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsEvents_FrontEnd.Models
{
    public class ComentarioModelo
    {


        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public String texto { get; set; }

        [ScaffoldColumn(false)]
        public String titulo { get; set; }

        [ScaffoldColumn(false)]
        public int idre { get; set; }

        [ScaffoldColumn(false)]
        public TipoComentarioEnum tipo { get; set; }

        [ScaffoldColumn(false)]
        public int likes { get; set; }



    }
}