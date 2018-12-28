using DSMGenNHibernate.Enumerated.DSM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM2.Models
{
    public class ComentarioModel
    {
        //SCAFFOLDFALSE ES PARA QUE NO SE PUEDA MODIFICAR/CREAR EN LA VISTA Y CONTROLLER AUTOMATICAMENTE
        [ScaffoldColumn(false)]
        public int id { get; set; }

        public String titulo { get; set; }

        public String texto { get; set; }

        [ScaffoldColumn(false)]
        public int likes { get; set; }

    }
}