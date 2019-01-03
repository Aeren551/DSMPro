using DSMGenNHibernate.Enumerated.DSM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsEvents_FrontEnd.Models
{
    public class ReporteModelo
    {


        [ScaffoldColumn(false)]
        public String idusu { get; set; }

        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public String texto { get; set; }

        [ScaffoldColumn(false)]
        public MotivoEnum motivo { get; set; }

        [ScaffoldColumn(false)]
        public TipoReporteEnum tipo { get; set; }
    }
}