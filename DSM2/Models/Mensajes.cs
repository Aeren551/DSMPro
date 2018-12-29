using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM2.Models
{
    public class Mensajes
    {
        //LOS MODELS SON COMO LOS EN DE ESA CLASE, SOLO DECLARAS QUE VA A TENER
        //De: https://www.tutorialspoint.com/asp.net_mvc/asp.net_mvc_scaffolding.htm
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Display(Prompt = "Mensaje", Description = "Mensaje", Name = "Mensaje ")]
        [Required(ErrorMessage = "Debe indicar un mensaje")]
        [StringLength(maximumLength: 500, ErrorMessage = "El mensaje no puede tener más de 500 caracteres")]
        public string Mensaje { get; set; }

        [ScaffoldColumn(false)]
        public Boolean Leido { get; set; }

        [Display(Prompt = "Origen", Description = "Origen", Name = "Origen ")]
        public string usu0 { get; set; }

        [Display(Prompt = "Destino", Description = "Destino", Name = "Destino ")]
        public string usu1 { get; set; }
    }
}