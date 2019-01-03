using DSMGenNHibernate.EN.DSM;
using DSMF.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsEvents_FrontEnd.Models
{
    public class FotoModelo
    {

        //
        // GET: /FotoModelo/

        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public int idgaleria { get; set; }

        [ScaffoldColumn(false)]
        public String nombre { get; set; }

        [ScaffoldColumn(false)]
        public String email { get; set; }

        [ScaffoldColumn(false)]
        public String descripcion { get; set; }

        [ScaffoldColumn(false)]
        public String ruta { get; set; }

        [ScaffoldColumn(false)]
        public int likes { get; set; }

    }
}
