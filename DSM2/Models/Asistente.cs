using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DSM2.Models
{

    public class Asistente
    {
        [ScaffoldColumn(false)]
        public String correo { get; set; }

        [ScaffoldColumn(false)]
        public String nombre { get; set; }

        [ScaffoldColumn(false)]
        public String contrasenya { get; set; }

        [ScaffoldColumn(false)]
        public String foto { get; set; }

        [ScaffoldColumn(false)]
        public String direccion { get; set; }

        [ScaffoldColumn(false)]
        public int telefono { get; set; }


    }
}
