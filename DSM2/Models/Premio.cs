using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM2.Models
{
    public class Premio
    {
        //LOS MODELS SON COMO LOS EN DE ESA CLASE, SOLO DECLARAS QUE VA A TENER
        //De: https://www.tutorialspoint.com/asp.net_mvc/asp.net_mvc_scaffolding.htm
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Display(Prompt = "Descripcion", Description = "Descripcion", Name = "Descripcion ")]
        [Required(ErrorMessage = "Debe indicar una Descripcion")]
        [StringLength(maximumLength: 500, ErrorMessage = "La Descripcion no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Evento", Description = "Evento", Name = "Evento ")]
        [Required(ErrorMessage = "Debe indicar un Evento")]
        public int Evento { get; set; }

        [Display(Prompt = "Nombre", Description = "Nombre", Name = "Nombre ")]
        public string Nombre { get; set; }

    }
}