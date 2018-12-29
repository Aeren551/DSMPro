using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM2.Models
{
    public class Grupo
    {
        //LOS MODELS SON COMO LOS EN DE ESA CLASE, SOLO DECLARAS QUE VA A TENER
        //De: https://www.tutorialspoint.com/asp.net_mvc/asp.net_mvc_scaffolding.htm
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Display(Prompt = "Nombre", Description = "Nombre", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre")]
        [StringLength(maximumLength: 20, ErrorMessage = "El nombre no puede tener más de 20 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Usuarios", Description = "Usuarios", Name = "Usuarios ")]
        public IList<string> ListaUsu { get; set; }

        [ScaffoldColumn(false)]
        public int cantidad { get; set; }

    }
}